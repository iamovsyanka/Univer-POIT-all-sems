using System;

namespace Lab11
{
    public partial class Bus : IComparable<Bus>
    {
        public static int count;
        private int index;
        private int numberStops;
        private int averageTime;
        public string Drivers { get; set; }

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

        public static int CountTime(int numberStops, int averageTime)
        {
            int resultTime = (numberStops - 1) * averageTime;
            Console.WriteLine($"Время маршрута {resultTime}");

            return resultTime;
        }

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
            if (minuteTime >= 60)
            {
                hourTime++;
                minuteTime -= 60;
            }
            Console.WriteLine(arrivalTime = $"Время прибытия {hourTime}:{minuteTime}");
        }

        public override string ToString() => "Номер автобуса " + Index.ToString() + ", количество остановок на маршруте " + NumberStops.ToString() + ", среднее время между остановками " + AverageTime.ToString();
        
        public int CompareTo(Bus bus) => AverageTime.CompareTo(bus.AverageTime);
    }

}
