using Lab14.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Lab14.View
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();

            var loginViewModel = new LoginViewModel();
            DataContext = loginViewModel;
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
                if (DataContext != null)
                { ((dynamic)DataContext).Password = ((PasswordBox)sender).Password; }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            var registration = new Registration();
            registration.Show();
        }
    }
}
