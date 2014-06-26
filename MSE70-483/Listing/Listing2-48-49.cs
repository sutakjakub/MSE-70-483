using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing2_48_49 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nThis listing show how to using virtual keyword.\n", FriendlyName());

            Console.WriteLine(" {0}", Regex.Split(FriendlyName(), " and ")[0]);
            A a = new A();
            a.Execute();
            
            B b = new B();
            b.Execute();

            Console.WriteLine("\n{0}", Regex.Split(FriendlyName(), " and ")[1]);
            C c = new C();
            c.Execute();

            Console.WriteLine("\nDone.");
        }

        public string FriendlyName()
        {
            return "Listing 2-48 and Listing 2-49";
        }

        #endregion


    }

    internal class A
    {
        public virtual void Execute()
        {
            Console.WriteLine("A.Execute() called.");
        }
    }

    internal class B: A
    {
        public override void Execute()
        {
            base.Execute();
        }
    }

    internal class C : A
    {
        public new void Execute() { Console.WriteLine("C.Execute called."); }
    }
}
