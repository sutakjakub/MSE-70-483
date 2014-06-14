using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing1_2 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.IsBackground = true;
            t.Start();
            Console.WriteLine("{0}\nThis message was written first because actual thread was started on the 'background'.", FriendlyName());
        }

        public string FriendlyName()
        {
            return "Listing 1-2";
        }

        #endregion

        public static void ThreadMethod()
        {
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine("{0}. cycle of thread", i);
                Thread.Sleep(1000);
            }
        }
    }
}
