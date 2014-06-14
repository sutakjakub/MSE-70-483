using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing1_12 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nAttaching child tasks to a parent task.", FriendlyName());
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];
                new Task(() => results[0] = 0, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = 1, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = 2, TaskCreationOptions.AttachedToParent).Start();
                return results;
            });

            var finalTask = parent.ContinueWith(          //finalTask runs onl after the parent Task is finished
                parentTask => {
                    foreach (var item in parentTask.Result)
                    {
                        Console.WriteLine("{0}.", item);
                    }
                });

            finalTask.Wait();

            Console.WriteLine("{0} done.", FriendlyName());
        }

        public string FriendlyName()
        {
            return "Listing 1-12";
        }

        #endregion
    }
}
