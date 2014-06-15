using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class Listing2_10 : IListing
    {

        #region IListing Members

        public void Run()
        {
            Console.WriteLine("{0}\nCreating collection. Nice declared method.\n", FriendlyName());

            Deck deck = new Deck();
            foreach (var item in deck.Cards)
            {
                Console.WriteLine("{0} {1}", item.Name, item.Color);
            }

            Console.WriteLine("\nCard's name on second position is {0}.", deck[1].Name);

            Console.WriteLine("\nDone.");
        }

        public string FriendlyName()
        {
            return "Listing 2-10";
        }

        #endregion
    }

    internal class Deck
    {

        public Deck()
        {
            InitialCards();
        }


        public ICollection<Card> Cards { get; private set; }

        public Card this[int index]
        {
            get { return Cards.ElementAt(index); }
        }

        private void InitialCards()
        {
            Cards = new List<Card>();
            Cards.Add(new Card() { Name = "King", Color = "Hearts"});
            Cards.Add(new Card() { Name = "Queen", Color = "Hearts"});
        }
    }

    internal class Card
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
