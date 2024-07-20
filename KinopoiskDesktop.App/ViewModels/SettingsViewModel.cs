using KinopoiskDesktop.App.Core;
using KinopoiskDesktop.App.Services.IService;
using KinopoiskDesktop.Domain.Models;
using System.Windows.Input;

namespace KinopoiskDesktop.App.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly INavigationService _navigationService;

        private AppUser _currentUser;

        public AppUser CurrentUser
        {
            get { return _authenticationService.CurrentUser; }
            set
            {
                OnPropertyChanged();
            }
        }


        public ICommand LogoutCommand { get; }
        public ICommand NavigateToRegisterCommand { get; }
        public ICommand NavigateToLoginCommand { get; }

        public SettingsViewModel()
        {
            
        }

        public SettingsViewModel(IAuthenticationService authenticationService, INavigationService navigationService)
        {
            _authenticationService = authenticationService;
            _navigationService = navigationService;
            LogoutCommand = new RelayCommand(async _ => await Logout(), _ => IsAuthenticated());
            NavigateToLoginCommand = new RelayCommand(_ => _navigationService.NavigateTo<LoginViewModel>(), _ => !IsAuthenticated());
            NavigateToRegisterCommand = new RelayCommand(_ => _navigationService.NavigateTo<RegisterViewModel>(), _ => !IsAuthenticated());
        }

        private bool IsAuthenticated()
        {
            return CurrentUser != null;
        }

        private async Task Logout()
        {
            await _authenticationService.Logout();
            CurrentUser = _authenticationService.CurrentUser;
        }
    }

}
