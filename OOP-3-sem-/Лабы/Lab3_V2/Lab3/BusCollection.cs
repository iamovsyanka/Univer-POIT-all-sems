using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab3
{
    class BusCollection :Bus,IDisposable
    {
        private List<Bus> buscollection = new List<Bus> { };
        private int Count
        {
            get
            {
                return buscollection.Count;
            }
        }
        public BusCollection()
        {
            this.buscollection = new List<Bus> { };
        }
        public void Add(Bus bus)
        {
            this.buscollection.Add(bus);
        }
        public void RemoveAt(int index)
        {
            if (index > this.buscollection.Count || index < 0)
            {
                Console.WriteLine("");
            }
            this.buscollection.RemoveAt(index);
        }
        
        public void Clear()
        {
            this.buscollection.Clear();
        }
        public Bus this[int index]
        {
            get
            {
                if (index > this.buscollection.Count || index < 0)
                {
                    Console.WriteLine("");
                }
                return (Bus)buscollection[index];
            }
            set
            {
                if (index > this.buscollection.Count || index < 0)
                {
                   Console.WriteLine("");
                }
                buscollection[index] = value;
            }
        }
        public override string ToString()
        {
            return "Коллеция из " + this.buscollection.Count + "элементов";
        }
        public bool Contains(object value)
        {
            bool inList = false;
            for (int i = 0; i < Count; i++)
            {
                if (buscollection[i] == value)
                {
                    inList = true;
                    break;
                }
            }
            Console.WriteLine(inList);
            return inList;
        }

       public void Search(int index)
       {
            for (int i = 0; i < Count; i++)
            {
                if (buscollection[i].Index == index)
                {
                    WriteBus.GetInformation(buscollection[i].ToString());
                }
            }
       }
        public void Dispose()
        {
            Console.Beep(300, 300);
            Thread.Sleep(20);
            Console.Beep(300, 300);
            Thread.Sleep(20);
            Console.Beep(300, 300);
            Thread.Sleep(20);
            Console.Beep(250, 300);
            Thread.Sleep(20);
            Console.Beep(350, 350);
            Console.Beep(300, 300);
            Thread.Sleep(10);
            Console.Beep(250, 300);
            Thread.Sleep(20);
            Console.Beep(350, 350);
            Console.Beep(300, 300);
            Thread.Sleep(20);
        }
    }
    
}
