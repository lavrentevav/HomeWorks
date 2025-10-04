using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp_Task_10_1_Authentication.Commands;
using WpfApp_Task_10_1_Authentication.Models;

namespace WpfApp_Task_10_1_Authentication.ViewModels
{
    public class AuthViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _username;
        private string _password;
        private string _statusMessage = "Введите учетные данные";
        private bool _isSuccess;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                _statusMessage = value;
                OnPropertyChanged();
            }
        }

        public bool IsSuccess
        {
            get => _isSuccess;
            set
            {
                _isSuccess = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }

        public AuthViewModel() => LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);


        private void ExecuteLogin(object parameter)
        {
            bool isValid = AuthModel.Authenticate(Username, Password);

            if (isValid)
            {
                StatusMessage = "Аутентификация успешна! Добро пожаловать!";
                IsSuccess = true;

            }
            else
            {
                StatusMessage = "Ошибка аутентификации. Неверный логин или пароль.";
                IsSuccess = false;
                Password = string.Empty;
            }
        }

        private bool CanExecuteLogin(object parameter)
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }        
    }
}
