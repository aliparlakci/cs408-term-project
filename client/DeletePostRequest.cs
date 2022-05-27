using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    public class DeletePostRequest
    {
        public DeletePostRequest() { }

        public DeletePostRequest(int id, string username)
        {
            Id = id;
            Username = username;
        }

        public int Id;
        public string Username;
    }
}
