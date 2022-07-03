namespace Decorator
{
    public class YellowFlower : FlowerDecorator
    {
        public YellowFlower(Flower flower) : base(flower.Name + " yellow color", flower){  }

        public override int GetCost() => Flower.GetCost() + 1;
    }
}
