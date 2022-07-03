using System;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml.Linq;

namespace Lab14
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1
            var author = new Author("Andrey", "Kozel", 54);

            var binaryFormatter = new BinaryFormatter();
            using (var stream = new FileStream("14.bin", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(stream, author);
            }

            using (var stream = new FileStream("14.bin", FileMode.Open))
            {
                var newAuthor = (Author)binaryFormatter.Deserialize(stream);
                Console.WriteLine("Binary:\n " + newAuthor.ToString());
            }
            Console.WriteLine();

            var soapFormatter = new SoapFormatter();
            using (var stream = new FileStream("14.soap", FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(stream, author);
            }

            using (var stream = new FileStream("14.soap", FileMode.Open))
            {
                var newAuthor = (Author)soapFormatter.Deserialize(stream);
                Console.WriteLine("Soap:\n " + newAuthor.ToString());
            }
            Console.WriteLine();

            var jsonSerializer = new DataContractJsonSerializer(typeof(Author));
            using (var stream = new FileStream("14.json", FileMode.OpenOrCreate))
            {
                jsonSerializer.WriteObject(stream, author);
            }

            using (var stream = new FileStream("14.json", FileMode.Open))
            {
                var newAuthor = (Author)jsonSerializer.ReadObject(stream);
                Console.WriteLine("Json:\n " + newAuthor.ToString());
            }
            Console.WriteLine();

            var xmlSerializer = new XmlSerializer(typeof(Author));
            using (var stream = new FileStream("14.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(stream, author);
            }

            using (var stream = new FileStream("14.xml", FileMode.Open))
            {
                var newAuthor = (Author)xmlSerializer.Deserialize(stream);
                Console.WriteLine("XML:\n " + newAuthor.ToString());
            }
            Console.WriteLine();
            #endregion

            #region 2
            var authors = new Author[] { new Author("Николас", "Спаркс", 18), new Author("Шарлотта","Бронте", 7) };
            
            var binFormatter = new BinaryFormatter();
            using (var stream = new FileStream("14s.bin", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(stream, authors);
            }

            using (var stream = new FileStream("14s.bin", FileMode.Open))
            {
                var newAuthors = (Author[])binFormatter.Deserialize(stream);
                Console.WriteLine("Bin:");
                foreach (var a in newAuthors)
                {
                    Console.WriteLine("\tName: " + a.Name);
                }
            }

            var sFormatter = new SoapFormatter();
            using (var stream = new FileStream("14s.soap", FileMode.OpenOrCreate))
            {
                sFormatter.Serialize(stream, authors);
            }

            using (var stream = new FileStream("14s.soap", FileMode.Open))
            {
                var newAuthors = (Author[])sFormatter.Deserialize(stream);
                Console.WriteLine("Soap: ");
                foreach (var a in newAuthors)
                {
                    Console.WriteLine("\tName: " + a.Name);
                }
            }
            Console.WriteLine();

            var jSerializer = new DataContractJsonSerializer(typeof(Author[]));
            using (var stream = new FileStream("14s.json", FileMode.OpenOrCreate))
            {
                jSerializer.WriteObject(stream, authors);
            }

            using (var stream = new FileStream("14s.json", FileMode.Open))
            {
                var newAuthors = (Author[])jSerializer.ReadObject(stream);
                Console.WriteLine("Json:");
                foreach (Author a in newAuthors)
                {
                    Console.WriteLine("\tName: " + a.Name);
                }
            }
            Console.WriteLine();

            var serializer = new XmlSerializer(typeof(Author[]));
            using (var stream = new FileStream("14s.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, authors);
            }

            using (var stream = new FileStream("14s.xml", FileMode.Open))
            {
                var newAuthors = (Author[])serializer.Deserialize(stream);
                Console.WriteLine("XML: ");
                foreach (var a in newAuthors)
                {
                    Console.WriteLine("\tName: " + a.Name);
                }
            }
            Console.WriteLine();
            #endregion

            #region 3
            var xmlDocument = new XmlDocument();
            xmlDocument.Load("14s.xml");
            var xmlRoot = xmlDocument.DocumentElement;
            var childnode = xmlRoot.SelectSingleNode("Author[Name='Николас']");
            if (childnode != null)
            {
                Console.WriteLine(childnode.OuterXml);
            }
            Console.WriteLine();
            var childnodes = xmlRoot.SelectNodes("*");
            foreach (XmlNode node in childnodes)
            {
                Console.WriteLine(node.OuterXml);
            }
            #endregion

            #region 4
            Console.WriteLine();
            var xdoc = new XDocument();
            var plant = new XElement("Plant");
            var cyrress = new XElement("myPlant");
            var rose = new XElement("myPlant");

            var cyrressAttribute1 = new XAttribute("name","cyrress");
            var roseAttribute1 = new XAttribute("name", "rose");
            var cyrressAttribute2 = new XAttribute("size", "medium");
            var roseAttribute2 = new XAttribute("size", "small");

            cyrress.Add(cyrressAttribute1);
            cyrress.Add(cyrressAttribute2);
            rose.Add(roseAttribute1);
            rose.Add(roseAttribute2);
                        
            plant.Add(cyrress);
            plant.Add(rose);

            xdoc.Add(plant);
            xdoc.Save("plant.xml");

            var linq = from x in xdoc.Element("Plant").Elements("myPlant")
                       select x;
            foreach (var i in linq)
            {
                Console.WriteLine(i.ToString());
            }
            #endregion
        }
    }
}
