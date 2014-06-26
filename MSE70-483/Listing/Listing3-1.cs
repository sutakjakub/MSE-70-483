using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing3_1 : IListing
    {
        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\n This listing showing how to using validation of data.", FriendlyName());
        }

        public string FriendlyName()
        {
            return "Listing 3-1";
        }

        #endregion
    }

    public class ShopContext : DbContext
    {
        public IDbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity(Customer)
        }
    }

    public class Customer
    {
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        public Address BillingAddress { get; set; }
    }

    public class Address
    {
        public string AddressLine { get; set; }
        public string City { get; set; }
    }

}
