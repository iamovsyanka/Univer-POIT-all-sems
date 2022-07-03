using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var arrayList = new ArrayList();
                var random = new Random();

                Console.WriteLine("Добавляем случайные числа: ");
                for (int i = 0; i < 5; i++)
                {
                    arrayList.Add(random.Next(10, 100));
                }
                arrayList.Show();

                Console.WriteLine("\nДобавляем строку и студента");
                arrayList.Add("string");

                var student = new Student("Andrey", "Kozlovski");
                arrayList.Add(student);
                arrayList.Show();

                Console.WriteLine("Введите номер удаляемого элемента");
                var del = Convert.ToInt16(Console.ReadLine());
                if (del < 0 || del > arrayList.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                Console.WriteLine($"Удаляем {del + 1}-ый элемент");
                arrayList.RemoveAt(del);
                arrayList.Show();

                Console.WriteLine($"Количество элементов в коллекции {arrayList.Count}");

                Console.WriteLine("\nВведите элемент для поиска");
                var search = Console.ReadLine();
                if (arrayList.Contains(search))
                {
                    Console.WriteLine("Элемент найден");
                }
                else
                {
                    Console.WriteLine("Элемент не найден");
                }


                var linkedList = new LinkedList<char>();
                linkedList.AddFirst('c');
                linkedList.AddLast('r');
                linkedList.AddBefore(linkedList.Last, 'a');
                linkedList.AddAfter(linkedList.First, 'h');
                linkedList.AddAfter(linkedList.Last, '1');
                linkedList.AddLast('2');

                linkedList.Show();

                Console.WriteLine($"Введите позицию элемента, с которого начнется удаление");
                var index = Convert.ToInt16(Console.ReadLine());
                if(index<0||index>linkedList.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                linkedList.RemoveRange(index);
                linkedList.Show();

                Console.WriteLine("\nВторая коллекция");
                var hashSet = new HashSet<char>();
                foreach(char i in linkedList)
                {
                    hashSet.Add(i);
                }
                foreach(char i in hashSet)
                {
                    Console.Write(i);
                }
                Console.WriteLine();

                Console.WriteLine("Введите элемент для поиска");
                var elem = Convert.ToChar(Console.ReadLine());
                if(hashSet.Contains(elem))
                {
                    Console.WriteLine("Элемент найден");
                }
                else
                {
                    Console.WriteLine("Элемент не найден");
                }

                var book1 = new Book();
                var book2 = new Book();
                var book3 = new Book();
                book1.Create();
                book2.Create();
                book3.Create();              

                var books = new LinkedList<Book>();
                books.AddFirst(book1);
                books.AddLast(book3);
                books.AddBefore(books.Last, book2);

                foreach(object i in books)
                {
                    Console.WriteLine(i.ToString());
                }

                var library = new ObservableCollection<Book>();
                library.CollectionChanged += LibraryChanged;
                library.Add(book1);
                library.Add(book2);
                library.Add(book3);
                library.Remove(book2);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
        }
        private static void LibraryChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Book newBook = e.NewItems[0] as Book;
                    Console.WriteLine($"Добавлен новый объект: {newBook.ToString()}");
                    break;
                case NotifyCollectionChangedAction.Remove: 
                    Book oldBook = e.OldItems[0] as Book;
                    Console.WriteLine($"Удален объект: {oldBook.ToString()}");
                    break;
            }
        }
    }
}
