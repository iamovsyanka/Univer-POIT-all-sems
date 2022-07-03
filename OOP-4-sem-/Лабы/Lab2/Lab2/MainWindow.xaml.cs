using System.Windows;
using Adapter;
using Decorator;
using MapComposite;

namespace Lab2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Adapter(object sender, RoutedEventArgs e)
        {
            var minipig = new MiniPig();
            minipig.MiniSay();
             
            var pig = new Pig();
            var pigToMiniPigAdapter = new PigToMiniPigAdapter(pig);
            pigToMiniPigAdapter.MiniSay();
        }

        private void Button_Click_Decorator(object sender, RoutedEventArgs e)
        {
            Flower rose = new Rose();
            rose = new YellowFlower(rose);
            MessageBox.Show($"Name: {rose.Name}, cost: {rose.GetCost()}");

            Flower chamomile = new Chamomile();
            chamomile = new WhiteFlower(chamomile);
            MessageBox.Show($"Name: {chamomile.Name}, cost: {chamomile.GetCost()}");
        }

        private void Button_Click_Map(object sender, RoutedEventArgs e)
        {
            var district = new Map { Title = "District" };
            district.AddComponent(new MapComponent { Title = "Cube 1" });
            district.AddComponent(new MapComponent { Title = "Cube 2" });

            var map = new Map { Title = "New Map of Objects" };
            map.AddComponent(district);
            map.Draw();
            var find = map.Find("Cube 1");
            find.Draw();
        }
    }
}
