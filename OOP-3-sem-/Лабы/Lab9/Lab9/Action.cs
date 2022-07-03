using System;

namespace Lab9
{
    public static class Action
    {
        public static void Battle(Game person1, Game person2)
        {
            Console.WriteLine($"~~~~~~~~~~~~~Игра началась!~~~~~~~~~~~~~\n\n\nПервым ходит {person1.Name}\n");
            int choice;
            while (true)
            {
                if (person1.Hp > 0)
                {
                    Console.WriteLine("1-атака, 2-лечение");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                person1.Attack(person2);
                                break;
                            }
                        case 2:
                            {
                                person1.Heal();
                                break;
                            }
                        default:
                            {
                                throw new Exception("Неверный формат");
                            }
                    }
                }
                else
                {
                    Console.WriteLine($"Игрок {person1.Name} Проиграл\nИгрок {person2.Name}-победитель");
                    Console.WriteLine("\n\n~~~~~~~~~~~~Конец.~~~~~~~~~~~~\n\n");
                    return;
                }
                if (person2.Hp > 0)
                {
                    Console.WriteLine("1-атака,2-лечение");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                person2.Attack(person1);
                                break;
                            }
                        case 2:
                            {
                                person2.Heal();
                                break;
                            }
                        default:
                            {
                                throw new Exception("Неверный формат");
                            }
                    }
                }
                else
                {
                    Console.WriteLine($"Игрок {person2} Проиграл\nИгрок {person1}-победитель");
                    Console.WriteLine("\n\n~~~~~~~~~~~~Конец.~~~~~~~~~~~~\n\n");
                    return;
                }
            }

        }
    }
}
