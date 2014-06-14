using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing1_37 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nExample of deadlock.\n", FriendlyName());

            object lockA = new object();
            object lockB = new object();

            var up = Task.Run(() =>
            {
                lock (lockA)
                {
                    Thread.Sleep(1000);
                    lock(lockB)
                    {
                        Console.WriteLine("Locked A and B");
                    }
                }
            });

            lock (lockB)
            {
                lock (lockA)
                {
                    Console.WriteLine("Locked B and A");
                }
            }

            up.Wait();
            Console.WriteLine("\nThis show how to create deadlock :-). Done.");

        }

        public string FriendlyName()
        {
            return "Listing 1-37";
        }

        #endregion
    }
}
