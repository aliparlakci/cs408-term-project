using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    public class Friendship
    {
        public string username1;
        public string username2;

        public static bool operator ==(Friendship lhs, Friendship rhs)
        {
            return lhs.GetHashCode() == rhs.GetHashCode();
        }

        public static bool operator !=(Friendship lhs, Friendship rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            var former = username1.CompareTo(username2) > 0 ? username1 : username2;
            var latter = username1.CompareTo(username2) <= 0 ? username1 : username2;

            var tuple = new Tuple<string,string>(former, latter);
            return tuple.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj.GetHashCode() == GetHashCode();
        }
    }
}
