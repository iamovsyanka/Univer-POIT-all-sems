using System;

namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            Reflector.AllAboutClass("Lab12.Book");
            Console.WriteLine();
            Reflector.PublicMethod("Lab12.Book");
            Console.WriteLine();
            Reflector.Field("Lab12.Book");
            Console.WriteLine();
            Reflector.Interface("Lab12.Book");
            Console.WriteLine();
            var typeParametr = new object();
            Reflector.MethodForType("Lab12.Book", typeParametr.GetType());
            Console.WriteLine();
            Reflector.Voke("Lab12.Book", "GetComment");
        }
    }
}
