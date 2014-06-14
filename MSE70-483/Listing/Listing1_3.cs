using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing1_3 : IListing
    {
        #region IListing Members

        public void Run()
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.Start(6);
            t.Join();

            Console.WriteLine("\n{0}\nNow we used 'ParameterizedThreadStart'.", FriendlyName());
        }

        public string FriendlyName()
        {
            return "Listing 1-3";
        }

        #endregion

        public static void ThreadMethod(object o)
        {
            for (int i = 1; i < (int)o; i++)
            {
                Console.WriteLine("{0}. cycle of thread", i);
                Thread.Sleep(1);
            }
        }
    }
}
