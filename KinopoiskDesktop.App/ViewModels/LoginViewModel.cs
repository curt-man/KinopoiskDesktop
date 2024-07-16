using KinopoiskDesktop.App.Core;
using KinopoiskDesktop.App.Services.IService;
using System.Windows.Input;

namespace KinopoiskDesktop.App.ViewModels
{
    public class LoginViewModel : BaseViewModel
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

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            
        }

        public LoginViewModel(IAuthenticationService authenticationService, INavigationService navigationService)
        {
            _authenticationService = authenticationService;
            _navigationService = navigationService;
            LoginCommand = new RelayCommand(async _ => await Login(), _ => CanLogin());
        }

        private async Task Login()
        {
            var result = await _authenticationService.Login(Username, Password);
            if (result)
            {
                _navigationService.NavigateTo<HomeViewModel>();
            }
            else
            {
                ErrorMessage = "Invalid username or password.";
            }
        }

        private bool CanLogin()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }
    }

}
