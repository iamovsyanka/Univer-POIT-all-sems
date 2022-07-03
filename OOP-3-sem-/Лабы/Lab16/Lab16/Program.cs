using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Lab16
{
    class Program
    {
        static int RandomSum()
        {
            var random = new Random();
            return random.Next(50) + random.Next(100);
        }

        static void Display()
        {
            Console.WriteLine($"Текущее: {Task.CurrentId}");
            Thread.Sleep(300);
        }

        static void Display(Task t)
        {
            Console.WriteLine($"Id задачи: {Task.CurrentId}");
            Console.WriteLine($"Id предыдущей задачи: {t.Id}");
        }

        static void Generate(int x)
        {
            var mas = new int[x];
            var random = new Random();
            for (var i = 0; i < x; i++)
            {
                mas[i] = random.Next(17);
            }
        }

        static Task<int> FactorialAsync(int x)
        {
            var result = 1;
            return Task.Run(() =>
            {
                for (var i = 1; i <= x; i++)
                {
                    result *= i;
                }
                return result;
            });
        }

        static async Task DisplayResultAsync()
        {
            var result = await FactorialAsync(25);
            Thread.Sleep(3);
            Console.WriteLine("Факториал числа {0} равен {1}", 25, result);
        }

        static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var taskPrimeNumber1 = new Task(PrimeNumber.PrintPrimeNumber);
            Console.WriteLine($"Status: {taskPrimeNumber1.Status}");
            taskPrimeNumber1.RunSynchronously();
            Console.WriteLine($"Status: {taskPrimeNumber1.Status}");
            stopWatch.Stop();
            Console.WriteLine($"Time: {stopWatch.Elapsed}");
            Console.WriteLine();

            var cancelTokenSource = new CancellationTokenSource();
            var token = cancelTokenSource.Token;
            var taskPrimeNumber2 = new Task(() => PrimeNumber.PrintPrimeNumber(15, token));
            taskPrimeNumber2.Start();
            Console.WriteLine("Введите 0 для отмены операции или другой символ для ее продолжения:");
            var symbStop = Console.ReadLine();
            if (symbStop == "0")
            {
                cancelTokenSource.Cancel();
            }

            Console.WriteLine();
            var task1 = new Task<int>(() => RandomSum());
            task1.Start();
            task1.Wait();
            Console.WriteLine($"task1.Result {task1.GetAwaiter().GetResult()}");

            var task2 = new Task<int>(() => RandomSum());
            task2.Start();
            Console.WriteLine($"task2.Result {task2.Result}");

            var task3 = new Task<int>(() => RandomSum());
            task3.Start();
            Console.WriteLine($"task3.Result {task3.Result}");

            var task4 = new Task<int>(() => task1.Result + task2.Result + task3.Result);
            task4.Start();
            Console.WriteLine($"task4.Result {task4.Result}");

            var continuationTask1 = task4.ContinueWith(Display);

            var watch1 = new Stopwatch();
            watch1.Start();
            Generate(10000);
            watch1.Stop();
            Console.WriteLine($"Общий цикл: {watch1.Elapsed}");
            watch1.Start();
            Parallel.For(1, 10000, Generate);
            watch1.Stop();
            Console.WriteLine($"Параллельный цикл: {watch1.Elapsed}");

            var watch2 = new Stopwatch();
            watch2.Start();
            foreach (int i in new List<int>() { 10000, 10000 })
            {
                Generate(i);
            }
            watch2.Stop();
            Console.WriteLine($"Общий цикл: {watch1.Elapsed}");
            watch2.Start();
            var result = Parallel.ForEach(new List<int>() { 10000, 10000 }, Generate);
            watch2.Stop();
            Console.WriteLine($"Параллельный цикл: {watch2.Elapsed}");

            Parallel.Invoke(Display,
                () =>
                {
                    Console.WriteLine($"Текущее: {Task.CurrentId}");
                    Thread.Sleep(300);
                    Generate(10000);
                },
                () => Generate(10000));

            Warehouse.Work();

            var t = DisplayResultAsync();
            t.Wait();
            Console.ReadLine();
        }
    }
}
