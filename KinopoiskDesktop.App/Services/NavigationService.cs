using KinopoiskDesktop.App.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KinopoiskDesktop.App.Services.IService;

namespace KinopoiskDesktop.App.Services
{
    public class NavigationService : ObservableObject, INavigationService
    {
        private BaseViewModel? currentView;
        private readonly IViewModelFactory viewModelFactory;

        public BaseViewModel CurrentView
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

        public void NavigateTo<TViewModel>() where TViewModel : BaseViewModel
        {
            BaseViewModel ViewModel = viewModelFactory.CreateViewModel<TViewModel>();
            CurrentView = ViewModel;
        }

        public void NavigateTo<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            BaseViewModel ViewModel = viewModelFactory.CreateViewModel<TViewModel>(parameter);
            CurrentView = ViewModel;
        }

        public void NavigateTo(BaseViewModel viewModel)
        {
            CurrentView = viewModel;
        }



    }
}
