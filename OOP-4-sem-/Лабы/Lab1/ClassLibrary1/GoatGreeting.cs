using System.Windows;

namespace Lab1.AbstractFactory
{
    class GoatGreeting : IGreeting
    {
        public void SayHello() => MessageBox.Show("Привет, я козел!");
    }
}
