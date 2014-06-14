using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing1_5 : IListing
    {

        [ThreadStatic]
        private static int _field;

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nNow we are using [ThreadStatic] attribute for field. It causes that each thread gets its own copy of marked field. It means that with [ThreadStatic] attribute we've got maximum 10 but without 20.\n", FriendlyName());
            
            DoIt();
        }

        public string FriendlyName()
        {
            return "Listing 1-5";
        }

        #endregion

        private static void DoIt()
        {
            new Thread(() =>
            {
                for (int x = 1; x < 11; x++)
                {
                    _field++;
                    Console.WriteLine("Thread {0}: {1}", Thread.CurrentThread.ManagedThreadId, _field);
                }
            }).Start();
            
            new Thread(() =>
            {
                for (int x = 1; x < 11; x++)
                {
                    _field++;
                    Console.WriteLine("Thread {0}: {1}", Thread.CurrentThread.ManagedThreadId, _field);
                }
            }).Start();
            
            
        }
    }
}
