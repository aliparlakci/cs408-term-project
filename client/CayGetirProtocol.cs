using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    public class CayGetirProtocol
    {
        public static string Message(string message)
        {
            return $"Cay Getir 1.0\ntype=message\nmessage={message}";
        }

        public static string Error(string message)
        {
            return $"Cay Getir 1.0\ntype=error\nmessage={message}";
        }

        public static string Signup(string name, string surname, string username, string password)
        {
            return $"Cay Getir 1.0\ntype=signup\nname={name}\nsurname={surname}\nusername={username}\npassword={password}";
        }

        public static MessageType DetermineType(string message)
        {
            var lines = message.Split(new char[] { '\n' });
            var type = lines[1].Substring(5);
            
            if (type == "message")
            {
                return MessageType.Message;
            }

            if (type == "signup")
            {
                return MessageType.Signup;
            }

            if (type == "error")
            {
                return MessageType.Error;
            }

            return MessageType.Message;
        }

        public static string ParseMessage(string message)
        {
            var lines = message.Split(new char[] { '\n' });

            return lines[2].Substring(8);
        }

        public static string ParseError(string message)
        {
            var lines = message.Split(new char[] { '\n' });

            return lines[2].Substring(8);
        }
    }

    public enum MessageType
    {
        Message,
        Signup,
        Error
    }
}
