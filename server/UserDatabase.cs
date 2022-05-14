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

        protected override void ReadFile()
        {
            items = File.ReadAllLines(_filename).ToList();
        }

        protected override void WriteToFile()
        {
            File.WriteAllLines(_filename, items);
        }
    }
}
