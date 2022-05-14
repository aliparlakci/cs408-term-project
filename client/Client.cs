﻿using System;
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

        private Action onDisconnect;
        private Action onUsernameAlreadyExists;
        private Action onSuccessfulAccountCreation;
        private Action onUsernameNotExists;

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

        public void SetTerminating() { terminating = true; }

        public bool TryConnect(string ip, int port, string username)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                clientSocket.Connect(ip, port);
                connected = true;

                var message = CayGetirProtocol.Login(username);
                Send(message);

                Thread receiveThread = new Thread(handshake);
                receiveThread.Start();
            }
            catch
            {
                return false;
            }

            return true;
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

                if (!message.Contains("created an account"))
                {
                    if (onSuccessfulAccountCreation != null) onSuccessfulAccountCreation();
                }

                _logger.Write($"{message}\n");
            }

            if(type == MessageType.Posts)
            {
                var posts = CayGetirProtocol.ParsePosts(incomingMessage);

                _logger.Write("Showing all posts from clients:\n");
                foreach(var post in posts)
                {
                    _logger.Write($"");
                }
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
                            receiveThread.Start();
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
                catch
                {
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
                    Byte[] buffer = new Byte[1024];
                    if (clientSocket.Receive(buffer) > 0)
                    {
                        string message = Encoding.Default.GetString(buffer);
                        message = message.Substring(0, message.IndexOf('\0'));

                        HandleIncomingMessage(message);
                    }
                }
                catch
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
