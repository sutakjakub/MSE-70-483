using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing1_18 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nUsing async and await.\n", FriendlyName());
            string s = "http://microsoft.com/";
            string result = DownloadContent(s).Result;
            Console.WriteLine("Result of 'DownloadContent({1})' is: \n{0}\nDone.", result, s);
        }

        public string FriendlyName()
        {
            return "Listing 1-18";
        }

        #endregion

        private static async Task<string> DownloadContent(string s)
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync(s);
                return result;
            }
        }
    }
}
