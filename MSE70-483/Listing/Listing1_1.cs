using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing1_1 : IListing
    {
        #region IRunner Members

        public void Run()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Priority = ThreadPriority.Normal;
            t.Start();

            for (int i = 1; i < 4; i++)
            {
                Console.WriteLine("{0}. Main thread doing some work.", i);
                Thread.Sleep(1);
            }

            t.Join();

            Console.WriteLine("\n{0} done.", FriendlyName());
        }

        #endregion

        public static void ThreadMethod()
        {
            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine("Thread saying {0}.", i);
                Thread.Sleep(1);
            }
        }

        #region IListing Members


        public string FriendlyName()
        {
            return "Listing 1-1";
        }

        #endregion
    }
}
