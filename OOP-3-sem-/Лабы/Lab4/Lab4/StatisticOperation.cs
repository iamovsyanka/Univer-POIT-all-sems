namespace Lab4
{
    static class StatisticOperation
    {
        public static int GetMax(MyList list)
        {
            int max = 0;
            for (int i = 0; i < list.count; i++)
            {
                if (max < list[i].Length)
                {
                    max = list[i].Length;
                }
            }

            return max;
        }

        public static int GetMin(MyList list)
        {
            int min = 0;
            for (int i = 0; i < list.count; i++)
            {
                if (min > list[i].Length)
                {
                    min = list[i].Length;
                }
            }

            return min;
        }

        public static int SubstractMaxMin(MyList list) => StatisticOperation.GetMax(list) - StatisticOperation.GetMin(list);
        
        public static int Cardinality(MyList list) => list.count;

        public static string FindLongWord(MyList list)
        {
            string longWord=null;
            for(int i=0;i<list.count;i++)
            {
                if(list[i].Length==GetMax(list))
                {
                    longWord=list[i];
                }
            }

            return longWord;
        }
        public static void RemoveLast(MyList list) => list.RemoveAt(list.count - 1);
    }
}
