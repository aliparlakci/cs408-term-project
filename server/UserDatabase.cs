using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    public class UsersDatabase : Database<User>
    {
        public UsersDatabase(string filename) : base(filename) { }

        public override void InsertItem(User user)
        {
            using (var file = File.AppendText(_filename))
            {
                file.WriteLine($"username={user.Username}&name={user.Name}&surname={user.Surname}&password={user.Password}");
            }   
        }

        protected override void ReadFile()
        {
            items = File.ReadAllLines(_filename).Select(line =>
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
