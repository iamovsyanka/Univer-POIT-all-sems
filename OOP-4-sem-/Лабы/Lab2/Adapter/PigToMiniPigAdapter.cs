namespace Adapter
{
    public class PigToMiniPigAdapter : IMiniPig
    {
        private Pig pig;
        public PigToMiniPigAdapter(Pig pi)
        {
            pig = pi;
        }

        public void MiniSay() => pig.Say();
    }
}
