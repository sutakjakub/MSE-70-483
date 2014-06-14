using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing1_27 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nHow can catching and AggregateException? This exception should be thrown while Parallel executing.\n", FriendlyName());

            var numbers = Enumerable.Range(0,20);
            try
            {
                var parallelResult = numbers.AsParallel().Where(i => IsEven(i));
                parallelResult.ForAll(e=>Console.WriteLine(e));
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("There where {0} exceptions.", ex.InnerExceptions.Count);
            }

            Console.WriteLine("\nDone.");
        }

        public string FriendlyName()
        {
            return "Listing 1-27";
        }

        #endregion
        private bool IsEven(int i)
        {
            if (i % 10 == 0)
            {
                throw new ArgumentException("i");
            }

            return i % 2 == 0;
        }
    }
}
