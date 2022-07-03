using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Lab15
{
    class Program
    {
        static object locker = new object();
        public static bool IsPrime(int x)
        {
            for (var i = 2; i <= x / i; i++)
            {
                if ((x % i) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static public void PrintProcess()
        {
            try
            {
                using (var writer = new StreamWriter("Process.txt"))
                {
                    Process[] allProcess = Process.GetProcesses();
                    foreach (Process proc in allProcess)
                    {
                        writer.WriteLine("Id: " + proc.Id);
                        writer.WriteLine("Process name: " + proc.ProcessName);
                        writer.WriteLine("Start at: " + proc.StartTime);
                        writer.WriteLine($"Priority: {proc.BasePriority}");
                        writer.WriteLine($"Memory: {proc.VirtualMemorySize64}");
                        writer.WriteLine();

                        Console.WriteLine($"Id: {proc.Id}");
                        Console.WriteLine($"Process name: {proc.ProcessName}");
                        Console.WriteLine($"Start at: {proc.StartTime}");
                        Console.WriteLine($"Priority: {proc.BasePriority}");
                        Console.WriteLine($"Memory: {proc.VirtualMemorySize64}");
                        Console.WriteLine($"Responding: {proc.Responding}");
                        Console.WriteLine();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message+"\n");
            }
        }

        static public void PrintDomain()
        {
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Name: {domain.FriendlyName}");
            Console.WriteLine($"Base Directory: {domain.BaseDirectory}");
            Console.WriteLine($"Configuration: {domain.SetupInformation}");
            Console.WriteLine("A set of.NET assemblies loaded into an application domain:");
            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly asm in assemblies)
            {
                Console.WriteLine("-->"+asm.GetName().FullName);
            }

            AppDomain newDomain = AppDomain.CreateDomain("NewDomain");
            newDomain.Load(assemblies[1].FullName);
            AppDomain.Unload(newDomain);
        }

        static public void FirstThread()
        {
            lock (locker)
            {
                Console.Write("Enter number: ");
                var number = Convert.ToInt16(Console.ReadLine());
                using (var writer = new StreamWriter("FirstThread.txt"))
                {
                    for (var i = 2; i <= number; i++)
                    {
                        if (IsPrime(i))
                        {
                            Console.Write(i + " ");
                            writer.Write(i + " ");
                            Thread.Sleep(500);
                        }
                        if (i == number)
                        {
                            Console.WriteLine($"\nId {Thread.CurrentThread.ManagedThreadId}");
                            Console.WriteLine($"Статус {Thread.CurrentThread.ThreadState}");
                            Console.WriteLine($"Приоритет {Thread.CurrentThread.Priority}");
                        }
                    }
                }
            }
        }

        static public void SecondThread()
        {
            for (var i = 0; i <= 5; i += 2)
            {
                lock (locker)
                {
                    using (var writer = new StreamWriter("SecondThread.txt"))
                    {
                        Console.Write(i + " ");
                        writer.Write(i + " ");
                        Thread.Sleep(500);
                    }
                }
            }
        }

        static public void ThirdThread()
        {
            for (var i = 1; i <= 5; i += 2)
            {
                lock (locker)
                {
                    using (var writer = new StreamWriter("ThirdThread.txt"))
                    {
                        Console.Write(i + " ");
                        writer.Write(i + " ");
                        Thread.Sleep(500);
                    }
                }
            }
        }

        static public void Beep(object obj)
        {
            for (var i = 1; i < 9; i++)
            {
                Console.Beep();
            }         
        }

        static void Main(string[] args)
        {
            PrintProcess();
            PrintDomain();

            var thread1 = new Thread(new ThreadStart(FirstThread));
            thread1.Start();
            Thread.Sleep(2000);
            thread1.Join();

            var thread2 = new Thread(new ThreadStart(SecondThread));
            var thread3 = new Thread(new ThreadStart(ThirdThread));
            thread3.Priority = ThreadPriority.Lowest;
            thread2.Start();
            thread2.Join();
            thread3.Start();
            thread3.Join();

            Console.WriteLine();
            var thread4 = new Thread(new ThreadStart(SecondThread));
            var thread5 = new Thread(new ThreadStart(ThirdThread));
            thread4.Start();
            thread5.Start();

            var num = 0;
            var tm = new TimerCallback(Beep);
            var timer = new Timer(tm, num, 2500, 200);
        }
    }
}
