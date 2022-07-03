using System.Windows;


namespace Lab1.AbstractFactory
{
    class PotatoEating : IEating
    {
        public void Eat() => MessageBox.Show("Кушаю картошку!");
    }
}
