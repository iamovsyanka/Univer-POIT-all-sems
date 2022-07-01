using System.Collections.Generic;

namespace Lab1
{
    public class ResultModel
    {
        public int Result { get; set; }
        public Stack<int> Stack { get; set; }
        public ResultModel()
        {
            Stack = new Stack<int>();
        }
    }
}