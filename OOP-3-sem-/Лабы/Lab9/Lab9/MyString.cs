using System.Linq;

namespace Lab9
{
    class MyString
    {
        public static string Upper(string myStr) => myStr.ToUpper();

        public static string RemoveSpace(string myStr) => myStr.Replace(" ", string.Empty);

        public static string RemoveNumber(string myStr)
        {
            var masOfNumber = new char[] {'0','1','2','3','4','5','6','7','8','9' };
            for(int i=0;i<myStr.Length;i++)
            {
                if (masOfNumber.Contains(myStr[i]))
                {
                    myStr = myStr.Remove(i, 1);
                }
            }

            return myStr;
        }

        public static string AddSymbol(string myStr) => myStr + "!";

        public static string ToNewLen(string myStr) => myStr.Replace(" ", "\n");
    }
}
