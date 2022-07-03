using System.Windows;

namespace Lab1.AbstractFactory
{
    class HayEating : IEating
    {
        public void Eat() => MessageBox.Show("Кушаю сено");
    }
}
