using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace server
{
    public abstract class Database<T> : IDisposable
    {
        protected string _filename;
        protected List<T> items;

        public Database(string filename)
        {
            _filename = filename;

            items = new List<T>();

            if (!File.Exists(filename))
            {
                File.Create(filename).Dispose();
            }

            ReadFile();
        }

        protected virtual void WriteToFile()
        {
            var lines = items.Select(item => JsonConvert.SerializeObject(item));
            File.WriteAllLines(_filename, lines);
        }

        public bool Exists(Func<T, bool> comparator)
        {
            return items.Where(item => comparator(item)).ToArray().Length > 0;
        }

        protected void InsertItem(T item)
        {
            items.Add(item);
            WriteToFile();
        }

        protected virtual void ReadFile()
        {
            items = File.ReadAllLines(_filename).Select(line =>
            {
                return JsonConvert.DeserializeObject<T>(line);
            }).ToList();
        }

        public void Dispose()
        {
            WriteToFile();
        }
    }
}
