namespace Decorator
{
    public abstract class Flower
    {
        public Flower(string n) => Name = n;

        public string Name { get; protected set; }

        public abstract int GetCost();
    }
}
