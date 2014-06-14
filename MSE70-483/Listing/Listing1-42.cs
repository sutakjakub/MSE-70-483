using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing1_42 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nUsing CancellationToken.", FriendlyName());

            CancellationTokenSource canTokenSource = new CancellationTokenSource();
            CancellationToken token = canTokenSource.Token;

            Task task = Task.Run(() => 
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write('*');
                    Thread.Sleep(1000);
                }
            }, token);


            Console.WriteLine("Press enter to stop the task.");

            Console.ReadLine();
            canTokenSource.Cancel();

            Console.WriteLine("Done.");

        }

        public string FriendlyName()
        {
            return "Listing 1-42";
        }

        #endregion
    }
}
