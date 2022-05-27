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

        public static string Signup(string name, string surname, string username, string password)
        {
            return $"Cay Getir 1.0\ntype=signup\nname={name}\nsurname={surname}\nusername={username}\npassword={password}";
        }

        public static string Login(string username)
        {
            return $"Cay Getir 1.0\ntype=login\nusername={username}";
        }

        public static string NewPost(int id, string username, string body, DateTime createdAt)
        {
            return $"Cay Getir 1.0\ntype=newpost\nid={id.ToString()}\nusername={username}\ntimestamp={createdAt.ToString()}\nbody={body}";
        }

        public static string Posts(IEnumerable<Post> posts)
        {
            var str = $"Cay Getir 1.0\ntype=posts\n";

            foreach (var post in posts)
            {
                str += $"id={post.Id}&username={post.Username}&timestamp={post.CreatedAt.ToString()}&body={post.Body}\n";
            }

            return str;
        }

        public static string RequestPosts(string username)
        {
            return $"Cay Getir 1.0\ntype=request_posts\nusername={username}";
        }

        public static string DeletePost(int id, string username)
        {
            return $"Cay Getir 1.0\ntype =delete_post\nid={id.ToString()}\nusername={username}";
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

            if (type == "login")
            {
                return MessageType.Login;
            }

            if (type == "newpost")
            {
                return MessageType.NewPost;
            }

            if (type == "posts")
            {
                return MessageType.Posts;
            }

            if (type == "error")
            {
                return MessageType.Error;
            }

            if (type == "request_posts")
            {
                return MessageType.RequestPosts;
            }
            if (type == "delete_post")
            {
                return MessageType.DeletePost;
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

        public static string ParseUserName(string message)
        {
            var lines = message.Split(new char[] { '\n' });

            return lines[2].Substring(9);
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
        
        public static Post ParseNewPost(string message)
        {
            var lines = message.Split(new char[] { '\n' });

            var re = new Regex(@"Cay Getir 1.0\ntype=newpost\nid=(.*)\nusername=(.*)\ntimestamp=(.*)\nbody=([\S\s]*)");
            var groups = re.Matches(message);
            var post = new Post
            {
                Id = Int32.Parse(groups[0].Groups[1].Value),
                Username = groups[0].Groups[2].Value,
                CreatedAt = DateTime.Parse(groups[0].Groups[3].Value),
                Body = groups[0].Groups[4].Value,
            };

            return post;
        }

        public static string ParseRequestPosts(string message)
        {
            var lines = message.Split(new char[] { '\n' });

            return lines[2].Substring(9);
        }
        
        public static IEnumerable<Post> ParsePosts(string message)
        {
            var lines = message.Split(new char[] { '\n' });
            var posts = new List<Post> { };

            foreach (var line in lines.Skip(2))
            {
                try
                {
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
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    continue;
                }
            }

            return posts;
        }
        public static DeletePostRequest ParseDeletePost(string message)
        {
            var lines = message.Split(new char[] { '\n' });
            var request = new DeletePostRequest();
            request.Id = Int32.Parse(lines[2].Substring(3));
            request.Username = lines[3].Substring(9);
            return request;
        }
    }

    public enum MessageType
    {
        Message,
        Signup,
        Login,
        Error,
        NewPost,
        Posts,
        RequestPosts,
        DeletePost
    }
}
