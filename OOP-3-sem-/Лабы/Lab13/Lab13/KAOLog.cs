using System;
using System.IO;

namespace Lab13
{
    public class KAOLog
    {
        static FileInfo file = new FileInfo("D:/logfile.txt");
        static string[] str;

        public static void Write(string s)
        {
            using (var writer = new StreamWriter(@"D:/logfile.txt", true, System.Text.Encoding.Default))
            {
                writer.WriteLine(DateTime.Now + " " + s);
            }
        }

        public static void Read()
        {
            string s;
            using (var st = new StreamReader(@"D:/logfile.txt", true))
            {
                s = st.ReadToEnd();
            }

            str = s.Split('\n');
            Console.WriteLine($"Количество записей {str.Length}");
        }

        public static void Search(int d)
        {
            for (var i = 0; i < str.Length - 1; i++)
            {
                if (int.Parse(str[i].Substring(0, 2)) == d)
                {
                    Console.WriteLine(str[i]);
                }
            }
        }
    }
}
