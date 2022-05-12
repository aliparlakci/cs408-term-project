﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace server
{
    public class Server : IDisposable
    {
        private Database _db;
        private Logger _logger;

        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Socket> clientSockets = new List<Socket>();

        bool terminating = false;
        bool listening = false;

        public Server(Database db, Logger logger)
        {
            _db = db;
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
                    clientSockets.Add(newClient);
                    _logger.Write("A client is connected.\n");

                    Thread receiveThread = new Thread(() => receive(newClient));
                    receiveThread.Start();
                }
                catch
                {
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

                        var user = CayGetirProtocol.ParseUser(message);
                        if (!_db.Exists(user.Username))
                        {
                            _db.InsertUser(user);
                            _logger.Write($"{user.Username} has created an account!\n");
                            var response = CayGetirProtocol.Message("You have created a new account!");
                            Send(client, response);
                        }
                        else
                        {
                            _logger.Write($"An account with the username {user.Username} already exists!\n");
                            var response = CayGetirProtocol.Error("There is already an account with this username!");
                            Send(client, response);
                        }
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

        public void Dispose()
        {
            listening = false;
            terminating = true;
        }
    }
}
