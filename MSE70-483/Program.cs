using MSE70_483.Listing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSE70_483
{
    class Program
    {
        static void Main(string[] args)
        {
            IListing runner = new Listing_1_82_83_84_85_86();
            runner.Run();

            Console.ReadLine();
        }
    }

}
