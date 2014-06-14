using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing1_8 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nThis listing shows how to create Task and how to wait until it's finished.", FriendlyName());

            Task t = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.Write('*');
                }
            });

            t.Wait(); //his is equivalent for Thread.Join()

            Console.WriteLine("\nAll '*' was written. Done.");

        }

        public string FriendlyName()
        {
            return "Listing 1-8";
        }

        #endregion
    }
}
