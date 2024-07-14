using KinopoiskDesktop.App.Core;
using KinopoiskDesktop.App.Services.IService;
using KinopoiskDesktop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KinopoiskDesktop.App.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly INavigationService _navigationService;

        public AppUser CurrentUser => _authenticationService.CurrentUser;

        public ICommand LogoutCommand { get; }
        public ICommand NavigateToRegisterCommand { get; }
        public ICommand NavigateToLoginCommand { get; }

        public SettingsViewModel(IAuthenticationService authenticationService, INavigationService navigationService)
        {
            _authenticationService = authenticationService;
            _navigationService = navigationService;
            LogoutCommand = new RelayCommand(async _ => await Logout(), _ => CanExecute());
            NavigateToLoginCommand = new RelayCommand(_ => _navigationService.NavigateTo<LoginViewModel>(), _ => CanExecute());
            NavigateToRegisterCommand = new RelayCommand(_ => _navigationService.NavigateTo<RegisterViewModel>(), _ => CanExecute());
        }

        private bool CanExecute()
        {
            return CurrentUser != null;
        }

        private async Task Logout()
        {
            await _authenticationService.Logout();
        }
    }

}
