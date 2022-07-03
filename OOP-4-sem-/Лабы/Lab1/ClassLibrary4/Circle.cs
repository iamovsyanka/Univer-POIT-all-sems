using System.Windows;

namespace Lab1.Prototype
{
    public class Circle : IFigure
    {
        public Circle(int r) => Radius = r;

        public int Radius { get; private set; }

        public IFigure Clone => new Circle(Radius);

        public void GetInfo() => MessageBox.Show($"Circle with radius {Radius}");

        public void ChangeSomething() => Radius *= 2;
    }
}
