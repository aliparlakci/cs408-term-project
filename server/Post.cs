using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    public class Post
    {
        public Post()
        {
            isActive = true;
        }

        public Post(int id, string username, string body, DateTime time, bool active=true)
        {
            Id = id;

            Username = username;
            Body = body;
            CreatedAt = time;
            isActive = active;
        }

        public int Id;
        public string Username;
        public string Body;
        public bool isActive;
        public DateTime CreatedAt;
    }
}
