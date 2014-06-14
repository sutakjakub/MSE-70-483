using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing1_9 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nThis listing shows how to create Task and how to return some value after executed work.", FriendlyName());

            Task<int> t = Task.Run(() =>
            {
                return 42;
            });

            Console.WriteLine("\nTask returned {0}. Done.", t.Result);

        }

        public string FriendlyName()
        {
            return "Listing 1-9";
        }

        #endregion
    }
}

