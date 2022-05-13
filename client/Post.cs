using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    public class Post
    {
        public Post() { }

        public Post(int id, string username, string body, DateTime time)
        {
            Id = id;
            Username = username;
            Body = body;
            CreatedAt = time;
        }

        public int Id;
        public string Username;
        public string Body;
        public DateTime CreatedAt;
    }
}
