using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing1_28 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nUsing BlockingCollection<T>", FriendlyName());

            BlockingCollection<string> col = new BlockingCollection<string>();
            Task read = Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine(col.Take());
                }
            });

            Task write = Task.Run(() =>
                {
                    while (true)
                    {
                        string s = Console.ReadLine();
                        if (string.IsNullOrEmpty(s)) break;
                        col.Add(s);
                    }

                });

            write.Wait();

            Console.WriteLine("Done.");
        }

        public string FriendlyName()
        {
            return "Listing 1-28";
        }

        #endregion
    }
}
