using KinopoiskDesktop.App.Core;
using KinopoiskDesktop.App.Helpers;
using KinopoiskDesktop.App.Services.IService;
using KinopoiskDesktop.Domain.Models;
using KinopoiskDesktop.Domain.SearchFilters;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace KinopoiskDesktop.App.ViewModels
{
    public class UserLibraryViewModel : ViewModelBase
    {
        private readonly IMovieService _movieService;
        private readonly INavigationService _navigationService;
        private readonly IAuthenticationService _authenticationService;
        private readonly FilterViewModel _filterViewModel;
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

        private MovieListingViewModel _movieListingViewModel;
        public MovieListingViewModel MovieListingViewModel
        {
            get { return _movieListingViewModel; }
            set
            {
                _movieListingViewModel = value;
                OnPropertyChanged();
            }
        }


        public UserLibraryViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                _movieListingViewModel = new MovieListingViewModel();
            }
        }

        public UserLibraryViewModel(
            IMovieService movieService,
            INavigationService navigationService,
            IAuthenticationService authenticationService,
            FilterViewModel filterViewModel,
            MovieListingViewModel movieListingViewModel
            ) : this()
        {
            _movieService = movieService;
            _navigationService = navigationService;
            _authenticationService = authenticationService;

            _movieListingViewModel = movieListingViewModel;
            _movieListingViewModel.MovieSelectedCommand = new RelayCommand((movie) => _navigationService.NavigateTo<MovieDetailsViewModel>(movie), _ => true);

            _filterViewModel = filterViewModel;
            _filterViewModel.applyFiltersDelegate = LoadMovies;

            IsUserAuthenticated = _authenticationService.CurrentUser != null;
            _authenticationService.UserLoggedIn += OnUserLoggedIn;
            _authenticationService.UserLoggedOut += OnUserLoggedOut;

            RefreshView();

        }

        private void OnUserLoggedIn(object sender, EventArgs e)
        {
            IsUserAuthenticated = true;
            _movieListingViewModel.IsUserAuthenticated = true;
        }

        private void OnUserLoggedOut(object sender, EventArgs e)
        {
            IsUserAuthenticated = false;
            _movieListingViewModel.IsUserAuthenticated = false;
        }

        private async void RefreshView()
        {
            await LoadMovies(_filterViewModel);
        }

        /// <summary>
        /// Load movies by filter if it's provided
        /// </summary>
        /// <param name="filterViewModel">Data from filter view model</param>
        /// <returns>List of current user's movies</returns>
        private async Task LoadMovies(FilterViewModel filterViewModel)
        {
            // TODO: Add to filter watched and rated movies as well
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
                IsFavorite = true,
                ForCurrentUser = true,
                PageSize = 20
            };

            var movies = await _movieService.GetFavoritesByFilterAsync(filter);
            _movieListingViewModel.Movies.Clear();
            foreach (var movie in movies)
            {
                _movieListingViewModel.Movies.Add(movie);
            }
        }
    }
}