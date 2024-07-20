using KinopoiskDesktop.App.Core;
using KinopoiskDesktop.App.Helpers;
using KinopoiskDesktop.App.Services.IService;
using KinopoiskDesktop.Domain.Models;
using KinopoiskDesktop.Domain.SearchFilters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KinopoiskDesktop.App.ViewModels
{
    public class MovieListingViewModel : ViewModelBase
    {
        private bool _isUserAuthenticated;

        public bool IsUserAuthenticated
        {
            get => _isUserAuthenticated;
            set
            {
                _isUserAuthenticated = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<AppUserMovie> Movies { get; set; }

        private AppUserMovie _selectedMovie;
        public AppUserMovie SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                OnPropertyChanged();
                if (value != null)
                {
                    MovieSelectedCommand.Execute(value);
                }
            }
        }

        public ICommand MovieSelectedCommand { get; set; }

        public MovieListingViewModel()
        {
            Movies = new ObservableCollection<AppUserMovie>();
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                foreach (var movie in SeedDataHelper.InitializeDesignTimeMovies())
                {
                    Movies.Add(movie);
                }
            }
        }

    }
}
