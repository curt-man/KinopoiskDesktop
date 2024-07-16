using KinopoiskDesktop.App.Core;
using KinopoiskDesktop.App.Services.IService;

namespace KinopoiskDesktop.App.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        public FilterViewModel FilterViewModel { get; }

        public INavigationService NavigationService
        {
            get => _navigationService;
            set
            {
                if (_navigationService == value)
                    return;
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(INavigationService navigationService, FilterViewModel filterViewModel)
        {
            NavigationService = navigationService;
            FilterViewModel = filterViewModel;

            NavigateToHomeCommand = new RelayCommand((_) => NavigationService.NavigateTo<HomeViewModel>(), (_) => true);
            NavigateToUserLibraryCommand = new RelayCommand(_ => NavigationService.NavigateTo<UserLibraryViewModel>(), (_) => true);
            NavigateToSettingsCommand = new RelayCommand(_ => NavigationService.NavigateTo<SettingsViewModel>(), (_) => true);

        }


        public RelayCommand NavigateToHomeCommand { get; }
        public RelayCommand NavigateToUserLibraryCommand { get; }
        public RelayCommand NavigateToSettingsCommand { get; }
    }
}
