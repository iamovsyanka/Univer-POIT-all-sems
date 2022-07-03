namespace Lab1.Prototype
{
    public interface IFigure
    {
        IFigure Clone { get; }

        void GetInfo();

        void ChangeSomething();
    }
}
