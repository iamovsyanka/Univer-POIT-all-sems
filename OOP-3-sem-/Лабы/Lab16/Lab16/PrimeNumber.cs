using System;
using System.Threading;

namespace Lab16
{
    public static class PrimeNumber
    {
        public static bool IsPrime(int x)
        {
            for (int i = 2; i <= x / i; i++)
            {
                if ((x % i) == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static void PrintPrimeNumber()
        {
            Console.WriteLine("PrintPrimeNumber() запущен");
            Console.Write("Enter number: ");
            var number = Convert.ToInt32(Console.ReadLine());
            for (var i = 2; i <= number; i++)
            {
                if (IsPrime(i))
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }

        public static void PrintPrimeNumber(int number, CancellationToken token)
        {
            Console.WriteLine("PrintPrimeNumber() запущен");
            for (var i = 2; i <= number; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана");
                    return;
                }
                if (IsPrime(i))
                {
                    Console.Write(i + " ");
                }
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
    }
}
