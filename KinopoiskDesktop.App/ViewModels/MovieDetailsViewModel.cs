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

        public ICommand AddToFavoritesCommand { get; }
        public ICommand MarkAsWatchedCommand { get; }
        public ICommand RateMovieCommand { get; }

        public MovieDetailsViewModel(IMovieService movieService, INavigationService navigationService, AppUserMovie movie)
        {
            _movieService = movieService;
            _navigationService = navigationService;
            SelectedMovie = movie;

            AddToFavoritesCommand = new RelayCommand(AddToFavorites, CanExecute);
            MarkAsWatchedCommand = new RelayCommand(MarkAsWatched, CanExecute);
            RateMovieCommand = new RelayCommand(RateMovie, CanExecute);
        }

        private bool CanExecute(object parameter)
        {
            return SelectedMovie != null;
        }

        private async void AddToFavorites(object parameter)
        {
            await _movieService.MarkAsFavoriteAsync(SelectedMovie);
            // Additional logic for updating UI or providing feedback
        }

        private async void MarkAsWatched(object parameter)
        {
            SelectedMovie.IsWatched = true;
            await _movieService.MarkAsWatchedAsync(SelectedMovie);
            // Additional logic for updating UI or providing feedback
        }

        private void RateMovie(object parameter)
        {
            // Logic for opening a rating dialog or similar
            var rating = ShowRatingDialog();
        }

        private double? ShowRatingDialog()
        {
            // Implement the logic to show a dialog for rating the movie and return the rating
            // This is just a placeholder implementation
            return 8.5; // Example rating
        }
    }


}
