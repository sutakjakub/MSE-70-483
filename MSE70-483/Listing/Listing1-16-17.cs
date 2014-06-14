using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing1_16_17 : IListing
    {
        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nUsing ForEach, For, ParallelLoopResult from Parallel class.\n", FriendlyName());

            DoFirst();
            DoSecond();
            Console.WriteLine("Done.");
        }

        public string FriendlyName()
        {
            return "Listing 1-16 and Listing 1-17";
        }

        #endregion

        private void DoFirst()
        {
            Console.WriteLine("Running {0}", Regex.Split(FriendlyName(), " and ")[0]);
            Parallel.For(0, 10, i => { Thread.Sleep(1000); Console.WriteLine("{0}. waiting in Parallel.For.", i); });
            
            var numbers = Enumerable.Range(0, 10);
            Parallel.ForEach(numbers, i => { Thread.Sleep(1000); Console.WriteLine("{0}. waiting in Parallel.ForEach.", i); });
        }

        private void DoSecond()
        {
            Console.WriteLine("\nRunning {0}", Regex.Split(FriendlyName(), " and ")[1]);
            ParallelLoopResult result = Parallel.For(0, 1000, (int i, ParallelLoopState loopState) =>
                {
                    if (i == 500)
                    {
                        Console.WriteLine("Some incident (i==500). Breaking 'Parallel.For'.");
                        loopState.Break();
                    }
                    return;
                } 
            );
        }
    }
}
