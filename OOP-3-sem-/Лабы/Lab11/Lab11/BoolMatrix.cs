using System;

namespace Lab11
{
    public class BoolRandom
    {
        Random random = new Random();
        public bool NextBool() => random.Next() % 2 == 0;
    }
    class BoolMatrix
    {
        public bool[,] myBoolMatrix = new bool[10, 10];
        public int Row { get; set; }
        public int Colunm { get; set; }

        BoolRandom random = new BoolRandom();
        public void CreateBoolMatrix()
        {
            Console.WriteLine();
            Row = Convert.ToInt32(Console.ReadLine());
            Colunm = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Colunm; j++)
                {
                    myBoolMatrix[i,j] = random.NextBool();
                }
            }
        }

        public void Show()
        {
            for(int i=0;i<Row;i++)
            {
                for (int j = 0; j < this.Colunm; j++)
                {
                    Console.Write((myBoolMatrix[i, j] == true ? 1 : 0) + " ");
                }
                Console.WriteLine();
            }
        }

        public int ReturnTrue()
        {
            var count = 0;
            for(int i=0;i<Row;i++)
            {
               for(int j=0;j<Colunm;j++)
               {
                    if (myBoolMatrix[i, j] == true)
                    {
                        count++;
                    }
               }
            }

            return count;
        }
    }
}
