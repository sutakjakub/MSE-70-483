using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing1_4 : IListing
    {
        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nIn this listing we are using loop while. This loop end when we press some key.  Thread will be aborted.\n", FriendlyName());

            bool stopped = false;
            Thread t = new Thread(new ThreadStart(() =>     //lambda expressions for shorthand version of a delegate 
            {
                while (!stopped)
                {
                    Console.WriteLine("Doing some work until you press some key. ");
                    Thread.Sleep(1000);
                }
            }));

            t.Start();
            Console.WriteLine("Press any key to exit.\n");
            Console.ReadKey();

            stopped = true;
            t.Join();

            Console.WriteLine("\nYou pressed some key. Thread was aborted.");
        }

        public string FriendlyName()
        {
            return "Listing 1-4";
        }

        #endregion
    }
}
