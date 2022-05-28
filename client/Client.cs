using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace client
{
    public class Client
    {
        private Logger _logger;

        Socket clientSocket;

        bool terminating = false;
        bool connected = false;

        private string _username = "";

        private Action onDisconnect;
        private Action onUsernameAlreadyExists;
        private Action onSuccessfulAccountCreation;
        private Action onUsernameNotExists;
        private Action onConnect;
        private Action onSendNewPost;
        private Action<IEnumerable<string>> onSetFriends;

        public Client(Logger logger)
        {
            _logger = logger;
        }

        public void OnDisconnect(Action func)
        {
            onDisconnect = func;
        }

        public void OnUsernameAlreadyExists(Action func)
        {
            onUsernameAlreadyExists = func;
        }

        public void OnUsernameNotExists(Action func)
        {
            onUsernameNotExists = func;
        }

        public void OnSuccessfulAccountCreation(Action func)
        {
            onSuccessfulAccountCreation = func;
        }

        public void OnConnect(Action func)
        {
            onConnect = func;
        }

        public void OnSendNewPost(Action func)
        {
            onSendNewPost = func;
        }

        public void OnSetFriends(Action<IEnumerable<string>> func)
        {
            onSetFriends = func;
        }

        public void SetTerminating() { terminating = true; }

        public void Connect(string ip, int port, string username)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                clientSocket.Connect(ip, port);
                connected = true;

                var message = CayGetirProtocol.Login(username);
                _username = username;
                Send(message);

                Thread receiveThread = new Thread(handshake);
                receiveThread.Start();
            }
            catch
            {
                _logger.Write("Cannot connect to the specified destination.\n");
                if (onDisconnect != null) onDisconnect();
            }
        }

        public void RequestPosts()
        {
            var message = CayGetirProtocol.RequestPosts();
            Send(message);
        }

        public void RequestMyPosts()
        {
            var message = CayGetirProtocol.RequestMyPosts();
            Send(message);
        }

        public void RequestMyArchive()
        {
            var message = CayGetirProtocol.RequestMyArchive();
            Send(message);
        }

        public void RequestFriendsPosts()
        {
            var message = CayGetirProtocol.RequestFriendsPosts();
            Send(message);
        }

        public void AddFriend(string username)
        {
            var message = CayGetirProtocol.AddFriend(username);
            Send(message);
        }

        public void RemoveFriend(string username)
        {
            var message = CayGetirProtocol.RemoveFriend(username);
            Send(message);
        }

        public void SendNewPost(string body)
        {
            var message = CayGetirProtocol.NewPost(0, _username, body, DateTime.Now);
            Send(message);
        }

        public void DeletePost(int id)
        {
            var message = CayGetirProtocol.DeletePost(id);
            Send(message);
        }
        public void ActivatePost(int id)
        {
            var message = CayGetirProtocol.ActivatePost(id);
            Send(message);
        }

        public bool Send(string message)
        {
            if (!connected)
            {
                return false;
            }

            Byte[] buffer = Encoding.Default.GetBytes(message);
            
            try
            {
                clientSocket.Send(buffer);
            }
            catch
            {
                clientSocket.Close();
                connected = false;

                if (onDisconnect != null) onDisconnect();

                return false;
            }

            return true;
        }

        public void Disconnect()
        {
            clientSocket.Close();
            if (onDisconnect != null) onDisconnect();
        }

        private void HandleIncomingMessage(string incomingMessage)
        {
            var type = CayGetirProtocol.DetermineType(incomingMessage);

            if (type == MessageType.Error)
            {
                var error = CayGetirProtocol.ParseError(incomingMessage);
                if (error.Contains("already an account"))
                {
                    if (onUsernameAlreadyExists != null) onUsernameAlreadyExists();
                    _logger.Write($"{error}\n");
                }

                if (error.Contains("enter a valid username"))
                {
                    if (onUsernameAlreadyExists != null) onUsernameAlreadyExists();
                    _logger.Write($"{error}\n");
                }
            }

            if (type == MessageType.Message)
            {
                var message = CayGetirProtocol.ParseMessage(incomingMessage);
                _logger.Write($"{message}\n");
            }

            if (type == MessageType.Posts)
            {
                var posts = CayGetirProtocol.ParsePosts(incomingMessage);

                foreach (var post in posts)
                {
                    _logger.Write($"Username: {post.Username}\n");
                    _logger.Write($"PostIDs: {post.Id}\n");
                    _logger.Write($"Post: {post.Body}\n");
                    _logger.Write($"Timestamp: {post.CreatedAt}\n\n");
                }
            }

            if (type == MessageType.NewPost)
            {
                if (onSendNewPost != null) onSendNewPost();
                var post = CayGetirProtocol.ParseNewPost(incomingMessage);
                _logger.Write("\nYou have successfull sent a post!\n");
                _logger.Write($"{post.Username}: {post.Body}\n");
            }

            if (type == MessageType.Friends)
            {
                var friends = CayGetirProtocol.ParseFriends(incomingMessage);
                if (onSendNewPost != null) onSetFriends(friends);
            }
        }

        private void handshake()
        {
            while (connected)
            {
                try
                {
                    Byte[] buffer = new Byte[1024];
                    if (clientSocket.Receive(buffer) > 0)
                    {
                        string message = Encoding.Default.GetString(buffer);
                        message = message.Substring(0, message.IndexOf('\0'));
                        var type = CayGetirProtocol.DetermineType(message);
                        var payload = CayGetirProtocol.ParseMessage(message);

                        if (type == MessageType.Message)
                        {
                            _logger.Write($"{payload}\n");
                            Thread receiveThread = new Thread(receive);
                            if (onConnect != null) onConnect();
                            receiveThread.Start();
                            connected = true;
                            break;
                        }
                        else
                        {
                            _logger.Write($"{CayGetirProtocol.ParseError(message)}\n");
                            connected = false;
                            clientSocket.Close();
                            if (onUsernameNotExists != null) onUsernameNotExists();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    connected = false;
                    clientSocket.Close();
                    if (onDisconnect != null) onDisconnect();
                }
            }
        }

        private void receive()
        {
            while (connected)
            {
                try
                {
                    Byte[] buffer = new Byte[4096];
                    if (clientSocket.Receive(buffer) > 0)
                    {
                        string message = Encoding.Default.GetString(buffer);
                        message = message.Substring(0, message.IndexOf('\0'));

                        HandleIncomingMessage(message);
                    }
                }
                catch (Exception ex)
                {
                    if (!terminating)
                    {
                        _logger.Write("Server has disconnected.\n");
                    }
                    else
                    {
                        terminating = false;
                    }

                    clientSocket.Close();
                    connected = false;
                    if (onDisconnect != null) onDisconnect();
                    _logger.Write("Succesfully disconnected!\n");
                }
            }
        }
    }
}
