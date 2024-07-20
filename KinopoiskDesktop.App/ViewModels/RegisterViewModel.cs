using KinopoiskDesktop.App.Core;
using KinopoiskDesktop.App.Services.IService;
using System.Windows.Input;

namespace KinopoiskDesktop.App.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly INavigationService _navigationService;
        private string _username;
        private string _password;
        private string _errorMessage;

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public ICommand RegisterCommand { get; }

        public RegisterViewModel()
        {
            
        }

        public RegisterViewModel(IAuthenticationService authenticationService, INavigationService navigationService)
        {
            _authenticationService = authenticationService;
            _navigationService = navigationService;
            RegisterCommand = new RelayCommand(async _ => await Register(), _ => CanRegister());
        }

        private async Task Register()
        {
            var result = await _authenticationService.Register(Username, Password);
            if (result)
            {
                _navigationService.NavigateTo<LoginViewModel>();
            }
            else
            {
                ErrorMessage = "Username already exists.";
            }
        }

        private bool CanRegister()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }
    }

}
