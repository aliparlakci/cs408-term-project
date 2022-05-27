using System;
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
        List<Client> clients = new List<Client>();

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
                        }
                        else if (clients.Any(client => client.Username == username))
                        {
                            _logger.Write($"{username} tried to connect again!\n");
                            var response = CayGetirProtocol.Error($"Hey {username}, you have already connected");
                            Send(newClient, response);
                            newClient.Close();
                        }
                        else
                        {
                            _logger.Write($"{username} has connected\n");
                            var response = CayGetirProtocol.Message($"Hello {username}! You are connected to the server.");
                            Send(newClient, response);

                            var client = new Client
                            {
                                Socket = newClient,
                                Username = username,
                            };
                            clients.Add(client);

                            Thread receiveThread = new Thread(() => receive(client));
                            receiveThread.Start();
                        }
                    }
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

        private void receive(Client client)
        {
            bool connected = true;

            while (connected && !terminating)
            {
                try
                {
                    Byte[] buffer = new Byte[8];
                    string message = "";
                    int bytesReceived = 0;
                    while ((bytesReceived = client.Socket.Receive(buffer)) > 0)
                    {
                        string bufferString = Encoding.Default.GetString(buffer);
                        if (bufferString.IndexOf('\0') > 0)
                        {
                            bufferString = bufferString.Substring(0, bufferString.IndexOf('\0'));
                        }
                        message += bufferString;

                        if (bytesReceived < 8)
                            HandleIncomingMessage(client, message);

                        buffer = new Byte[8];
                    }
                }
                catch (SocketException ex)
                {

                    if (!terminating)
                    {
                        _logger.Write($"{client.Username} has disconnected\n");
                    }
                    client.Socket.Close();
                    clients.Remove(client);
                    connected = false;
                }
            }
        }

        public void HandleIncomingMessage(Client client, string message)
        {
            var type = CayGetirProtocol.DetermineType(message);

            if (type == MessageType.Message)
            {
                var payload = CayGetirProtocol.ParseMessage(message);
            }
            else if (type == MessageType.NewPost)
            {
                var post = CayGetirProtocol.ParseNewPost(message);
                _postDb.InsertPost(post);
                _logger.Write($"{post.Username} has sent a post: {post.Body}\n");
                var response = CayGetirProtocol.NewPost(post.Id, post.Username, post.Body, post.CreatedAt);
                Send(client.Socket, response);
            }
            else if (type == MessageType.RequestPosts)
            {
                var username = CayGetirProtocol.ParseRequestPosts(message);
                _logger.Write($"Showed all posts for {username}\n");
                SendPosts(client, username);
            }
            else if (type == MessageType.DeletePost)
            {
                var deleteRequest = CayGetirProtocol.ParseDeletePost(message);
                if (_postDb.Exists(item => item.Id == deleteRequest.Id))
                {
                    _logger.Write($"{deleteRequest.Username} tried to delete post with ID: {deleteRequest.Id}. However it does not exist!\n");
                    string errorMessage = $"There is no post with ID: {deleteRequest.Id}";
                    var response = CayGetirProtocol.Message(errorMessage);
                    Send(client.Socket, response);
                }
                else
                {
                    if (!_postDb.DeletePost(deleteRequest))
                    {
                        _logger.Write($"Post with ID {deleteRequest.Id} does not belong to {deleteRequest.Username}\n");
                        string errorMessage = $"Post with ID {deleteRequest.Id} is not yours";
                        var response = CayGetirProtocol.Message(errorMessage);
                        Send(client.Socket, response);
                    }
                    else
                    {
                        _logger.Write($"{deleteRequest.Username} deleted the post with ID {deleteRequest.Id}");
                        string successMessage = $"Post with ID {deleteRequest.Id} deleted successfully";
                        var response = CayGetirProtocol.Message(successMessage);
                        Send(client.Socket, response);
                    }

                }
            }
        }

        private void SendPosts(Client client, string username)
        {
            var posts = _postDb.GetPostsExceptUsername(username);
            var response = CayGetirProtocol.Posts(posts);
            Send(client.Socket, response);
        }

        public void Dispose()
        {
            listening = false;
            terminating = true;
        }
    }
}
