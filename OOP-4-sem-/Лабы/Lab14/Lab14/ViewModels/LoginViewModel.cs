using Lab14.View;
using Lab14.Context;
using Models.Commands;
using System.Windows;
using System.Windows.Input;

namespace Lab14.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private UnitOfWork context;
        private string userName;
        private string password;

        public LoginViewModel()
        {
            context = new UnitOfWork();
        }

        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string Password
        {
            private get => password;
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public ICommand LoginCommand => new RelayCommand(obj => CanLogin());

        private void CanLogin()
        {
            var currentUser = context.UserRepository.GetItem(UserName);
            if (currentUser != null)
            {
                if (Password == currentUser.Password)
                {
                    var concert = new Concert();
                    concert.Show();
                }
                else
                {
                    MessageBox.Show("Password isn't correctly");
                }
            }
            else
            {
                MessageBox.Show("Login or Password isn't correctly");
            }
        }
    }
}
