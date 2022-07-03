namespace Lab1.AbstractFactory
{
    public class GoatFactory : AnimalFactory
    {
        public override IGreeting CreateGreeting() => new GoatGreeting();

        public override IEating CreateEating() => new HayEating();
    }
}
