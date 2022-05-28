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
            return base.items.Where(item => item.Username != username && item.isActive);
        }
        public IEnumerable<Post> GetPostsOfUsername(string username)
        {
            ReadFile();
            return base.items.Where(item => item.Username == username && item.isActive);
        }
        public IEnumerable<Post> GetArchiveOfUsername(string username)
        {
            ReadFile();
            return base.items.Where(item => item.Username == username && !item.isActive);
        }

        public IEnumerable<Post> GetPostsOfUsers(IEnumerable<string> users)
        {
            return base.items.Where(item => users.Contains(item.Username) && item.isActive);
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
        public bool DeletePost(int id, string username)
        {
            var result = UpdateItem(
                item =>
                {
                    item.isActive = false;
                    return item;
                },
                item => item.Id == id && item.Username == username
            );

            return result > 0;
        }
        public bool ActivatePost(int id, string username)
        {
            var result = UpdateItem(
                item =>
                {
                    item.isActive = true;
                    return item;
                },
                item => item.Id == id && item.Username == username
            );

            return result > 0;
        }
        public Post GetPostById(int id)
        {
            try
            {
                return base.items.Where(item => item.Id == id).First(); 
            } 
            catch
            {
                return null;
            }
        }
    }
}
