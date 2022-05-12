using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace server
{
    public class Database
    {
        private readonly string filename = "database.txt";
        private IEnumerable<User> users;

        public Database()
        {
            users = new List<User>();

            if (!File.Exists(filename))
            {
                File.Create(filename).Dispose();
            }
        }

        public bool Exists(string username)
        {
            ReadFile();
            return users.Where(user => user.Username == username).ToArray().Length > 0;
        }

        public void InsertUser(User user)
        {
            using (var file = File.AppendText(filename))
            {
                file.WriteLine($"username={user.Username}&name={user.Name}&surname={user.Surname}&password={user.Password}");
            }
        }

        private void ReadFile()
        {
            users = File.ReadAllLines(filename).Select(line =>
            {
                var re = new Regex("username=(.*)&name=(.*)&surname=(.*)&password=(.*)");
                var groups = re.Matches(line);
                return new User
                {
                    Username = groups[0].Groups[1].Value,
                    Name = groups[0].Groups[2].Value,
                    Surname = groups[0].Groups[3].Value,
                    Password = groups[0].Groups[4].Value,
                };
            });
        }
    }
}
