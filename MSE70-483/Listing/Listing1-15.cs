using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing1_15 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nInstead of waiting until all tasks are finised, you can also wait until one of the tasks is finished.\n", FriendlyName());

            Task<int>[] tasks = new Task<int>[3];

            tasks[0] = Task.Run(() => { Thread.Sleep(1000); return 1; });
            tasks[1] = Task.Run(() => { Thread.Sleep(1000); return 2; });
            tasks[2] = Task.Run(() => { Thread.Sleep(1000); return 3; });

            while (tasks.Length > 0)
            {
                int i = Task.WaitAny(tasks);
                Task<int> completedTask = tasks[i];

                Console.WriteLine("Completed task result is {0}", completedTask.Result);

                var temp = tasks.ToList();
                temp.RemoveAt(i);
                tasks = temp.ToArray();
            }

            Console.WriteLine("\nDone.");
        }

        public string FriendlyName()
        {
            return "Listing 1-15";
        }

        #endregion
    }
}
