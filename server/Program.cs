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
            var usersDb = new UsersDatabase("user-db.txt");
            var postsDb = new PostsDatabase("posts.txt");
            var logger = new Logger();
            var server = new Server(usersDb, postsDb, logger);

            postsDb.InsertPost(new Post(0, "suada", "Kimin postu buu", DateTime.Now));
            postsDb.InsertPost(new Post(0, "suada", "Bu benim postum", DateTime.Now));
            postsDb.InsertPost(new Post(0, "mark", "Deneme", DateTime.Now));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ServerForm(server, logger));

            //var serialized = JsonConvert.SerializeObject(new Post[] { a1, a2, a3 }); // server
            //var a4 = JsonConvert.DeserializeObject<Post[]>(serialized); // client

            return;
        }
    }
}