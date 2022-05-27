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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ServerForm(server, logger));

            //var friendshipDb = new FriendshipDatabase("friendships.txt");
            //friendshipDb.AddFriendship("ali", "serra");
            //friendshipDb.AddFriendship("serra", "ali");
            //friendshipDb.AddFriendship("atakan", "ali");

            //var q1 = friendshipDb.Has("ali", "atakan");
            //var q2 = friendshipDb.Has("ali", "serra");

            //friendshipDb.Remove("serra", "ali");

            //var q3 = friendshipDb.Has("serra", "ali");

            //var friends = friendshipDb.GetFriendsOf("ali");

            return;
        }
    }
}