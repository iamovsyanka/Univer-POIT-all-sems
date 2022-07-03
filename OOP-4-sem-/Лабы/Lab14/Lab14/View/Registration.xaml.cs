using Lab14.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Lab14.View
{
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();

            var registrationViewModel = new RegistrationViewModel();
            DataContext = registrationViewModel;
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
                if (DataContext != null)
                { ((dynamic)DataContext).Password = ((PasswordBox)sender).Password; }
        }
    }
}
