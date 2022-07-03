using System;
using System.Text;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.Типы
            var v = 0; //применяется только в объявлении локальных переменных
            sbyte sb = 1;
            short sh = 1;
            int i = 2;
            long l = 3;
            byte b = 5;
            ushort us = 8;
            uint ui = 13;
            ulong ul = 21;
            char ch = 'A';
            bool bo = false;
            float f = 1.7f; //точность 6–9 цифр
            double d = 14.12375d; //точность 15–17 цифр
            decimal dec = 144.734342m; //точность 28-29 знаков
            string str = "String";
            object Object = "Object"; //может хранить значение любого типа данных

            //явное преобразование
            d = (double)f;
            ch = (char)ui;
            b = (byte)sb;
            i = (int)l;
            us = (ushort)sh;

            //неявное преобразование
            d = f;
            l = i;
            ul = us;
            i = sh;
            dec = i;

            //упаковкa и распаковкa значимых типов
            int x = 4;     
            object o = x;     // упаковкa
            int j = (int)o;   // распаковкa
            Console.WriteLine(j + "\n===========================");

            //работа с неявно типизированной переменной
            var Var1 = "iamvar";
            var Var2 = 1234;
            Console.WriteLine("Строка " + Var1 + "\n" + "Число " + Var2 + "\n===========================");

            //пример работы с Nullable переменной
            int? Null1 = null;
            int? Null2 = null;
            Console.WriteLine(Null1 == Null2 ? "True" : "False\n");
            Console.WriteLine("{0} \n===========================", Null1.HasValue && Null2.HasValue ? "Not null" : "null");

            // 2.Строки
            string str1 = "c#", str2 = "c++";
            Console.WriteLine("{0} \n===========================", str1 == str2 ? "==" : "!=");
            // литералы
            string lit1 = @"C:\Windows\user";
            string lit2 = "C:\\Windows\\user";
            string lit3 = "C:/Windows/user";
            Console.WriteLine($"{lit1}\n{lit2}\n{lit3}\n===========================");

            String Str1 = "JS ";
            String Str2 = "LOVE";
            String Str3 = "I love JavaScript";
            Console.WriteLine("Конкатенация: {0}", String.Concat(Str1, Str2));
            Str2 = String.Copy(Str1);
            Console.WriteLine("Копирование: {0}", Str2);
            Console.WriteLine("Выделение подстроки: {0}", Str3.Substring(2));
            Console.WriteLine("Pазделение строки на слова: {2} {1} {0}", Str3.Split(' ')[0], Str3.Split(' ')[1], Str3.Split(' ')[2]);
            Console.WriteLine("Вставка подстроки в заданную позицию: {0}", Str3.Insert(7, Str2));
            Console.WriteLine("Yдаление заданной подстроки: {0}\n===========================", Str3.Remove(6));

            // Пустая и null строка
                //Пустая строка — экземпляр объекта System.String, содержащий 0 символов:
            string pstr = "";
            // Для пустых строк можно вызывать методы.
            string nustr = null;
            /* Строки со значениями null не ссылаются на экземпляр объекта
            System.String, попытка вызвать метод для строки null вызовет
            исключение NullReferenceException.строки null можно использовать в
            операциях объединения и сравнения с другими строками.*/
            Console.WriteLine(pstr.GetType());
            Console.WriteLine(pstr);
            Console.WriteLine(nustr);
            Console.WriteLine("{0}\t{1}", pstr.Length, pstr == nustr);
            nustr = "help";
            Console.WriteLine("{0} \n===========================", nustr);

            StringBuilder SB = new StringBuilder("Matesha", 50);
            SB = SB.Remove(0, 2);
            SB = SB.Append("ZLO");
            SB = SB.Insert(0, "Mo");
            Console.WriteLine("{0} \n===========================", SB);

            // 3. Массивы
            int[,] mas = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            for (int k = 0; k < 3; k++)
            {
                for (int m = 0; m < 3; m++)
                {
                    Console.Write(mas[k, m] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("===========================");

            string[] masstr = new string[] { "c++", "c#", "js", "ruby", "html" };
            for (int y = 0; y < masstr.Length; y++)
                  Console.Write(masstr[y] + " ");
            Console.WriteLine("\nДлина массива: " + masstr.Length);
            Console.Write("Выберите позицию: ");
            int position = Int16.Parse(Console.ReadLine());
            Console.Write("Введите новый элемент: ");
            masstr[position] = Console.ReadLine();
            for (int y = 0; y < masstr.Length; y++)
                  Console.Write(masstr[y] + " ");
            Console.WriteLine("\n===========================");

            double[][] masdouble = {new double[2], new double[3], new double[4]};;
            Console.WriteLine("Введите значения массива");
            for (int q = 0; q < 2; q++)
            {
                masdouble[0][q] = Convert.ToDouble(Console.ReadLine());
            }
            for (int q = 0; q < 3; q++)
            {
                masdouble[1][q] = Convert.ToDouble(Console.ReadLine());
            }
            for (int q = 0; q < 4; q++)
            {
                masdouble[2][q] = Convert.ToDouble(Console.ReadLine());
            }
            foreach (double[] z in masdouble)
            {
                foreach (int q in z)
                    Console.Write("\t" + q);
                Console.WriteLine();
            }
            Console.WriteLine("\n===========================");

            var masvar = new[] { 1, 'a', -7 };
            Console.Write("Массив: ");
            for (int e=0; e<masvar.Length; e++)
                Console.Write(masvar[e] + " ");
            Console.WriteLine("\n"+masvar.GetType());
            var varstr = "IamStroka";
            Console.WriteLine("Строка: {0}", varstr);
            Console.WriteLine(varstr.GetType());
            Console.WriteLine("===========================");

            // 4. Кортежи
            (int, string, char, string, ulong) kor1 = (4, "POIT", 'A', "FIT", 29);
            var kor2 = (Nomer: 6, Spec: "POIT", Val: 'G', Fac: "FIT", Kol: 29);
            Console.WriteLine($"Номер группы:{kor2.Nomer}\nСпециальность:{kor2.Spec} {kor2.Val}\nФакультет:{kor2.Fac}\nКоличество студентов{kor2.Kol}\n");
            Console.WriteLine($"Номер группы:{kor1.Item1}\nФакультет:{kor1.Item4}\nКоличество студентов:{kor1.Item5}\n");

            var (Nomer, Spec, Val, Fac, Kol) = (kor2.Item1, kor2.Item2, kor2.Item3, kor2.Item4, kor2.Item5);
            Console.WriteLine($"Номер группы:{Nomer}\nСпециальность:{Spec} {Val}\nФакультет:{Fac}\nКоличество студентов:{Kol}\n");
            Console.Write("Кортежи {0} и {1} - {2}", kor1, kor2, Equals(kor1, kor2) ? "равны\n" : "не равны\n");
            Console.WriteLine("===========================");

            // 5. Локальная функция
            
            (int, int, int, char) locfunc(int[] mass, string strok)
            {
                int min = mass[0], max = mass[0], sum = 0;
                for (int u=0; u<mass.Length;u++)
                {
                    if (mass[u] < min)
                        min = mass[u];
                    if (mass[u] > max)
                        max = mass[u];
                    sum += mass[u];
                }
               var result = (min, max, sum, strok[0]);
               return result;
            }
            int[] massiv = { 0, -8, 7, 4, 15 };
            string stroka = "fuf";
            var kort = locfunc(massiv, stroka);
            Console.WriteLine($"Минимальный элемент:{kort.Item1}\nМаксимальный элемент:{kort.Item2}\nСумма элементов:{kort.Item3}\nПервый символ строки: {kort.Item4}");
        }
    }
}
