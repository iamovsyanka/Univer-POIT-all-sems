using System;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var collectionString = new CollectionType<string> { };
                collectionString.Add("YAP");
                collectionString.Add("OOP");
                collectionString.Add("Motesha");
                collectionString.Show();
                collectionString.RemoveAt(2);
                //collectionString.Insert(6, "KSiS");
                collectionString.Show();
                Console.WriteLine();

                var collectionAuthor = new CollectionType<Author> { };
                collectionAuthor.Add(new Author("Andrey","Kozlovski",10));
                collectionAuthor.Add(new Author("Vadim", "Minakov",7));
                collectionAuthor.Print();

                var collectionObj = new CollectionType<object> { };
                collectionObj.Add(12);
                collectionObj.Add(16);
                collectionObj.Add(18);
                collectionObj.Show();
                collectionObj.Insert(2, 20);
                collectionObj.Show();

            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("\n\nEnd.");
            }
        }
    }
}
