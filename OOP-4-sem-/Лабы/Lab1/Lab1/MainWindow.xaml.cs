using Lab1.AbstractFactory;
using Lab1.Singleton;
using Lab1.Builder;
using Lab1.Prototype;
using System.Windows;

namespace Lab1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Pig_Click(object sender, RoutedEventArgs e)
        {
            var pig = new Animal(new PigFactory());
            pig.Say();
            pig.Eat();
            MessageBox.Show($"Количество животных: {pig.Count}");
        }

        private void Goat_Click(object sender, RoutedEventArgs e)
        {
            var goat = new Animal(new GoatFactory());
            goat.Say();
            goat.Eat();
            MessageBox.Show($"Количество животных: {goat.Count}");
        }

        private void BigPig_Click(object sender, RoutedEventArgs e)
        {
            var bigPig = GoldPig.GetGoldPig();
            MessageBox.Show($"Я {bigPig.Name}, мой идентификатор:\n {bigPig.guid.ToString()}");
        }

        private void Man_Click(object sender, RoutedEventArgs e)
        {
            var director = new Director();
            DifficultHuman man = director.Create(new ManBuilder());
            MessageBox.Show(man.ToString());
        }

        private void Clon_Click(object sender, RoutedEventArgs e)
        {
            IFigure figure = new Rectangle(30, 40);
            IFigure clonedFigure = figure.Clone;
            figure.GetInfo();
            clonedFigure.GetInfo();
            figure.ChangeSomething();
            figure.GetInfo();
            clonedFigure.GetInfo();
        }
    }
}
