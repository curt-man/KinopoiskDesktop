using KinopoiskDesktop.App.Core;
using KinopoiskDesktop.App.Services.IService;

namespace KinopoiskDesktop.App.Services
{
    public class NavigationService : ObservableObject, INavigationService
    {
        private ViewModelBase? currentView;
        private readonly IViewModelFactory viewModelFactory;

        public ViewModelBase CurrentView
        {
            get => currentView!;
            private set
            {
                if (currentView == value)
                    return;
                currentView = value;
                OnPropertyChanged();
            }
        }

        public NavigationService(IViewModelFactory viewModelFactory) => this.viewModelFactory = viewModelFactory;

        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
        {
            ViewModelBase ViewModel = viewModelFactory.CreateViewModel<TViewModel>();
            CurrentView = ViewModel;
        }

        public void NavigateTo<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            ViewModelBase ViewModel = viewModelFactory.CreateViewModel<TViewModel>(parameter);
            CurrentView = ViewModel;
        }

        public void NavigateTo(ViewModelBase viewModel)
        {
            CurrentView = viewModel;
        }



    }
}
