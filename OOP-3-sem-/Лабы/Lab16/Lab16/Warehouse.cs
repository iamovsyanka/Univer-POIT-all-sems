using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Lab16
{
    public static class Warehouse
    {
        public static BlockingCollection<int> warehouse;
        public static void Producer()
        {
            for (var i = 1; i <= 10; i++)
            {
                warehouse.Add(i);
                Console.WriteLine("Продавец: " + i);
            }
            warehouse.CompleteAdding();
        }

        public static void Consumer()
        {
            int i;
            while (!warehouse.IsCompleted)
            {
                if (warehouse.TryTake(out i))
                {
                    Console.WriteLine("Покупатель: " + i);
                }
            }
        }

        public static void Work()
        {
            warehouse = new BlockingCollection<int>(5);
            var producer = new Task(Producer);
            var consumer = new Task(Consumer);
            producer.Start();
            consumer.Start();
            try
            {
                Task.WaitAll(consumer, producer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                consumer.Dispose();
                producer.Dispose();
                warehouse.Dispose();
            }
        }

    }
}
