using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing3_27 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nInitializinf StringSecure.\n", FriendlyName());

            using (SecureString ss = new SecureString())
            {
                Console.WriteLine("Please write your password: ");
                while (true)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Enter) break;

                    ss.AppendChar(cki.KeyChar);
                    Console.Write("*");
                }
                ss.MakeReadOnly();
                Console.WriteLine("\n\nYour password was: {0}\nDone.", ConvertToUnsecureString(ss));
            }


        }

        public string FriendlyName()
        {
            return "Listing 3-27";
        }

        #endregion

        public static string ConvertToUnsecureString(SecureString securePassword)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
