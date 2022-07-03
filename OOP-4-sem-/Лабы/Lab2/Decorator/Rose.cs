namespace Decorator
{
    public class Rose : Flower
    {
        public Rose() : base("Rose"){ }

        public override int GetCost() => 10;
    }
}
