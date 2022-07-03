using System;
using System.Windows;

namespace Lab1.Prototype
{
    public class Rectangle : IFigure
    {
        public Rectangle(int w, int h)
        {
            Width = w;
            Height = h;
        }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public IFigure Clone => new Rectangle(Width, Height);

        public void GetInfo() => MessageBox.Show($"Rectangle height - {Height} \t  width - {Width}");
        
        public void ChangeSomething()
        {
            Width += 10;
            Height += 5;
        }
    }
}
