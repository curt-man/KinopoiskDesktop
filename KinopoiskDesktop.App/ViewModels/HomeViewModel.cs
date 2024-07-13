using KinopoiskDesktop.App.Core;
using KinopoiskDesktop.App.Services;
using KinopoiskDesktop.App.Services.IService;
using KinopoiskDesktop.Domain.Enums;
using KinopoiskDesktop.Domain.Models;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace KinopoiskDesktop.App.ViewModels
{
    public class HomeViewModel : ViewModel
    {
        private readonly IMovieService _movieService;
        private readonly INavigationService _navigationService;
        public ObservableCollection<Movie> Movies { get; set; }
        public ICommand MovieSelectedCommand { get; }

        public HomeViewModel(IMovieService movieService, INavigationService navigationService)
        {
            _movieService = movieService;
            _navigationService = navigationService;
            Movies = new ObservableCollection<Movie>();

            MovieSelectedCommand = new RelayCommand((movie)=>_navigationService.NavigateTo<MovieDetailViewModel>(movi), _=>true);

            LoadMovies();
        }

        private async void LoadMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            foreach (var movie in movies)
            {
                Movies.Add(movie);
            }
        }

        private void PopulateDesignViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                var seedMovies = new List<Movie>()
                {
                    new Movie()
                    {
                        KinopoiskId = 5260016,
                        ImdbId = null,
                        NameRu = "Попкульт",
                        NameEn = null,
                        NameOriginal = null,
                        Countries = new List<Country>()
                        {
                            new Country() { Name = "Россия" }
                        },
                        Genres = new List<Genre>()
                        {
                            new Genre() { Name = "документальный" }
                        },
                        RatingKinopoisk = 9.4,
                        RatingImdb = null,
                        Year = 2022,
                        Type = FilmType.TV_SERIES,
                        PosterUrl = "https://kinopoiskapiunofficial.tech/images/posters/kp/5260016.jpg",
                        PosterUrlPreview = "https://kinopoiskapiunofficial.tech/images/posters/kp_small/5260016.jpg"
                    },
                    new Movie()
                    {
                        KinopoiskId = 1201206,
                        ImdbId = null,
                        NameRu = null,
                        NameEn = null,
                        NameOriginal = "BTS: Blood Sweat & Tears",
                        Countries = new List<Country>()
                        {
                            new Country() { Name = "Корея Южная" }
                        },
                        Genres = new List<Genre>()
                        {
                            new Genre() { Name = "музыка" },
                            new Genre() { Name = "короткометражка" }
                        },
                        RatingKinopoisk = 9.4,
                        RatingImdb = null,
                        Year = 2016,
                        Type = FilmType.VIDEO,
                        PosterUrl = "https://kinopoiskapiunofficial.tech/images/posters/kp/1201206.jpg",
                        PosterUrlPreview = "https://kinopoiskapiunofficial.tech/images/posters/kp_small/1201206.jpg"
                    },

                    new Movie()
                    {
                        KinopoiskId = 952236,
                        ImdbId = "tt5223716",
                        NameRu = "Hot Wheels. Мегатрасса",
                        NameEn = null,
                        NameOriginal = "Team Hot Wheels: Build the Epic Race",
                        Countries = new List<Country>()
                        {
                            new Country() { Name = "США" }
                        },
                        Genres = new List<Genre>()
                        {
                            new Genre() { Name = "мультфильм" },
                            new Genre() { Name = "детский" }
                        },
                        RatingKinopoisk = 9.3,
                        RatingImdb = 6.2,
                        Year = 2015,
                        Type = FilmType.FILM,
                        PosterUrl = "https://kinopoiskapiunofficial.tech/images/posters/kp/952236.jpg",
                        PosterUrlPreview = "https://kinopoiskapiunofficial.tech/images/posters/kp_small/952236.jpg"
                    },
                    new Movie()
                    {
                        KinopoiskId = 5493676,
                        ImdbId = null,
                        NameRu = "Лапша и булочка",
                        NameEn = null,
                        NameOriginal = "Noodle and Bun",
                        Countries = new List<Country>()
                        {
                            new Country() { Name = "ЮАР" }
                        },
                        Genres = new List<Genre>()
                        {
                            new Genre() { Name = "приключения" },
                            new Genre() { Name = "комедия" },
                            new Genre() { Name = "мультфильм" },
                            new Genre() { Name = "семейный" }
                        },
                        RatingKinopoisk = 9.3,
                        RatingImdb = 9.2,
                        Year = 2020,
                        Type = FilmType.TV_SERIES,
                        PosterUrl = "https://kinopoiskapiunofficial.tech/images/posters/kp/5493676.jpg",
                        PosterUrlPreview = "https://kinopoiskapiunofficial.tech/images/posters/kp_small/5493676.jpg"
                    },
                    new Movie()
                    {
                        KinopoiskId = 962472,
                        ImdbId = "tt5396486",
                        NameRu = "Hot Wheels. За гранью воображения",
                        NameEn = null,
                        NameOriginal = "Team Hot Wheels: The Skills to Thrill",
                        Countries = new List<Country>()
                        {
                            new Country() { Name = "США" }
                        },
                        Genres = new List<Genre>()
                        {
                            new Genre() { Name = "мультфильм" },
                            new Genre() { Name = "детский" }
                        },
                        RatingKinopoisk = 9.3,
                        RatingImdb = 6.9,
                        Year = 2015,
                        Type = FilmType.FILM,
                        PosterUrl = "https://kinopoiskapiunofficial.tech/images/posters/kp/962472.jpg",
                        PosterUrlPreview = "https://kinopoiskapiunofficial.tech/images/posters/kp_small/962472.jpg"
                    },
                    new Movie()
                    {
                        KinopoiskId = 1072974,
                        ImdbId = "tt13535142",
                        NameRu = "Герои Энвелла",
                        NameEn = null,
                        NameOriginal = null,
                        Countries = new List<Country>()
                        {
                            new Country() { Name = "Россия" }
                        },
                        Genres = new List<Genre>()
                        {
                            new Genre() { Name = "фантастика" },
                            new Genre() { Name = "мультфильм" },
                            new Genre() { Name = "детский" }
                        },
                        RatingKinopoisk = 9.3,
                        RatingImdb = null,
                        Year = 2017,
                        Type = FilmType.TV_SERIES,
                        PosterUrl = "https://kinopoiskapiunofficial.tech/images/posters/kp/1072974.jpg",
                        PosterUrlPreview = "https://kinopoiskapiunofficial.tech/images/posters/kp_small/1072974.jpg"
                    },
                    new Movie()
                    {
                        KinopoiskId = 1309325,
                        ImdbId = null,
                        NameRu = "Космос",
                        NameEn = null,
                        NameOriginal = "",
                        Countries = new List<Country>()
                        {
                            new Country() { Name = "США" }
                        },
                        Genres = new List<Genre>()
                        {
                            new Genre() { Name = "документальный" }
                        },
                        RatingKinopoisk = 9.3,
                        RatingImdb = null,
                        Year = 2019,
                        Type = FilmType.TV_SERIES,
                        PosterUrl = "https://kinopoiskapiunofficial.tech/images/posters/kp/1309325.jpg",
                        PosterUrlPreview = "https://kinopoiskapiunofficial.tech/images/posters/kp_small/1309325.jpg"
                    },
                    new Movie()
                    {
                        KinopoiskId = 674243,
                        ImdbId = null,
                        NameRu = "Счастливые люди",
                        NameEn = null,
                        NameOriginal = null,
                        Countries = new List<Country>()
                        {
                            new Country() { Name = "Россия" }
                        },
                        Genres = new List<Genre>()
                        {
                            new Genre() { Name = "документальный" }
                        },
                        RatingKinopoisk = 9.2,
                        RatingImdb = 8.7,
                        Year = 2008,
                        Type = FilmType.MINI_SERIES,
                        PosterUrl = "https://kinopoiskapiunofficial.tech/images/posters/kp/674243.jpg",
                        PosterUrlPreview = "https://kinopoiskapiunofficial.tech/images/posters/kp_small/674243.jpg"
                    },

                    new Movie()
                    {
                        KinopoiskId = 1003587,
                        ImdbId = "tt6146460",
                        NameRu = "Гамильтон",
                        NameEn = null,
                        NameOriginal = "Hamilton's America",
                        Countries = new List<Country>()
                        {
                            new Country() { Name = "США" }
                        },
                        Genres = new List<Genre>()
                        {
                            new Genre() { Name = "биография" },
                            new Genre() { Name = "мюзикл" }
                        },
                        RatingKinopoisk = 9.2,
                        RatingImdb = 8.3,
                        Year = 2016,
                        Type = FilmType.FILM,
                        PosterUrl = "https://kinopoiskapiunofficial.tech/images/posters/kp/1003587.jpg",
                        PosterUrlPreview = "https://kinopoiskapiunofficial.tech/images/posters/kp_small/1003587.jpg"
                    },

                };

                foreach (var movie in seedMovies)
                {
                    Movies.Add(movie);
                }
            }
        }
    }

}