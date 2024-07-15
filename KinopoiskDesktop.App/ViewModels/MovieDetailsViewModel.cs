using KinopoiskDesktop.App.Core;
using KinopoiskDesktop.App.Services.IService;
using KinopoiskDesktop.Domain.Models;
using System.Windows.Input;

namespace KinopoiskDesktop.App.ViewModels
{
    public class MovieDetailsViewModel : BaseViewModel
    {
        private readonly IMovieService _movieService;
        private readonly INavigationService _navigationService;
        private AppUserMovie _selectedMovie;

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

        public MovieDetailsViewModel(IMovieService movieService, INavigationService navigationService, AppUserMovie movie)
        {
            _movieService = movieService;
            _navigationService = navigationService;
            SelectedMovie = movie;

            ToggleFavoriteCommand = new RelayCommand(ToggleFavorite, CanExecute);
            ToggleWatchedCommand = new RelayCommand(ToggleWatched, CanExecute);
            RateMovieCommand = new RelayCommand(RateMovie, CanExecute);
        }

        private bool CanExecute(object parameter)
        {
            return SelectedMovie != null;
        }

        private async void ToggleFavorite(object parameter)
        {
            SelectedMovie.IsFavorite = !SelectedMovie.IsFavorite;
            if (SelectedMovie.IsFavorite)
            {
                await _movieService.AddToFavoritesAsync(SelectedMovie);
            }
            else
            {
                await _movieService.RemoveFromFavoritesAsync(SelectedMovie);
            }
            OnPropertyChanged(nameof(SelectedMovie));
        }

        private async void ToggleWatched(object parameter)
        {
            SelectedMovie.IsWatched = !SelectedMovie.IsWatched;
            if (SelectedMovie.IsWatched)
            {
                await _movieService.MarkAsWatchedAsync(SelectedMovie);
            }
            else
            {
                await _movieService.MarkAsUnwatchedAsync(SelectedMovie);
            }
            OnPropertyChanged(nameof(SelectedMovie));
        }

        private void RateMovie(object parameter)
        {
            var rating = ShowRatingDialog();
        }

        private double? ShowRatingDialog()
        {
            return 8.5; // Example rating
        }
    }
}
