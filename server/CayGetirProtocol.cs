using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace server
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

        public static string Login(string name, string surname, string username, string password)
        {
            return $"Cay Getir 1.0\ntype=signup\nname={name}\nsurname={surname}\nusername={username}\npassword={password}";
        }

        public static string NewPost(string name, string surname, string username, string password)
        {
            return $"Cay Getir 1.0\ntype=signup\nname={name}\nsurname={surname}\nusername={username}\npassword={password}\n";
        }

        public static string Posts(Post[] posts)
        {
            var str = $"Cay Getir 1.0\ntype=posts\n";

            foreach (var post in posts)
            {
                str += $"id={post.Id}&username={post.Username}&body={post.Body}&timestamp={post.CreatedAt.ToString()}\n";
            }

            return str;
        }

        public static MessageType DetermineType(string message)
        {
            var lines = message.Split(new char[] { '\n' });
            var type = lines[1].Substring(6);
            
            if (type == "message")
            {
                return MessageType.Message;
            }

            if (type == "signup")
            {
                return MessageType.Signup;
            }

            if (type == "posts")
            {
                return MessageType.Posts;
            }

            if (type == "error")
            {
                return MessageType.Error;
            }

            return MessageType.Message;
        }

        public static User ParseUser(string message)
        {
            var user = new User();
            var lines = message.Split(new char[] { '\n' });

            user.Name = lines[2].Substring(5);
            user.Surname = lines[3].Substring(8);
            user.Username = lines[4].Substring(9);
            user.Password = lines[5].Substring(9);

            return user;
        }

        public static string ParseMessage(string message)
        {
            var lines = message.Split(new char[] { '\n' });

            return lines[2].Substring(8);
        }

        public static List<Post> ParsePosts(string message)
        {
            var lines = message.Split(new char[] { '\n' });

            var posts = new List<Post> { };

            var line = lines[3];
            var re = new Regex("id=(.*)&username=(.*)&body=(.*)&timestamp=(.*)");
            var groups = re.Matches(line);
            var post = new Post
            {
                Id = Int32.Parse(groups[0].Groups[1].Value),
                Username = groups[0].Groups[2].Value,
                Body = groups[0].Groups[3].Value,
                CreatedAt = DateTime.Parse(groups[0].Groups[4].Value),
            };

            posts.Add(post);
            return posts;

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
        Error,
        Posts
    }
}
