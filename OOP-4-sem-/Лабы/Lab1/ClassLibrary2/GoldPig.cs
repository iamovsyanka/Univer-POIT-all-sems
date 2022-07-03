using System;

namespace Lab1.Singleton
{
    public class GoldPig
    {
        private static GoldPig president;

        private GoldPig()
        { }

        public string Name { get; private set; }

        public Guid guid;

        public static GoldPig GetGoldPig()
        {
            if (president == null)
            {
                president = new GoldPig() { Name = "Главная свиння" };
                president.guid = Guid.NewGuid();
            }

            return president;
        }
    }
}
