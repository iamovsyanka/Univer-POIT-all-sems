using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            var list1 = new MyList();
            list1.Add("hi");
            list1.Add("i'm");
            list1.Add("string");
            list1.Show();

            var list2 = new MyList();
            list2.Add("i'm");
            list2.Add("string");
            list2.Add("too");
            list2.Show();

            list2 = list2 >> 2;
            Console.WriteLine($"Неравенство двух множеств: {list1 != list2}");
            Console.WriteLine("Добавление элемента: ");

            list2 += "yes";
            list2.Show();
            Console.WriteLine($"Мощность множетсва: {StatisticOperation.Cardinality(list1)}");
            Console.WriteLine($"Длина максимального слова: {StatisticOperation.GetMax(list1)}");
            Console.WriteLine($"Самое длинное слово: { StatisticOperation.FindLongWord(list1)}");

            Console.WriteLine("Удаление последнего элемента: ");
            StatisticOperation.RemoveLast(list2);
            list1.Show();
            MyList.Date dateOfCreation = new MyList.Date();
            Console.WriteLine("\nСдано");
            Console.WriteLine(dateOfCreation);
        }
    }
}
