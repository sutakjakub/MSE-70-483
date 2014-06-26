using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace MSE70_483.Listing
{
    public class SerializationDataContractJSON
    {
        public void Do()
        {
            Person p = new Person() { id = 1, name = "peter" };
            using (MemoryStream stream = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Person));
                ser.WriteObject(stream, p);

                stream.Position = 0;
                StreamReader reader = new StreamReader(stream);
                Console.WriteLine(reader.ReadToEnd());

                stream.Position = 0;
                Person pBack = (Person)ser.ReadObject(stream);
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
