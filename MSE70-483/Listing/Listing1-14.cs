using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing1_14 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nYou have 3 tasks. Every task has 1000ms duration. If you using WaitAll method you will wait only 1000ms instead of 3000ms.\n", FriendlyName());

            Stopwatch sw = new Stopwatch();
            Task[] tasks = new Task[3];
            sw.Start();
            tasks[0] = Task.Run(() => { Thread.Sleep(1000); Console.WriteLine("1. task completed."); return 1; });
            tasks[1] = Task.Run(() => { Thread.Sleep(1000); Console.WriteLine("2. task completed."); return 2; });
            tasks[2] = Task.Run(() => { Thread.Sleep(1000); Console.WriteLine("3. task completed."); return 3; });

            Task.WaitAll(tasks);
            sw.Stop();

            Console.WriteLine("\nDuration of executed these task was {0}ms", sw.ElapsedMilliseconds);
        }

        public string FriendlyName()
        {
            return "Listing 1-14";
        }

        #endregion
    }
}
