using System;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            var author1 = new Author("Katy", "Kerez", 5);
            var author2 = new Author("Andrey", "Kozlovsky", 10);

            Console.WriteLine(author1.ToString());
            Console.Write("Псевдоним автора: ");
            Console.WriteLine(author1.CreateAlias());
            Console.WriteLine($"{author1.WritingExperience(45, 15)} жизни автор занимается писательством");
            Console.WriteLine();

            var book = new Book();
            book.YearOfPublications();
            book.GetGenre();
            book.GetTitle();
            book.NumberOfPublications();
            Console.WriteLine(book.ToString());
            Console.WriteLine();

            IPublishing publishing = book as IPublishing;
            if(book is IPublishing)
            {
                publishing.YearOfPublications();
                publishing.GetTitle();
                Console.WriteLine(Printer.IAmPrinnting(publishing));
            }
            
        }
    }
}
