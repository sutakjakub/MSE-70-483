using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MSE70_483.Listing
{

    public class SerializerXML
    {
        public void Do()
        {
            XmlSerializer ser = new XmlSerializer(typeof(Person));
            Person p = new Person() { FirstName = "Jakub", LastName = "Novotny" };

            string xml;
            using (StreamWriter writer = new StreamWriter())
            {
                ser.Serialize(writer, p);
                xml = writer.ToString();
            }

            Console.WriteLine(xml);

            using (StringReader reader = new StringReader(xml))
            {
                Person pBack = (Person)ser.Deserialize(reader);
                Console.WriteLine(pBack.FirstName + " " + pBack.LastName);
            }


        }

    }
    [Serializable]
    private class Person
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
