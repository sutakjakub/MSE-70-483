using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class SerializationDataContractXML
    {
        public void Do()
        {
            Person p = new Person() { id = 10, name="Jakub" , age = 20};

            using (Stream stream = new FileStream("file.xml", FileMode.Create))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(Person));
                ser.WriteObject(stream, p);
            }
            using (Stream stream = new FileStream("file.xml", FileMode.Open))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(Person));
                Person pBack = (Person)ser.ReadObject(stream);
                Console.WriteLine(pBack.id + " " + pBack.name + " " + pBack.age);
            }
        }
        [DataContract]
        private class Person
        {
            [DataMember]
            public int id { get; set; }

            [DataMember]
            public string name { get; set; }

            public int age { get; set; }
        }
    }
}
