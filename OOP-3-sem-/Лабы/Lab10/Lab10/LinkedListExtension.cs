using System;
using System.Collections.Generic;

namespace Lab10
{
    public static class LinkedListExtension
    {
        public static void RemoveRange<T>(this LinkedList<T> list, int index)
        {
            for (int i = list.Count; i > index; i--)
            {
                list.RemoveLast();
            }
            
        }

        public static void Show<T>(this LinkedList<T> list)
        {
            foreach(object i in list)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }
    }
}
