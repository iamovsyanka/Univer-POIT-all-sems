using Lab14.ViewModels;
using System.Windows;

namespace Lab14.View
{
    public partial class Concert : Window
    {
        public Concert()
        {
            InitializeComponent();

            var concertViewModel = new ConcertViewModel();
            DataContext = concertViewModel;
        }
    }
}
