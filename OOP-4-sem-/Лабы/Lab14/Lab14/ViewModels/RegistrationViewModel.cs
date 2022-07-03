using Lab14.Context;
using Lab14.Models;
using Models.Commands;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;


namespace Lab14.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private UnitOfWork context;
        private string userName;
        private string password;    

        public RegistrationViewModel()
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

        public ICommand SignUpCommand => new RelayCommand(obj => CanSignUp());

        private async void CanSignUp()
        {
            if (context.UserRepository.GetItem(UserName) != null)
            {
                MessageBox.Show("User has already existed");
                return;
            }

            if (CheckField())
            {
                var newUser = new User()
                {
                    UserName = userName,
                    Password = password,
                };
                await context.UserRepository.AddAsync(newUser);
            }
        }

        private bool CheckField()
        {
            Regex regexLogin = new Regex(@"^[A-zА-я\d]+$");
            Regex regexPassword = new Regex(@"^[A-Za-z\d]+$");

            if (!regexLogin.IsMatch(UserName))
            {
                MessageBox.Show("Login is not validated");
                return false;
            }

            if (!regexPassword.IsMatch(Password) || Password.Length < 6)
            {
                MessageBox.Show("Password is not validated");
                return false;
            }

            return true;
        }

    }
}
