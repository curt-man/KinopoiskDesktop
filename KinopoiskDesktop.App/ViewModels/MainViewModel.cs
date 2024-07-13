using KinopoiskDesktop.App.Core;
using KinopoiskDesktop.App.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskDesktop.App.ViewModels
{
    public class MainViewModel : ViewModel
    {
		private INavigationService _navigationService;

		public INavigationService NavigationService
		{
			get { return _navigationService; }
			set
			{
				if (_navigationService == value)
					return;
				_navigationService = value;
				OnPropertyChanged();
			}
		}

		public MainViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
			NavigateToHomeCommand = new RelayCommand((_) => NavigationService.NavigateTo<HomeViewModel>(), (_) => true);
			NavigateToUserLibraryCommand = new RelayCommand((_) => NavigationService.NavigateTo<UserLibraryViewModel>(), (_) => true);
        }

		public RelayCommand NavigateToHomeCommand { get; set; }
		public RelayCommand NavigateToUserLibraryCommand { get; set; }



	}
}
