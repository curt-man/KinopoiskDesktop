using KinopoiskDesktop.App.Core;
using KinopoiskDesktop.App.Helpers;
using KinopoiskDesktop.App.Services;
using KinopoiskDesktop.App.Services.IService;
using KinopoiskDesktop.Domain.Enums;
using KinopoiskDesktop.Domain.Models;
using KinopoiskDesktop.Domain.SearchFilters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace KinopoiskDesktop.App.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IMovieService _movieService;
        private readonly INavigationService _navigationService;
        private IAuthenticationService _authenticationService;
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
        private readonly FilterViewModel _filterViewModel;

        private AppUserMovie _selectedMovie;
        public AppUserMovie SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                OnPropertyChanged();
                if(value != null)
                {
                    MovieSelectedCommand.Execute(value);
                }
            }
        }

        public ICommand MovieSelectedCommand { get; }

        public HomeViewModel()
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

        public HomeViewModel(IMovieService movieService, INavigationService navigationService, FilterViewModel filterViewModel, IAuthenticationService authenticationService) : this ()
        {
            _movieService = movieService;
            _navigationService = navigationService;
            _authenticationService = authenticationService;

            MovieSelectedCommand = new RelayCommand((movie) => _navigationService.NavigateTo<MovieDetailsViewModel>(movie), _ => true);

            _filterViewModel = filterViewModel;
            _filterViewModel.applyFiltersDelegate = LoadMovies;

            SyncFromApi();
            LoadMovies(filterViewModel);

            IsUserAuthenticated = _authenticationService.CurrentUser != null;
            _authenticationService.UserLoggedIn += OnUserLoggedIn;
            _authenticationService.UserLoggedOut += OnUserLoggedOut;
        }

        private void OnUserLoggedIn(object sender, EventArgs e)
        {
            IsUserAuthenticated = true;
        }

        private void OnUserLoggedOut(object sender, EventArgs e)
        {
            IsUserAuthenticated = false;
        }

        private async void SyncFromApi()
        {
            await _movieService.SyncWithApiAsync();
        }

        private async Task LoadMovies(FilterViewModel filterViewModel)
        {
            var filter = new MovieFilter
            {
                Countries = filterViewModel.SelectedCountries,
                Genres = filterViewModel.SelectedGenres,
                Order = filterViewModel.SelectedOrder,
                Type = filterViewModel.SelectedType,
                RatingFrom = filterViewModel.RatingFrom,
                RatingTo = filterViewModel.RatingTo,
                YearFrom = filterViewModel.YearFrom,
                YearTo = filterViewModel.YearTo,
                ImdbId = filterViewModel.ImdbId,
                Keyword = filterViewModel.Keyword,
                PageSize = 20
            };

            var movies = await _movieService.GetMoviesByFilterAsync(filter);
            Movies.Clear();
            foreach (var movie in movies)
            {
                Movies.Add(movie);
            }
        }

    }

}