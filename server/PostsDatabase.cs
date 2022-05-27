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

        public IEnumerable<Post> GetPostsExceptUsername(string username)
        {
            ReadFile();
            return base.items.Where(item => item.Username != username);
        }

        public IEnumerable<Post> GetPostsOfUsers(IEnumerable<User> users)
        {
            return base.items.Where(item => users.Select(user => user.Username).Contains(item.Username));
        }

        public void InsertPost(Post post)
        {
            try
            {
                post.Id = items.Max(item => item.Id) + 1;
            }
            catch
            {
                post.Id = 1;
            }
            InsertItem(post);
        }
        public bool DeletePost(DeletePostRequest request)
        {
            var result = UpdateItem(
                item =>
                {
                    item.isActive = false;
                    return item;
                },
                item => item.Id == request.Id && item.Username == request.Username
            );

            return result > 0;
        }
    }
}
