using System;
using System.Collections.Generic;

namespace Lab4
{
    public class Owner
    {
        protected string name;
        protected string orghanisation;
        protected int id;
        public Owner(){ }
        public Owner(int id, string name, string orghanisation)
        {
            this.id = id;
            this.name = name;
            this.orghanisation = orghanisation;
        }

    }
    public class MyList : Owner
    {
        readonly Owner owner = new Owner(6, "Anya", "BSTU");
        private List<string> list = new List<string> { };
        public int count=0;

        private int Count => list.Count;

        public void Add(string myList)
        {
            list.Add(myList);
            count++;
        }

        public void Insert(int index, string myList)
        {
            if (index > this.list.Count || index < 0)
            {
                throw new Exception("Out of range");
            }
            list.Insert(index, myList);
            count++;
        }

        public string this[int index]
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

        public static MyList operator >>(MyList list, int indexToDelete)
        {
            Console.WriteLine($"Удаление из списка элемента с индексом {indexToDelete+1}");
            list.RemoveAt(indexToDelete);
            list.Show();

            return list;       
        }

        public static MyList operator +(MyList list, string stringToAdd)
        {
            list.Add(stringToAdd);
            return list;
        }

        public static bool operator ==(MyList list1, MyList list2)
        {
            bool result = false;
            for (int i = 0; i < (list1.Count<list2.Count?list1.Count:list2.Count); i++)
            {
                if (list1[i] == list2[i])
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }

            return result;
        }

        public static bool operator !=(MyList list1, MyList list2)
        {
            bool result = false;
            for (int i = 0; i < (list1.Count < list2.Count ? list1.Count : list2.Count); i++)
            {
                if (list1[i] != list2[i])
                {
                    result=true;
                }
                else
                {
                    result=false;
                }  
            }

            return result;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 23 + count.GetHashCode();
                return hash;
            }
        }

        public class Date
        {
            DateTime dateTime = DateTime.Now;
            public override string ToString() => dateTime.ToShortDateString();
        }
    }
}
