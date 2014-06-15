using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing2_39 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nThis listing shows how to implement explicit interface.", FriendlyName());

            MoveableObject obj = new MoveableObject();
            ((ILeft)obj).Move();   //nice :-)

            Console.WriteLine("\nDone.");

        }

        public string FriendlyName()
        {
            return "Listing 2-39";
        }

        #endregion
    }

    interface ILeft
    {
        void Move();
    }

    interface IRight
    {
        void Move();
    }

    public class MoveableObject : ILeft, IRight
    {
        void ILeft.Move() { Console.WriteLine("turning left."); }
        void IRight.Move() {  }
    }
}
