﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace server
{
    public class Server : IDisposable
    {
        private UsersDatabase _userDb;
        private PostsDatabase _postDb;
        private Logger _logger;

        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets = new List<Socket>();

        bool terminating = false;
        bool listening = false;

        public Server(UsersDatabase userDb, PostsDatabase postDb, Logger logger)
        {
            _userDb = userDb;
            _postDb = postDb;
            _logger = logger;
        }

        public bool Listen(int port)
        {
            listening = true;

            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3);

                Thread acceptThread = new Thread(accept);
                acceptThread.Start();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        private bool Send(Socket client, string message)
        {

            Byte[] buffer = Encoding.Default.GetBytes(message);

            try
            {
                client.Send(buffer);
            }
            catch
            {
                client.Close();
                return false;
            }

            return true;
        }

        private void accept()
        {
            while (listening)
            {
                try
                {
                    Socket newClient = serverSocket.Accept();
                    Byte[] buffer = new Byte[1024];
                    if (newClient.Receive(buffer) > 0)
                    {
                        string message = Encoding.Default.GetString(buffer);
                        message = message.Substring(0, message.IndexOf('\0'));
                        var username = CayGetirProtocol.ParseUserName(message);

                        if (!_userDb.Exists((item) => item == username))
                        {
                            _logger.Write($"{username} tried to connect to the server but cannot\n");
                            var response = CayGetirProtocol.Error("Please enter a valid username!");
                            Send(newClient, response);
                            
                            newClient.Close();
                            continue;
                            //burada connect olamadığı için throw error yapıcaz bence ama burayı sana bıraktık :))
                        }
                        else
                        {
                            _logger.Write($"{username} has connected\n");
                            var response = CayGetirProtocol.Message($"Hello {username}! You are connected to the server.");
                            Send(newClient, response);
                        }
                    }
                    clientSockets.Add(newClient);

                    Thread receiveThread = new Thread(() => receive(newClient));
                    receiveThread.Start();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        _logger.Write("The socket stopped working.\n");
                    }
                }
            }
        }

        private void receive(Socket client)
        {
            bool connected = true;

            while (connected && !terminating)
            {
                try
                {
                    Byte[] buffer = new Byte[1024];
                    if (client.Receive(buffer) > 0)
                    {
                        string message = Encoding.Default.GetString(buffer);
                        message = message.Substring(0, message.IndexOf('\0'));

                        HandleIncomingMessage(client, message);
                    }
                }
                catch (SocketException ex)
                {
                    if (!terminating)
                    {
                        _logger.Write("A client has disconnected\n");
                    }
                    client.Close();
                    clientSockets.Remove(client);
                    connected = false;
                }
            }
        }

        public void HandleIncomingMessage(Socket client, string message)
        {
            var type = CayGetirProtocol.DetermineType(message);

            if (type == MessageType.Message)
            {
                var payload = CayGetirProtocol.ParseMessage(message);

                if (payload.Contains("POSTS"))
                {
                    var re = new Regex("POSTS username=(.*)");
                    var groups = re.Matches(message);

                    var username = groups[0].Groups[1].Value;
                    _logger.Write($"Showed all posts for {username}\n");
                    SendPosts(client, username);
                }
            }
        }

        private void SendPosts(Socket client, string username)
        {
            var posts = _postDb.GetPostsExceptUsername(username);
            var response = CayGetirProtocol.Posts(posts);
            Send(client, response);
        }

        public void Dispose()
        {
            listening = false;
            terminating = true;
        }
    }
}
