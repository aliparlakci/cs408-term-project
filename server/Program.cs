using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            var usersDb = new UserDatabase();
            var postsDb = new PostsDatabase();
            var logger = new Logger();
            var server = new Server(usersDb, postsDb, logger);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ServerForm(server, logger));

        }
    }
}