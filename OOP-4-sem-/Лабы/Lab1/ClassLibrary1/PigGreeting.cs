using System.Windows;


namespace Lab1.AbstractFactory
{
    class PigGreeting : IGreeting
    {
        public void SayHello() => MessageBox.Show("Привет, я свинка!");
    }
}
