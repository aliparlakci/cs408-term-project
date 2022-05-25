using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    public class FriendshipDatabase : Database<Friendship>
    {
        public FriendshipDatabase(string filename) : base(filename) { }

        public void AddFriendship(string username1, string username2)
        {
            var newFriendship = new Friendship { username1 = username1, username2 = username2 };
            if (base.Exists(friendship => friendship == newFriendship))
            {
                return;
            }
            base.InsertItem(newFriendship);
        }

        public bool Has(string username1, string username2)
        {
            return base.Exists(friendship => friendship == new Friendship { username1 = username1, username2 = username2 });
        }

        public void Remove(string username1, string username2)
        {
            base.RemoveItem(friendship => friendship == new Friendship { username1 = username1, username2 = username2 });
        }
    }
}
