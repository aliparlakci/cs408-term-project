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
        private FriendshipDatabase _friendshipDb;
        private Logger _logger;

        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<Client> clients = new List<Client>();

        bool terminating = false;
        bool listening = false;

        public Server(UsersDatabase userDb, PostsDatabase postDb, FriendshipDatabase friendshipDb, Logger logger)
        {
            _userDb = userDb;
            _postDb = postDb;
            _friendshipDb = friendshipDb;
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

            SendFriends(client);

            while (connected && !terminating)
            {
                try
                {
                    Byte[] buffer = new Byte[4096];
                    if (client.Socket.Receive(buffer) > 0)
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
                Send(client.Socket, CayGetirProtocol.Message("Showing all posts from clients:"));
                _logger.Write($"Showed all posts for {client.Username}\n");
                SendPosts(client, client.Username);
            }

            else if (type == MessageType.RequestMyPosts)
            {
                Send(client.Socket, CayGetirProtocol.Message("Showing your posts:"));
                _logger.Write($"Showed {client.Username}'s posts\n");
                SendOwnPosts(client, client.Username);
            }
            else if (type == MessageType.RequestMyArchive)
            {
                Send(client.Socket, CayGetirProtocol.Message("Showing your archive:"));
                _logger.Write($"Showed {client.Username}'s archive\n");
                SendOwnArchive(client, client.Username);
            }

            else if (type == MessageType.DeletePost)
            {
                var deleteRequestId = CayGetirProtocol.ParsePostActionRequest(message);
                DeletePost(client, deleteRequestId);
            }
            else if (type == MessageType.ActivatePost)
            {
                var deleteRequestId = CayGetirProtocol.ParsePostActionRequest(message);
                ActivatePost(client, deleteRequestId);
            }
            else if (type == MessageType.RequestFriends)
            {
                var friends = _friendshipDb.GetFriendsOf(client.Username);
                Send(client.Socket, CayGetirProtocol.Friends(friends));
            }
            else if (type == MessageType.AddFriend)
            {
                var username = CayGetirProtocol.ParseAddFriend(message);
                AddFriend(client, username);
            }
            else if (type == MessageType.RemoveFriend)
            {
                var username = CayGetirProtocol.ParseRemoveFriend(message);
                RemoveFriend(client, username);
            }
        }

        private void AddFriend(Client client, string username)
        {
            if (!_userDb.Exists(user => user == username))
            {
                Send(client.Socket, CayGetirProtocol.Error($"Person with username {username} does not exists"));
                _logger.Write($"{client.Username} tried to add {username} as their friend but {username} does not exist!");
                return;
            }

            var success = _friendshipDb.AddFriendship(client.Username, username);
            if (success)
            {
                Send(client.Socket, CayGetirProtocol.Message($"You successfully added {username} as your friend"));
                _logger.Write($"{client.Username} added {username} as their friend.\n");
            }
            else
            {
                Send(client.Socket, CayGetirProtocol.Error($"{username} is already your friend"));
                _logger.Write($"{client.Username} tried to add {username} as their friend but {username} is already their friend!\n");
            }
            BroadcastFriendsList();
        }

        private void RemoveFriend(Client client, string username)
        {
            var success = _friendshipDb.RemoveFriendship(client.Username, username);
            if (success)
            {
                Send(client.Socket, CayGetirProtocol.Message($"You successfully removed {username} from your friends"));
                _logger.Write($"{client.Username} removed {username} from their friends.\n");
            }
            else
            {
                Send(client.Socket, CayGetirProtocol.Error($"{username} is not your friend!"));
                _logger.Write($"{client.Username} tried to unfriend {username} but {username} is not their friend!\n");
            }
            BroadcastFriendsList();
        }

        private void DeletePost(Client client, int deleteRequestId)
        {
            var post = _postDb.GetPostById(deleteRequestId);
            if (post == null)
            {
                _logger.Write($"{client.Username} tried to delete post with ID: {deleteRequestId}. However it does not exist!\n");
                string errorMessage = $"There is no post with ID: {deleteRequestId}";
                var response = CayGetirProtocol.Message(errorMessage);
                Send(client.Socket, response);
            }
            else if (!post.isActive)
            {
                _logger.Write($"{client.Username} tried to delete post with ID: {deleteRequestId}. However, it has been already deleted!\n");
                string errorMessage = $"Post with ID {deleteRequestId} has been already deleted!";
                var response = CayGetirProtocol.Message(errorMessage);
                Send(client.Socket, response);
            }
            else
            {
                if (!_postDb.DeletePost(deleteRequestId, client.Username))
                {
                    _logger.Write($"Post with ID {deleteRequestId} does not belong to {client.Username}\n");
                    string errorMessage = $"Post with ID {deleteRequestId} is not yours!";
                    var response = CayGetirProtocol.Message(errorMessage);
                    Send(client.Socket, response);
                }
                else
                {
                    _logger.Write($"{client.Username} deleted the post with ID {deleteRequestId}\n");
                    string successMessage = $"Post with ID {deleteRequestId} deleted successfully";
                    var response = CayGetirProtocol.Message(successMessage);
                    Send(client.Socket, response);
                }

            }
        }
        private void ActivatePost(Client client, int activateRequestId)
        {
            var post = _postDb.GetPostById(activateRequestId);
            if (!_postDb.Exists(item => item.Id == activateRequestId))
            {
                _logger.Write($"{client.Username} tried to activate post with ID: {activateRequestId}. However it does not exist!\n");
                string errorMessage = $"There is no post with ID: {activateRequestId}";
                var response = CayGetirProtocol.Message(errorMessage);
                Send(client.Socket, response);
            }
            else if (post.isActive)
            {
                _logger.Write($"{client.Username} tried to activate post with ID: {activateRequestId}. However, it is active!\n");
                string errorMessage = $"Post with ID {activateRequestId} has been already active!";
                var response = CayGetirProtocol.Message(errorMessage);
                Send(client.Socket, response);
            }
            else
            {
                if (!_postDb.ActivatePost(activateRequestId, client.Username))
                {
                    _logger.Write($"Post with ID {activateRequestId} does not belong to {client.Username}\n");
                    string errorMessage = $"Post with ID {activateRequestId} is not yours";
                    var response = CayGetirProtocol.Message(errorMessage);
                    Send(client.Socket, response);
                }
                else
                {
                    _logger.Write($"{client.Username} activated the post with ID {activateRequestId}\n");
                    string successMessage = $"Post with ID {activateRequestId} activated successfully";
                    var response = CayGetirProtocol.Message(successMessage);
                    Send(client.Socket, response);
                }

            }
        }

        private void SendPosts(Client client, string username)
        {
            var posts = _postDb.GetPostsExceptUsername(username);
            var response = CayGetirProtocol.Posts(posts);
            Send(client.Socket, response);
        }

        private void SendOwnPosts(Client client, string username)
        {
            var posts = _postDb.GetPostsOfUsername(username);
            var response = CayGetirProtocol.Posts(posts);
            Send(client.Socket, response);
        }

        private void SendOwnArchive(Client client, string username)
        {
            var posts = _postDb.GetArchiveOfUsername(username);
            var response = CayGetirProtocol.Posts(posts);
            Send(client.Socket, response);
        }

        private void BroadcastFriendsList()
        {
            clients.ForEach(SendFriends);
        }

        private void SendFriends(Client client)
        {
            var friends = _friendshipDb.GetFriendsOf(client.Username);
            var message = CayGetirProtocol.Friends(friends);
            Send(client.Socket, message);
        }

        public void Dispose()
        {
            listening = false;
            terminating = true;
        }
    }
}
