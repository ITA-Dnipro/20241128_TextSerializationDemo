using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace _20241128_TextSerializationDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DemoXmlSerialization();

            DemoJsonSerialization();
        }

        public static void DemoJsonSerialization()
        {
            Person p = new Person(55) { Id = 0xFFFF, Name = "Dmytro", Age = 18.5 };

            DataContractJsonSerializer personSerializer = new DataContractJsonSerializer(typeof(Person));

            using (FileStream fsOut = new FileStream("person.json", FileMode.Create, FileAccess.Write))
            {
                personSerializer.WriteObject(fsOut, p);
            }

            using (FileStream fsIn = new FileStream("person.json", FileMode.Open, FileAccess.Read))
            {
                Person pCopy = (Person)personSerializer.ReadObject(fsIn);

                Console.WriteLine($"pCopy: {pCopy}");
            }

            DataContractJsonSerializer peopleSerializer = new DataContractJsonSerializer(typeof(List<Person>));

            List<Person> people = new List<Person>()
            {
                p,
                new Person(33) { Id = 255, Name = "Petro", Age = 28.5 }
            };

            using (FileStream fsOut = new FileStream("people.json", FileMode.Create, FileAccess.Write))
            {
                peopleSerializer.WriteObject(fsOut, people);
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("peopleCopy:");

            using (FileStream fsIn = new FileStream("people.json", FileMode.Open, FileAccess.Read))
            {
                List<Person> peopleCopy = (List<Person>)peopleSerializer.ReadObject(fsIn);
                for (int i = 0; i < peopleCopy.Count; i++)
                {
                    Console.WriteLine(peopleCopy[i]);
                }
            }
        }


        public static void DemoXmlSerialization()
        {
            Person p = new Person(55) { Id = 0xFFFF, Name = "Dmytro", Age = 18.5 };

            XmlSerializer personSerializer = new XmlSerializer(typeof(Person));

            using (FileStream fsOut = new FileStream("person.xml", FileMode.Create, FileAccess.Write))
            {
                personSerializer.Serialize(fsOut, p);
            }

            using (FileStream fsIn = new FileStream("person.xml", FileMode.Open, FileAccess.Read))
            {
                Person pCopy = (Person)personSerializer.Deserialize(fsIn);

                Console.WriteLine($"pCopy: {pCopy}");
            }

            XmlSerializer peopleSerializer = new XmlSerializer(typeof(List<Person>));


            List<Person> people = new List<Person>()
            {
                p,
                new Person(33) { Id = 255, Name = "Petro", Age = 28.5 }
            };

            using (FileStream fsOut = new FileStream("people.xml", FileMode.Create, FileAccess.Write))
            {
                peopleSerializer.Serialize(fsOut, people);
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("peopleCopy:");

            using (FileStream fsIn = new FileStream("people.xml", FileMode.Open, FileAccess.Read))
            {
                List<Person> peopleCopy = (List<Person>)peopleSerializer.Deserialize(fsIn);
                for (int i = 0; i < peopleCopy.Count; i++)
                {
                    Console.WriteLine(peopleCopy[i]);
                }
            }
        }
    }
}