using System;

namespace Lab9
{
    class Program
    {
        private static int Attacked(Game person,int attackValue)
        {
            Console.WriteLine($"У игрока {person.Name} после атаки осталось {person.Hp-attackValue}");
            return person.Hp - attackValue;
        }

        private static int Heal(Game person, int healValue)
        {
            Console.WriteLine($"У игрока {person.Name} после лечения теперь {person.Hp + healValue}");
            return person.Hp + healValue;
        }

        static void Main(string[] args)
        {
            try
            {
                var Ragnar = new Game() { AttackValue = 10, Hp = 100, Name = "Ragnar", HealingValue = 1 };
                var Rollo = new Game() { AttackValue = 2, Hp = 20, Name = "Rollo", HealingValue = 3 };
                Ragnar.AttackEvent += Attacked;
                Ragnar.TreatEvent += Heal;
                Rollo.AttackEvent += Attacked;
                Rollo.TreatEvent += Heal;
                Action.Battle(Rollo, Ragnar);
                
                var myStr = "learn Reac1t";
                Func<string, string> func = MyString.Upper;
                Console.WriteLine($"{func(myStr)}");
                func += MyString.RemoveSpace;
                Console.WriteLine($"{func(myStr)}");
                func += MyString.RemoveNumber;
                Console.WriteLine($"{func(myStr)}");
                func += MyString.AddSymbol;
                Console.WriteLine($"{func(myStr)}");
                func += MyString.ToNewLen;
                Console.WriteLine($"{func(myStr)}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
