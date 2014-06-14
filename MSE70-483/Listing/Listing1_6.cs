using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing1_6 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nThis listing shows how to use local data in a thread and initialize it for each thread.", FriendlyName());

            new Thread(() =>
                {
                    for (int i = 0; i < _field.Value; i++)
                    {
                        Console.WriteLine("Thread A: {0}", i);
                    }
                }).Start();

            new Thread(() =>
            {
                for (int i = 0; i < _field.Value; i++)
                {
                    Console.WriteLine("Thread B: {0}", i);
                }
            }).Start();
        }

        public string FriendlyName()
        {
            return "Listing 1-6";
        }

        #endregion

        public static ThreadLocal<int> _field =
            new ThreadLocal<int>(() =>
                {
                    return Thread.CurrentThread.ManagedThreadId;
                });
    }
}
