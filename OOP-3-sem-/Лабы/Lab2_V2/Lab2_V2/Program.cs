using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab2_V2
{
    using Exa = Lab2.Example;
    class Program
    {      
        static void Main(string[] args)
        {
            //Базовый уровень
                //1
            sbyte Sbyte = 1;
            short Short = 1;
            int Int = 2;
            long Long = 3;
            byte Byte = 5;
            ushort Ushort = 8;
            uint Uint = 13;
            ulong Ulong = 21;
            char Char = 'A';
            bool Bool = false;
            float Float = 1.7f; //точность 6–9 цифр
            double Double = 14.12375d; //точность 15–17 цифр
            decimal Decimal = 144.734342m; //точность 28-29 знаков
            string String1 = "String";
            object Object = "Object"; //может хранить значение любого типа данных
 
            object o = Short;     // упаковкa
            short j = (short)o;   // распаковкa

                //2
            int index=6;
            //явное преобразование
            index = (short)Short;
            index = (byte)Byte;
            index = (sbyte)Sbyte;
            //неявное преобразование
            index = Int;
            index = Short;
            index = Ushort;

                 //3
            string name = "Onya";
            Console.WriteLine(String.Format("My name is {0}", name));
            Console.WriteLine($"My name is {name}");
            Console.WriteLine("~~~~~~~~~~~~");

                //4
            object obj1 = 147;
            object obj2 = "147";
            Console.WriteLine(obj1.GetType());
            Console.WriteLine(obj1.Equals(obj2));
            Console.WriteLine((obj1.ToString()).Equals(obj2));
            Console.WriteLine("~~~~~~~~~~~~");

                //5
            string str1 = "Java", str2 = "love";
            Console.Write("Сравнение двух строк в алфавитном порядке: ");
            int srav = String.Compare(str1, str2);
            if (srav < 0)
            {
                Console.WriteLine("cтрока str1 перед строкой str2");
            }
            else if (srav > 0)
            {
                Console.WriteLine("cтрока str1 стоит после строки str2");
            }
            else
            {
                Console.WriteLine("cтроки str1 и str2 идентичны");
            }
            Console.WriteLine("Проверка на наличие указанного символа: {0}", str1.Contains('a'));
            Console.WriteLine("Выделение подстроки: {0}", str1.Substring(4));
            Console.WriteLine("Вставка в строку подстроку: {0}", str1.Insert(0, str2));
            Console.WriteLine("Замещение в строке символ или подстроку другим символом или подстрокой: {0}", str2.Replace('l', 'L'));
            Console.WriteLine("~~~~~~~~~~~~");

                //6
            string pStr = "";
            string nuStr = null;
            Console.WriteLine(String.IsNullOrEmpty(pStr));
            Console.WriteLine(String.IsNullOrEmpty(nuStr));
            Console.WriteLine("~~~~~~~~~~~~");

                //7
            /*var Error = 23;
            Error = "IamError";
            Ошибка CS0029  Не удается неявно преобразовать тип "string" в "int"*/

                //8
            int? Null1 = null;
            Nullable<int> Null2 = null;
            Console.WriteLine(Null1 == Null2 ? "==" : "!=");
            Console.WriteLine("{0} \n~~~~~~~~~~~~", Null1.HasValue && Null2.HasValue ? "Not null" : "null");

            //Средний уровень

            var tuple1 = (it1:2,it2:4);
            void foo((int n, int a) tuple)
            {
                Console.WriteLine(tuple.GetType());
            }
            foo(tuple1);

            var tuple2 = (it1: 2, it2: 4,it3:8);
            var (data1, data2, data3) = (tuple2.it1, tuple2.it2, tuple2.it3);

            /*void Print1()
            {
                checked
                {
                    int max = (int)Math.Pow(2, 31);
                    Console.WriteLine(max);
                }
            }*/

            void Print2()
            {
                unchecked
                {
                    int max = (int)Math.Pow(2, 31);
                    Console.WriteLine(max);
                }
            }

            //Print1();
            Print2();
            Exa a = new Exa(4);
            a.Dispose();
        }
    }
}

namespace Lab2
{
    public class Example : IDisposable
    {
        private readonly int _state;

        public Example(int state)
        {
            _state = state;
        }

        public int GetState() => _state;

        public void Dispose()
        {
            Console.Beep();
        }
    }
}
