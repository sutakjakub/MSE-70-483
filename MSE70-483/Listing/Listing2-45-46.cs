using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing2_45_46 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nThis listing shows how pretty we can use interface and classes.\n", FriendlyName());

            List<Order> orders = new List<Order>();
            orders.Add(new Order { Id = 1, Amount = 10 });
            orders.Add(new Order { Id = 2, Amount = 20 });
            orders.Add(new Order { Id = 3, Amount = 87 });

            RepositoryOrder repOrder = new RepositoryOrder(orders);
            var result = repOrder.FilterOrdersOnAmount(87);
            foreach (var item in result)
            {
                Console.WriteLine("Id:{0}  Amount:{1}", item.Id, item.Amount);
            }

            Console.WriteLine("\nDone.");
        }

        public string FriendlyName()
        {
            return "Listing 2-45 and Listing 2-46";
        }

        #endregion
    }

    interface IEntity
    {
        int Id { get; set; }
    }

    internal class Repository<T> where T : IEntity
    {
        protected IEnumerable<T> _elements;

        public Repository(IEnumerable<T> elements)
        {
            _elements = elements;
        }

        public T FindById(int id)
        {
            return _elements.SingleOrDefault(e => e.Id == id);
        }
    }

    internal class RepositoryOrder : Repository<Order>
    {
        private IEnumerable<Order> _orders;

        public RepositoryOrder(IEnumerable<Order> orders)
            : base(orders)      //this code pass orders to constructor of Repository<T> class
        {
            _orders = orders;
        }

        public IEnumerable<Order> FilterOrdersOnAmount(decimal amount)
        {
            List<Order> orders = new List<Order>();
            orders = _orders.Where(val => val.Amount == amount).ToList();
            return orders;
        }
    }

    internal class Order : IEntity
    {
        public int Amount { get; set; }

        #region IEntity Members

        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        #endregion
    }
}
