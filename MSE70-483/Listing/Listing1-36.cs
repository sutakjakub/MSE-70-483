using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing1_36 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\n", FriendlyName());

            int n = 0;
            object _lock = new object();

            var up = Task.Run(() =>
                {
                    for (int i = 0; i < 1000000; i++)
                    {
                        lock (_lock)
                        {
                            n++;
                        }
                    }
                });

            for (int i = 0; i < 1000000; i++)
            {
                lock (_lock)
                        {
                            n--;
                        }
            }

            up.Wait();

            Console.WriteLine("\nVariable 'n' is {0}. Done.", n);
        }

        public string FriendlyName()
        {
            return "Listing 1-36";
        }

        #endregion
    }
}
