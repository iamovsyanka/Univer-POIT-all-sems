using System;

namespace Lab3
{
    public partial class Bus : ICloneable
    {
        public static int count;
        private int index;
        private int numberStops;
        private int averageTime;
        private string nameDriver;
        private string typeBus;

        public readonly short maxNumberStops = 17;
        public Bus()
        {
            index = 1;
            numberStops = 5;
            averageTime = 10;
            count++;
        }
        public Bus(int indexBus, byte numberStopsBus, int averageTimeBus)
        {
            index = indexBus;
            numberStops = numberStopsBus;
            averageTime = averageTimeBus;
            count++;
        }
        static Bus() => Console.WriteLine("\t\t\t~~~~~Создание объекта~~~~~");

        public object Clone() 
        {         
            return MemberwiseClone();      
        }


        ~Bus()
        {
            Console.WriteLine("\t\t\t~~~~~Объект уничтожен~~~~~");
        }
        public static int CountTime(int numberStops, int averageTime)
        {
            int resultTime = (numberStops - 1) * averageTime;
            Console.WriteLine($"Время маршрута {resultTime}");

            return resultTime;
        }

        public short NumberBus { get; } = 60;

        public string NameDriver
        {
            set => nameDriver = value;
        }

        public string TypeBus{ get; set; }

        public int Index
        {
            get => index;
            set
            {
                if (value > 0 && value < 25)
                {
                    index = value;
                }
                else
                {
                    Console.WriteLine("Некорретное значение (номер автобуса >0, <25)");
                }
            }
        }

        public int NumberStops
        {
            get => numberStops;
            set
            {
                if (value > 1)
                {
                    numberStops = value;
                }
                else
                {
                    Console.WriteLine("Некорретное значение (количество остановок > 1");
                }
            }
        }

        public int AverageTime
        {
            get => averageTime;
            set
            {
                if (value > 5 && value < 60)
                {
                    averageTime = value;
                }
                else
                {
                    Console.WriteLine("Некорретное значение (среднее время между остановками >5, <60)");
                }
            }
        }

        public void ArrivalTime(ref int hourTime, ref int minuteTime, int countTime, out string arrivalTime)
        {
            minuteTime += countTime;
            if(minuteTime>=60)
            {
                hourTime++;
                minuteTime -= 60;
            }
            Console.WriteLine(arrivalTime = $"Время прибытия {hourTime}:{minuteTime}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Bus m = obj as Bus;
            if (m as Bus == null)
            {
                return false;
            }

            return m.Index == Index && m.NumberStops == NumberStops && m.AverageTime == AverageTime;
        }

        public bool Equals(Bus obj) 
        {
            if (obj == null)
                return false;
            return obj.Index == Index && obj.NumberStops == NumberStops && obj.AverageTime == AverageTime;
        }

        public override int GetHashCode()
        {
            unchecked 
            {
                var hash = 17;
                hash = hash * 23 + Index.GetHashCode();
                hash = hash * 23 + NumberStops.GetHashCode();
                hash = hash * 23 + AverageTime.GetHashCode();

                return hash;
            }
        }

        public override string ToString() => "Номер автобуса " + Index.ToString() + ", количество остановок на маршруте " + NumberStops.ToString() + ", среднее время между остановками " + AverageTime.ToString();
    }

    public static class WriteBus
    {
        public static void GetInformation(string info) => Console.WriteLine($"{info}");
    }

    class Program
    {
        static void Main(string[] args)
        {
            var bus = new Bus(5, 4, 15);
            var bus1 = new Bus(5, 5, 15);

            WriteBus.GetInformation(bus.ToString());
            Console.WriteLine(bus1.Equals(bus));

            var countTime = Bus.CountTime(bus.NumberStops, bus.AverageTime);
            var hour = Convert.ToInt32(Console.ReadLine());
            var minute = Convert.ToInt32(Console.ReadLine());
            bus.ArrivalTime(ref hour, ref minute, countTime, out string arrivalTime);

            var someType = new { index = 7, numberStops = 4, averageTime = 12 };
            Console.WriteLine(someType.index);

            var elemCollection = new BusCollection();
            elemCollection.Add(bus);
            elemCollection.Add(bus1);
            elemCollection.Add(new Bus(9, 15, 25));
            elemCollection.Contains(bus1);
            elemCollection.Search(bus.Index);
            bus.ToString();
            elemCollection.Dispose();
        }
    }
}
