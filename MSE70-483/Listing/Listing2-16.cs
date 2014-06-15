using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing2_16 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nThis listing shows how to using Extension methods.", FriendlyName());

            Product p = new Product();
            p.Price = 100;
            var result = p.Discount(); //magic :)

            Console.WriteLine("\nResult is {0}. Done.", result);
        }

        public string FriendlyName()
        {
            return "Listing 2-16";
        }

        #endregion
    }

    internal class Product
    {
        public decimal Price { get; set; }
    }

    internal static class MyExtension
    {
        public static decimal Discount(this Product product)
        {
            return product.Price * .9M;
        }
    }


}
