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
        public PostsDatabase(string filename) : base(filename) { }

        public override void InsertItem(Post item)
        {
            using (var file = File.AppendText(_filename))
            {
                file.WriteLine($"id={item.Id}&username={item.Username}&post={item.Body}&timestamp={item.CreatedAt.ToString()}");
            }
        }

        public IEnumerable<Post> GetPostsExceptUsername(string username)
        {
            ReadFile();
            return items.Where(item => item.Username != username);
        }

        protected override void ReadFile()
        {
            Post.SetCurrentId(1);
            items = File.ReadAllLines(_filename).Select(line =>
            {
                var re = new Regex("id=(.*)&username=(.*)&post=(.*)&timestamp=(.*)");
                var groups = re.Matches(line);
                return new Post(
                        Int32.Parse(groups[0].Groups[1].Value),
                        groups[0].Groups[2].Value,
                        groups[0].Groups[3].Value,
                        DateTime.Parse(groups[0].Groups[4].Value)
                    );
            });
        }
    }
}
