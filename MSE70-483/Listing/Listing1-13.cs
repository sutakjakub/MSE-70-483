using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing1_13 : IListing
    {
        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nHow to make Listing 1-12 easier? Using TaskFactory. ", FriendlyName());

            Task<Int32[]> parent = Task.Run(() =>
                {
                    var results = new Int32[3];

                    TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);

                    tf.StartNew(() => results[0] = 0);
                    tf.StartNew(() => results[1] = 1);
                    tf.StartNew(() => results[2] = 2);
                    return results;
                });

            var finalTask = parent.ContinueWith(          //finalTask runs onl after the parent Task is finished
                parentTask =>
                {
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
            return "Listing 1-13";
        }

        #endregion
    }
}
