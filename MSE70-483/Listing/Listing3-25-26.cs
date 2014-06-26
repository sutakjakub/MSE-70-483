using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing3_25_26 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nYou can specify CAS in two ways: declarative or imperative. Declarative means that you use attributes to apply security information to your code. Listing 3-25 shows an example of asking for the permission to read all local files by using the FileIOPermissionAttribute.\n\nYou can also do this in an imperative way, which means that you explicitly ask for the per- mission in the code. Listing 3-26 shows how you can create a new instance of FileIOPermission and demand certain rights.\n\n", FriendlyName());

            DeclarativeCAS();
            ImperativeCAS();

            Console.WriteLine("Done.");
        }

        public string FriendlyName()
        {
            return "Listing 3-25 and Listing 3-26";
        }

        #endregion

        [FileIOPermission(SecurityAction.Demand, AllLocalFiles = FileIOPermissionAccess.Read)]
        public void DeclarativeCAS()
        {
            
        }

        public void ImperativeCAS()
        {
            FileIOPermission f = new FileIOPermission(PermissionState.None);
            f.AllLocalFiles = FileIOPermissionAccess.Read;
            try
            {
                f.Demand();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
