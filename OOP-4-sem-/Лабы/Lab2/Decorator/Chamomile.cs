namespace Decorator
{
    public class Chamomile : Flower
    {
        public Chamomile() : base("Chamomile"){ }

        public override int GetCost() => 8;
    }
}
