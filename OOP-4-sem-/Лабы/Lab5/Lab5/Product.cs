using System;

namespace Lab5
{
    [Serializable]
    public class Product
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public DateTime DateTime { get; set; }
        public string Weight { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public Producer Producer { get; set; }
        public override string ToString() => $"Name product - {Name}, number - {Number}";
    }
}
