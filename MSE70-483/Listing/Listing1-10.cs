using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing1_10 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nIf you want another operation to execute as soon as the Task finishes you can use continuation task.", FriendlyName());

            Task<int> t = Task.Run(() =>
            {
                return 42;
            }).ContinueWith((i) =>
            {
                return i.Result * 2;
            });

            Console.WriteLine("\nContinuation task returned {0}. Done.", t.Result);

        }

        public string FriendlyName()
        {
            return "Listing 1-10";
        }

        #endregion
    }
}

