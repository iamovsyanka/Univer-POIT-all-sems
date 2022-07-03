using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CountPublications { get; set; }
        public abstract float WritingExperience(int x, int y);
        public abstract string CreateAlias();
        public abstract override string ToString();
    }
    public class Author : Person
    {
        public Author() { }
        public Author(string _name, string _surname, int _countPublications)
        {
            Name = _name;
            Surname = _surname;
            CountPublications = _countPublications;
        }
        public override float WritingExperience(int year, int yearOfWriting)
        {
            return (float)yearOfWriting / year;
        }
        public override string CreateAlias()
        {
            return Name.ToUpper() + Surname.Substring(0, 2);
        }
        public override string ToString()
        {
            return $"Тип объекта: {GetType()}, фамилия и имя автора - {Surname} {Name}, количество книг - {CountPublications}";
        }
    }
    public class Publishing : Author
    {
        private List<Author> authors;
        private int Count => authors.Count;

        public Publishing() => authors = new List<Author> { };

        public void Add(Author author) => authors.Add(author);

        public void RemoveAt(int index)
        {
            if (index > authors.Count || index < 0)
            {
                Console.WriteLine("");
            }
            authors.RemoveAt(index);
        }

        public void Clear() => authors.Clear();

        public Author this[int index]
        {
            get
            {
                if (index > authors.Count || index < 0)
                {
                    Console.WriteLine("");
                }

                return authors[index];
            }
            set
            {
                if (index > authors.Count || index < 0)
                {
                    Console.WriteLine("");
                }
                authors[index] = value;
            }
        }

        public override string ToString() => $"Количество авторов, печатающихcя в издательстве, {authors.Count}";

        public void Search(string alias)
        {
            for (int i = 0; i < Count; i++)
            {
                if (authors[i].CreateAlias() == alias)
                {
                    Console.WriteLine("Это автор есть в базе");
                }
                else
                {
                    Console.WriteLine("Автора в базе нет");
                }
            }
        }

    }

    public interface IPublishing
    {
        string Title { get; set; }
        string Genre { get; set; }
        int NumberOfPublicat { get; set; }
        int Year { get; set; }
        void GetTitle();
        void GetGenre();
        void NumberOfPublications();
        void YearOfPublications();
        string ToString();
    }

    public struct Book : IPublishing
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int NumberOfPublicat { get; set; }
        public int Year { get; set; }

        public void GetTitle()
        {
            Console.WriteLine("Введите название книги: ");
            Title = Console.ReadLine();
            if(Title == "")
            {
                throw new ArgumentException("Название книги должно быть задано");
            }
        }

        public void GetGenre()
        {
            Console.WriteLine("Выбирете жанр: \n1-Научный\n2-Фантастика\n3-Драма\n4-Классика");
            var choice = Convert.ToInt16(Console.ReadLine());

            if (choice > 4 || choice < 1)
            {
                throw new ArgumentOutOfRangeException("Out of range");
            }
            else
            {
                switch (choice)
                {
                    case 1:
                        Genre = "Научный";
                        break;
                    case 2:
                        Genre = "Фантастика";
                        break;
                    case 3:
                        Genre = "Драма";
                        break;
                    case 4:
                        Genre = "Классика";
                        break;
                }
            }
        }

        public void NumberOfPublications()
        {
            Console.WriteLine("Введите количество изданий:");
            NumberOfPublicat = Convert.ToInt16(Console.ReadLine());
            if(NumberOfPublicat<10)
            {
                throw new ArgumentException("Количество публикаций должно превышать 10");
            }
        }

        public void YearOfPublications()
        {
            Console.WriteLine("Введите год выпуска:");
            Year = Convert.ToInt16(Console.ReadLine());
        }

        public override string ToString() => $"Тип объекта: {GetType()}, название книги - {Title}, жанр - {Genre}, количество публикаций - {NumberOfPublicat}, год выпуска - {Year}";
        
        public void Create()
        {
            GetGenre();
            GetTitle();
            NumberOfPublications();
            YearOfPublications();
        }
    }

    public struct Magazine : IPublishing
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int NumberOfPublicat { get; set; }
        public int Year { get; set; }
        public void GetTitle()
        {
            Console.WriteLine("Введите название журнала: ");
            Title = Console.ReadLine();
        }
        public void GetGenre()
        {
            Console.WriteLine("Выбирете жанр: \n1-Научный\n2-Комиксы\n3-Женский\n4-Детский");
            var choice = Convert.ToInt16(Console.ReadLine());

            if (choice > 4 || choice < 1)
            {
                throw new Exception("Out of range");
            }
            else
            {
                switch (choice)
                {
                    case 1:
                        Genre = "Научный";
                        break;
                    case 2:
                        Genre = "Комиксы";
                        break;
                    case 3:
                        Genre = "Женский";
                        break;
                    case 4:
                        Genre = "Детский";
                        break;
                }
            }
        }

        public void NumberOfPublications()
        {
            Console.WriteLine("Введите количество изданий:");
            NumberOfPublicat = Convert.ToInt16(Console.ReadLine());
        }

        public void YearOfPublications()
        {
            Console.WriteLine("Введите год выпуска");
            Year = Convert.ToInt16(Console.ReadLine());
        }

        public override string ToString() => $"Тип объекта: {GetType()}, название журнала - {Title}, жанр - {Genre}, количество публикаций - {NumberOfPublicat}, год выпуска - {Year}";
        
        public void Create()
        {
            GetGenre();
            GetTitle();
            NumberOfPublications();
            YearOfPublications();
        }
    }
    public struct Schoolbook : IPublishing
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int NumberOfPublicat { get; set; }
        public int Year { get; set; }

        public void GetTitle()
        {
            Console.WriteLine("Введите название учебника: ");
            Title = Console.ReadLine();
        }

        public void GetGenre()
        {
            Console.WriteLine("Выбирете жанр: \n1-Физика\n2-Химия\n3-Математика\n4-Биология");
            var choice = Convert.ToInt16(Console.ReadLine());
            if (choice > 4 || choice < 1)
            {
                throw new Exception("Out of range");
            }
            else
            {
                switch (choice)
                {
                    case 1:
                        Genre = "Научный";
                        break;
                    case 2:
                        Genre = "Комиксы";
                        break;
                    case 3:
                        Genre = "Женский";
                        break;
                    case 4:
                        Genre = "Детский";
                        break;
                }
            }
        }

        public void NumberOfPublications()
        {
            Console.WriteLine("Введите количество изданий:");
            NumberOfPublicat = Convert.ToInt16(Console.ReadLine());
        }
        
        public void YearOfPublications()
        {
            Console.WriteLine("Введите год выпуска");
            Year = Convert.ToInt16(Console.ReadLine());
        }
        
        public override string ToString() => $"Тип объекта: {GetType()}, название учебника - {Title}, жанр - {Genre}, количество публикаций - {NumberOfPublicat}, год выпуска - {Year}";
        
        public void Create()
        {
            GetGenre();
            GetTitle();
            NumberOfPublications();
            YearOfPublications();
        }
    }
}
