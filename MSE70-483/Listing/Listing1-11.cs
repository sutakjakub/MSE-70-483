using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing1_11 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nScheduling different continuation task.\n", FriendlyName());

            Task<int> t = Task.Run(() =>
            {
                return 42;
            });

            t.ContinueWith((i) =>
                {
                    Console.WriteLine("Cancelled.");
                }, TaskContinuationOptions.OnlyOnCanceled);

            t.ContinueWith((i) => { Console.WriteLine("Faulted."); }, TaskContinuationOptions.OnlyOnFaulted);

            var completedTask = t.ContinueWith((i) => { Console.WriteLine("Completed"); }, TaskContinuationOptions.OnlyOnRanToCompletion);

            completedTask.Wait();

            Console.WriteLine("\nCompletedTask is {0}. Done.", t.Result);

        }

        public string FriendlyName()
        {
            return "Listing 1-11";
        }

        #endregion
    }
}

