using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Service service = new Service();
            service.Print();

            Console.WriteLine("\n");
            Console.WriteLine("Enter Id");
            int id1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name: ");
            string name1 = Console.ReadLine();
            service.Add(id1, name1);

            Console.WriteLine("\n");
            Console.WriteLine("Enter Id");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new Name: ");
            string name = Console.ReadLine();
            service.Update(id, name);

            Console.WriteLine("\n\n");
            service.Print();
        }
    }
}
