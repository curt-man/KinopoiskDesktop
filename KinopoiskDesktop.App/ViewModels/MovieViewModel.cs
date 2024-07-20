using KinopoiskDesktop.App.Core;
using KinopoiskDesktop.App.Services.IService;
using KinopoiskDesktop.Domain.Enums;
using KinopoiskDesktop.Domain.Models;

namespace KinopoiskDesktop.App.ViewModels
{
    public class MovieViewModel : ViewModelBase
    {
        private readonly IMovieService _movieService;
        private readonly INavigationService _navigationService;
        private IAuthenticationService _authenticationService;

        private AppUserMovie _appUserMovie;
        public AppUserMovie AppUserMovie
        {
            get { return _appUserMovie; }
            set
            {
                _appUserMovie = value;
                OnPropertyChanged();
            }
        }

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

        public MovieViewModel()
        {
            _isUserAuthenticated=true;
            _appUserMovie = new AppUserMovie()
            {
                AppUser = new AppUser
                {
                    UserName = "Ahmat",
                    Id = Guid.Parse("54c3195f-2bb4-4c46-86d7-b812f2b2fa83"),
                },
                IsFavorite = true,
                IsWatched = true,
                Rating = 9.5,
                Movie = new Movie()
                {
                    KinopoiskId = 5260016,
                    ImdbId = null,
                    NameRu = "Попкульт",
                    NameEn = null,
                    NameOriginal = null,
                    Countries = new List<MovieCountry> { new MovieCountry { Country = new Country { Name = "Россия" } } },
                    Genres = new List<MovieGenre> { new MovieGenre { Genre = new Genre { Name = "музыка" } } },
                    RatingKinopoisk = 9.4,
                    RatingImdb = null,
                    Year = 2022,
                    Type = FilmType.TV_SERIES,
                    PosterUrl = "https://kinopoiskapiunofficial.tech/images/posters/kp/5260016.jpg",
                    PosterUrlPreview = "https://kinopoiskapiunofficial.tech/images/posters/kp_small/5260016.jpg"
                }
            };
        }

        public MovieViewModel(IMovieService movieService, INavigationService navigationService, IAuthenticationService authenticationService) : this()
        {
            _movieService = movieService;
            _navigationService = navigationService;
            _authenticationService = authenticationService;

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


    }
}
