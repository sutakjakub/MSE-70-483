using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing_1_82_83_84_85_86 : IListing
    {
        public delegate void OnChangeDelegate();
        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nThis listing showing how to create and use event in C#.\n", FriendlyName());

            Console.WriteLine("{0}", Regex.Split(FriendlyName(), " and ")[0]);
            Pub p = new Pub();
            p.OnChange += () => Console.WriteLine("Event raised to method 1.");
            p.OnChange += () => Console.WriteLine("Event raised to method 2.");
            p.Raise();

            Console.WriteLine("\n{0}", Regex.Split(FriendlyName(), " and ")[1]);
            PubEventSyntax pes = new PubEventSyntax();
            pes.OnChange += () => Console.WriteLine("Event raised (PES).");
            pes.Raise();

            Console.WriteLine("\n{0}", Regex.Split(FriendlyName(), " and ")[2]);
            PubEvArgs pea = new PubEvArgs();
            pea.OnChange += (sender, e) => { Console.WriteLine("Event raised: {0}", e.Value); };
            pea.Raise(new MyArgs(55));

            Console.WriteLine("\n{0}", Regex.Split(FriendlyName(), " and ")[3]);
            PubCustomAccessors pCustomAcc = new PubCustomAccessors();
            pCustomAcc.OnChange += (sender, e) => { Console.WriteLine("Event raised: {0}", e.Value); };
            pCustomAcc.Raise(new MyArgs(32));

            Console.WriteLine("\n{0}", Regex.Split(FriendlyName(), " and ")[4]);
            PubExcHandling peh = new PubExcHandling();

            peh.OnChanged += (sender, e) => Console.WriteLine("Subscriber 1 called.");
            peh.OnChanged += (sender, e) => { throw new Exception(); };
            peh.OnChanged += (sender, e) =>  Console.WriteLine("Subscriber 3 called.");

            try
            {
                peh.Raise();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.InnerExceptions.Count);
            }

            Console.WriteLine("\nDone.");

        }

        public string FriendlyName()
        {
            return "Listing 1-82 and Listing 1-83 and Listing 1-84 and Listing 1-85 and Listing 1-86";
        }

        #endregion

    }

    public class Pub
    {
        public Action OnChange { get; set; }
        public void Raise()
        {
            if (OnChange != null)
            {
                OnChange();
            }
        }
    }

    public class PubEventSyntax
    {
        public event Action OnChange = delegate { };

        public void Raise()
        {
            OnChange();
        }
    }

    public class MyArgs : EventArgs
    {
        public int Value { get; set; }
        public MyArgs(int value)
        {
            Value = value;
        }
    }
    public class PubEvArgs
    {
        public event EventHandler<MyArgs> OnChange = delegate { };

        public void Raise(MyArgs args)
        {
            OnChange(this, args);
        }
    }

    public class PubCustomAccessors
    {
        private event EventHandler<MyArgs> onChange = delegate { };
        public event EventHandler<MyArgs> OnChange
        {
            add
            {
                lock (onChange)
                {
                    onChange += value;
                }
            }

            remove
            {
                lock (onChange)
                {
                    onChange -= value;
                }
            }
        }

        public void Raise(MyArgs args)
        {
            onChange(this, args);
        }
    }

    public class PubExcHandling
    {
        public event EventHandler<EventArgs> OnChanged = delegate { };
        public void Raise()
        {
            var exceptions = new List<Exception>();
            foreach (Delegate handler in OnChanged.GetInvocationList())
            {
                try
                {
                    handler.DynamicInvoke(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }
    }


}
