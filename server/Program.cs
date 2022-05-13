using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace server
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var usersDb = new UsersDatabase("users.txt");
            var postsDb = new PostsDatabase("posts.txt");

            //var logger = new Logger();
            //var server = new Server(usersDb, postsDb, logger);

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ServerForm(server, logger));

            var a1 = new Post("aliparlakci", "Bu benim mesajım.");
            var a2 = new Post("aliparlakci", "Bu da diğer mesajım.");
            var a3 = new Post("atakan", "Bu kimin mesajı?");

            var serialized = JsonConvert.SerializeObject(new Post[] { a1, a2, a3 }); // server
            var a4 = JsonConvert.DeserializeObject<Post[]>(serialized); // client

            postsDb.InsertItem(a1);
            postsDb.InsertItem(a2);
            postsDb.InsertItem(a3);
            var a = postsDb.GetPostsExceptUsername("atakan").ToList();

            return;
        }
    }
}