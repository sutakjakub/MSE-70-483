using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing3_23 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nShows an example of using the SHA256Managed algorithm to calculate the hash code for a piece of text.\n", FriendlyName());

            UnicodeEncoding byteConverter = new UnicodeEncoding();
            SHA256 sha = SHA256.Create();
            string data = "A paragrapg of a text!";
            byte[] hashA = sha.ComputeHash(byteConverter.GetBytes(data));

            data = "Changed text!";
            byte[] hashB = sha.ComputeHash(byteConverter.GetBytes(data));

            data = "A paragrapg of a text!";
            byte[] hashC = sha.ComputeHash(byteConverter.GetBytes(data));

            Console.WriteLine(hashA.SequenceEqual(hashB));
            Console.WriteLine(hashA.SequenceEqual(hashC));

            Console.WriteLine("Done.");
        }

        public string FriendlyName()
        {
            return "Listing 3-23";
        }

        #endregion


    }
}
