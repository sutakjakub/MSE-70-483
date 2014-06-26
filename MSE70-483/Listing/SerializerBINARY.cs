using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class SerializerBINARY
    {

        public void Do()
        {
            Person p = new Person() { FirstName = "Peter", LastName = "DontKnow"};
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream("file.bin", FileMode.Create))
            {
                formatter.Serialize(stream, p);
            }
            using (Stream stream = new FileStream("file.bin", FileMode.Open))
            {
                Person pBack = (Person)formatter.Deserialize(stream);
                Console.WriteLine(pBack.FirstName + " " + pBack.LastName);
            }
        }
        [Serializable]
        private class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

    }

    
}
