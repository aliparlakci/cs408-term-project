using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    public class UsersDatabase : Database<String>
    {
        public UsersDatabase(string filename) : base(filename) { }

        //public void InsertUser(User user)
        //{
        //    base.InsertItem(user);
        //}
    }
}
