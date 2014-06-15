using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing2_18 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nThis listing shows how to using sealed keyword.", FriendlyName());


        }

        public string FriendlyName()
        {
            return "Listing 2-18";
        }

        #endregion
    }

    internal class Base
    {
        public virtual int MyMethod()
        {
            return 42;
        }
    }
    internal class Derived : Base
    {
        public sealed override int MyMethod()
        {
            return base.MyMethod() * 2;
        }
    }

    internal class Derived2 : Derived
    {
        //this line would give a compile error
        //public override int MyMethod() { return 1; }
    }
}
