namespace Lab1.AbstractFactory
{
    public abstract class AnimalFactory
    {
        public abstract IGreeting CreateGreeting();

        public abstract IEating CreateEating();
    }
}
