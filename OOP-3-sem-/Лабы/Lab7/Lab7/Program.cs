using System;
using System.Diagnostics;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            var help = "I want to sleep";
            Debug.Assert(help=="I want to sleep");

            try
            { 
                Console.WriteLine("~~~~~~~~~~~~~~Книги~~~~~~~~~~~~~~");
                var book1 = new Book();
                var book2 = new Book();
                var author = new Author();
                book1.Create();
                book2.Create();

                Console.WriteLine("\n\n~~~~~~~~~~Библиотека~~~~~~~~~~");
                var library = new Library();
                library.Add(book1);
                library.Show();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                ex.GetInfo();
            }
            catch (IsNotIPublishingException ex)
            {
                ex.GetInfo();
            }
            catch (ArgumentException ex)
            {
                ex.GetInfo();
            }
            catch
            {
                Console.WriteLine("Неизвестная ошибка");
            }
            finally
            {
                Console.WriteLine("\n\n\nЗавершение программы!");
            }
        }
    }
}
