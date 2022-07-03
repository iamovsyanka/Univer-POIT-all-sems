using System;
using System.Collections.Generic;
using System.IO;

namespace Lab8
{
    public class CollectionType<T> : ICollectionType<T> where T : class 
    {
        private List<T> list = new List<T> { };
        static int count = 0;

        public void Add(T myList)
        {
            list.Add(myList);
            count++;
        }

        public void Insert(int index, T myList)
        {
            if (index > list.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Out of range");
            }
            list.Insert(index, myList);
            count++;
        }

        public T this[int index]
        {
            get
            {
                if (index > list.Count || index < 0)
                {
                    throw new Exception("Out of range");
                }

                return list[index];
            }
            set
            {
                if (index > list.Count || index < 0)
                {
                    throw new Exception("Out of range");
                }
                list[index] = value;
            }
        }

        public void Show()
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write("{0}\t", list[i]);
            }
            Console.WriteLine();
        }

        public void Print()
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine();

        }

        public void Clear()
        {
            list.Clear();
            count = 0;
        }

        public void RemoveAt(int index)
        {
            if (index > list.Count || index < 0)
            {
                throw new Exception("Out of range");
            }
            list.RemoveAt(index);
            count--;
        }  
    }
}
