using KinopoiskDesktop.App.Core;
using KinopoiskDesktop.App.Helpers;
using KinopoiskDesktop.App.Services.IService;
using KinopoiskDesktop.Domain.Models;
using System.Windows.Input;

namespace KinopoiskDesktop.App.ViewModels
{
    public class MovieDetailsViewModel : ViewModelBase
    {
        private readonly IMovieService _movieService;
        private readonly INavigationService _navigationService;
        private AppUserMovie _selectedMovie;
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

        public AppUserMovie SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                OnPropertyChanged();
            }
        }

        public ICommand ToggleFavoriteCommand { get; }
        public ICommand ToggleWatchedCommand { get; }
        public ICommand RateMovieCommand { get; }

        public MovieDetailsViewModel()
        {
        }

        public MovieDetailsViewModel(IMovieService movieService, INavigationService navigationService, AppUserMovie movie, IAuthenticationService authenticationService)
        {
            _movieService = movieService;
            _navigationService = navigationService;
            _authenticationService = authenticationService;
            SelectedMovie = movie;

            ToggleFavoriteCommand = new RelayCommand(ToggleFavorite, CanExecute);
            ToggleWatchedCommand = new RelayCommand(ToggleWatched, CanExecute);
            RateMovieCommand = new RelayCommand(RateMovie, CanExecute);

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

        private bool CanExecute(object parameter)
        {
            return SelectedMovie != null && IsUserAuthenticated;
        }

        /// <summary>
        /// Toggles the selected movie's favorite status
        /// </summary>
        /// <param name="parameter"></param>
        private async void ToggleFavorite(object parameter)
        {
            var isChanged = await _movieService.ToggleFavoriteAsync(SelectedMovie);
            if (isChanged)
            {
                OnPropertyChanged(nameof(SelectedMovie));
            }
        }

        /// <summary>
        /// Toggles the selected movie's watched status
        /// </summary>
        /// <param name="parameter"></param>
        private async void ToggleWatched(object parameter)
        {
            var isChanged = await _movieService.ToggleWatchedAsync(SelectedMovie);
            if(isChanged)
            {
                OnPropertyChanged(nameof(SelectedMovie));
            }
        }

        /// <summary>
        /// Rates the selected movie
        /// </summary>
        /// <param name="parameter"></param>
        private async void RateMovie(object parameter)
        {
            // TODO: Use commands instead of calling methods directly
            var dialogHelper = new DialogHelper();
            var rating = await dialogHelper.ShowRatingDialogAsync();
            if (rating.HasValue)
            {
                SelectedMovie.Rating = rating.Value;
                await _movieService.RateMovieAsync(SelectedMovie);
                OnPropertyChanged(nameof(SelectedMovie));
            }
        }
    }
}
