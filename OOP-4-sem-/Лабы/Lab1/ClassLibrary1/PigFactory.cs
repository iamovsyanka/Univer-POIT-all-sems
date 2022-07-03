namespace Lab1.AbstractFactory
{
    public class PigFactory : AnimalFactory
    {
        public override IGreeting CreateGreeting() => new PigGreeting();

        public override IEating CreateEating() => new PotatoEating();
    }
}
