namespace Lab1.AbstractFactory
{
    public class Animal
    {
        private IGreeting greeting;
        private IEating eating;
        private static int count=0;

        public int Count => count;

        public Animal(AnimalFactory farmFactory)
        {
            greeting = farmFactory.CreateGreeting();
            eating = farmFactory.CreateEating();
            count++;
        }

        public void Say() => greeting.SayHello();

        public void Eat() => eating.Eat();
    }
}
