namespace Decorator
{
    public abstract class FlowerDecorator : Flower
    {
        protected Flower Flower;

        public FlowerDecorator(string n, Flower flower) : base(n) => Flower = flower;
    }
}
