using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace server
{
    public class PostsDatabase : Database<Post>
    {
        public override void InsertItem(Post item)
        {
            using (var file = File.AppendText(filename))
            {
                file.WriteLine($"id={item.Id}&username={item.Username}&post={item.Body}&timestamp={item.Timestamp.ToString()}");
            }
        }

        protected override void ReadFile()
        {
            items = File.ReadAllLines(filename).Select(line =>
            {
                var re = new Regex("id=(.*)&username=(.*)&post=(.*)");
                var groups = re.Matches(line);
                return new Post
                {
                    Id = Int32.Parse(groups[0].Groups[1].Value),
                    Username = groups[0].Groups[2].Value,
                    Body = groups[0].Groups[3].Value,
                    Timestamp = DateTime.Parse(groups[0].Groups[4].Value)
                };
            });
        }
    }
}
