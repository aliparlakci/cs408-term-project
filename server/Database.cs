using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace server
{
    public abstract class Database<T>
    {
        protected string filename = "database.txt";
        protected IEnumerable<T> items;

        public Database()
        {
            items = new List<T>();

            if (!File.Exists(filename))
            {
                File.Create(filename).Dispose();
            }

            ReadFile();
        }

        public bool Exists(Func<T, bool> comparator)
        {
            ReadFile();
            return items.Where(item => comparator(item)).ToArray().Length > 0;
        }

        public virtual void InsertItem(T item) { }

        protected virtual void ReadFile() { }
    }
}
