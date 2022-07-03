using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1 задание
            var months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            
            Console.WriteLine("Запрос 1: последовательность месяцев с длиной строки равной n");
            {
                Console.WriteLine("Введите длину строки:");
                var lenth = Convert.ToInt32(Console.ReadLine());

                IEnumerable<string> linq1 = from m in months
                                            where m.Length == lenth
                                            select m;
                foreach (string month in linq1)
                {
                    Console.Write($"{month}  ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nЗапрос 2: только летние и зимние месяцы");
            {
                var linq2 = months.Where(m => m == months[0] || m == months[1] || m == months[11] || m == months[6] || m == months[7] || m == months[11]);
                foreach (string month in linq2)
                {
                    Console.Write($"{month}  ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nЗапрос 3: вывод месяцев в алфавитном порядке");
            {
                var linq3 = months.OrderBy(m => m);
                foreach (string month in linq3)
                {
                    Console.Write($"{month}  ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nЗапрос 4: месяцы, содержащие букву «u» и длиной имени не менее 4-х");
            {
                IEnumerable<string> linq4 = from m in months where m.Contains('u') && m.Length >= 4 select m;
                foreach (string month in linq4)
                {
                    Console.Write($"{month}  ");
                }
                Console.WriteLine();
            }
            #endregion
            #region 2 задание
            var buses = new List<Bus>
            {
                new Bus(4,20,5),
                new Bus(5,10,20),
                new Bus(6,15,12),
                new Bus(7,14,30),
                new Bus(4,10,10),
                new Bus(10,5,13),
                new Bus(6,3,19)
            };
            var numberOfRoutes = new int[]{4,5,6};
            
            Console.WriteLine("\n\n~~Выбор автобусов, среднее время между остановками которых >10 и <20");
            var linqBus1 = buses.Where(b=>b.AverageTime>10&&b.AverageTime<20);
            foreach(object bus in linqBus1)
            {
                Console.WriteLine(bus.ToString());
            }

            Console.Write("\n~~Выбор автобусов, количество остановок которых больше заданного числа: ");
            int numberStops = Convert.ToInt32(Console.ReadLine());
            linqBus1 = buses.Where(b=>b.NumberStops>numberStops);
            foreach (object bus in linqBus1)
            {
                Console.WriteLine(bus.ToString());
            }

            Console.WriteLine("\n~~Сортировка по номеру и вывод первых 3");
            linqBus1 = buses.OrderBy(b=>b.Index)
                            .Take(3);
            foreach (object bus in linqBus1)
            {
                Console.WriteLine(bus.ToString());
            }

            Console.Write("\nСреднее время между остановками выбранных автобусов: ");
            IEnumerable<int> linqBus2 = buses.Where(b => b.Index == 4 || b.Index == 5 || b.Index == 6)
                            .Where(b => b.NumberStops > 10)
                            .Select(b => b.AverageTime);
            foreach (object bus in linqBus2)
            {
                Console.Write(bus.ToString()+ " ");
            }
         
            var busMaxAverageTime = buses.Max();
            Console.WriteLine($"\nАвтобус с максимальным временем между остановками:\n{busMaxAverageTime}");

            var busMinAverageTime = buses.Min();
            Console.WriteLine($"\nАвтобус с минимальным временем между остановками:\n{busMinAverageTime}");

            Console.WriteLine("\nПример метода Join()");
            var result = buses.Join(numberOfRoutes, b=>b.Index, n=>n, (b,n)=>new { index = b, numberOfRoutes = n });
            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
            #endregion

        }
    }
}
