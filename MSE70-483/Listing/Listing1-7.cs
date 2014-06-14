using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing1_7 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nThis listing showing how to use thread from threadpool.");
            ThreadPool.QueueUserWorkItem((s) =>
                {
                    Console.WriteLine("Working on a thread from thredpool.");
                });
        }

        public string FriendlyName()
        {
            return "Listing 1-7";
        }

        #endregion
    }
}
