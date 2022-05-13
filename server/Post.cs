using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    public class Post
    {
        public Post() { }

        public Post(string username, string body)
        {
            Id = currentId;
            currentId = currentId + 1;

            Username = username;
            Body = body;
            CreatedAt = DateTime.Now;
        }

        public Post(int id, string username, string body, DateTime time)
        {
            Id = id;
            currentId = Math.Max(currentId, Id) + 1;

            Username = username;
            Body = body;
            CreatedAt = time;
        }

        public static void SetCurrentId(int id)
        {
            currentId = id;
        }

        private static int currentId = 1;
        public int Id;
        public string Username;
        public string Body;
        public DateTime CreatedAt;
    }
}
