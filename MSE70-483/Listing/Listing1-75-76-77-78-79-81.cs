using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing1_75_76_77_78_79_81 : IListing
    {

        private delegate int Calculate(int x, int y);
        private delegate void Del();
        private delegate TextWriter CovarianceDel();
        private delegate void ContravarianceDel(StreamWriter sw);

        private StreamWriter MethodStream() { return null; }
        private StringWriter MethodString() { return null; }
        private void DoSomething(TextWriter text) { }

        private int Add(int x, int y) { return x + y; }
        private int Multiply(int x, int y) { return x * y; }


        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nHow to create and use delegate(multicasting[adding delegates with +=] too), Lambda Expressions, Covariance, Contravariance, Action.\n", FriendlyName());

            Console.WriteLine("{0}", Regex.Split(FriendlyName(), " and ")[0]);
            Calculate cal = Add;
            Console.WriteLine("Add: {0}", cal(3, 4));

            cal = Multiply;
            Console.WriteLine("Multiply: {0}", cal(3, 4));

            Console.WriteLine("\n{0}", Regex.Split(FriendlyName(), " and ")[1]);
            Del d = MethodOne;
            d += MethodTwo;
            d();


            Console.WriteLine("\n{0}", Regex.Split(FriendlyName(), " and ")[2]);
            //because StreamWrite and StringWriter inherite from TextWriter, we can use CovarianceDel with both methods
            //StreamWriter -> TextWriter (covariance)
            CovarianceDel cov;
            cov = MethodStream;
            cov = MethodString;

            Console.WriteLine("\n{0}", Regex.Split(FriendlyName(), " and ")[3]);
            //this is too possible; StreamWriter inherite from TextWrite so must have method from TextWriter
            //TextWriter -> StreamWriter (contravariance)
            ContravarianceDel cov2;
            cov2 = DoSomething;

            Console.WriteLine("\n{0}", Regex.Split(FriendlyName(), " and ")[4]);
            Calculate calLambdaEx = (x, y) => x + y;
            //this is same but other written
            calLambdaEx = (x, y) =>
            {
                Console.WriteLine("Add(LE): {0}", x + y);
                return x + y;
            };
            Console.WriteLine("Add(LE): {0}", calLambdaEx(3, 4));
            calLambdaEx = (x, y) => x * y;
            Console.WriteLine("Multiply(LE): {0}", calLambdaEx(3, 4));


            Console.WriteLine("\n{0}", Regex.Split(FriendlyName(), " and ")[5]);
            Action<int, int> calcAction = (x, y) =>
                {
                    Console.WriteLine("Action (add): {0}", x + y);
                };
            calcAction(3, 4);

            Console.WriteLine("\nDone.");
        }

        public void MethodOne()
        {
            Console.WriteLine("Method one.");
        }

        public void MethodTwo()
        {
            Console.WriteLine("Method two.");
        }

        public string FriendlyName()
        {
            return "Listing 1-75 and Listing 1-76 and Listing 1-77 and Listing 1-78 and Listing 1-79 and Listing 1-81";
        }

        #endregion
    }
}
