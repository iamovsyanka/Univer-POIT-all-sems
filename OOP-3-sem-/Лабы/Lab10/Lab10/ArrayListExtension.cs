using System;
using System.Collections;

namespace Lab10
{
    public static class ArrayListExtension
    {
        public static void Show(this ArrayList arrayList)
        {
            foreach (object obj in arrayList)
            {
                if (obj is int)
                {
                    Console.Write(obj.ToString() + " ");
                }
                else
                {
                    Console.WriteLine(obj.ToString());
                }
            }
            Console.WriteLine();
        }
    }
}
