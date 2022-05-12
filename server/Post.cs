using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    public class Post
    {
        private static int CurrentId = 1;
        public int Id;
        public string Username;
        public string Body;
        public DateTime Timestamp;
    }
}
