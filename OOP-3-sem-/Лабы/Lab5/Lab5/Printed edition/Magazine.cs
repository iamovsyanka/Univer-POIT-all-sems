using System;

namespace Lab5
{
    public class Magazine : Author, IPublishing
    {
        private string title;
        private string genre;
        private int numberOfPublicat;
        private int yearOfPublicat;

        public void GetTitle()
        {
            Console.WriteLine("Введите название журнала: ");
            title = Console.ReadLine();
        }

        public void GetGenre()
        {
            Console.WriteLine("Выбирете жанр: \n1-Научный\n2-Комиксы\n3-Женский\n4-Детский");
            var choice = Convert.ToInt16(Console.ReadLine());

            if(choice>5 || choice<1)
            {
                throw new Exception("Out of range");
            }
            else
            {
                switch(choice)
                {
                    case 1:
                        genre = "Научный";
                        break;
                    case 2:
                        genre = "Комиксы";
                        break;
                    case 3:
                        genre = "Женский";
                        break;
                    case 4:
                        genre = "Детский";
                        break;
                }

            }
            
        } 
        public void NumberOfPublications()
        {
            Console.WriteLine("Введите количество изданий:");
            numberOfPublicat = Convert.ToInt16(Console.ReadLine());
        }
        public void YearOfPublications()
        {
            Console.WriteLine("Введите год выпуска");
            yearOfPublicat = Convert.ToInt16(Console.ReadLine());
        }
        public override string ToString() => $"Тип объекта: {GetType()}, название журнала - {title}, жанр - {genre}, количество публикаций - {numberOfPublicat}";
    }
}
