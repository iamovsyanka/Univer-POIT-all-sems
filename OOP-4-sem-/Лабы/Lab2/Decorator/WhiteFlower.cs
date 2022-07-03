namespace Decorator
{
    public class WhiteFlower : FlowerDecorator
    {
        public WhiteFlower(Flower flower) : base(flower.Name + " white color", flower) {    }

        public override int GetCost() => Flower.GetCost() + 3;
    }
}
