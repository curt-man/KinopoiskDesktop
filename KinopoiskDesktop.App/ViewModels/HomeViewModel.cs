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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace KinopoiskDesktop.App.ViewModels
{
    public class HomeViewModel : ViewModel
    {
        private readonly IMovieService _movieService;
        public ObservableCollection<Movie> Movies { get; set; }

        // Designtime constructor
        public HomeViewModel()
        {
            Movies = new ObservableCollection<Movie>();

            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                //var seedMovies = JsonSerializer.Deserialize<List<Movie>>(
                //    """
                //      [
                //        {
                //          "kinopoiskId": 5260016,
                //          "imdbId": null,
                //          "nameRu": "Попкульт",
                //          "nameEn": null,
                //          "nameOriginal": null,
                //          "countries": [
                //            {
                //              "country": "Россия"
                //            }
                //          ],
                //          "genres": [
                //            {
                //              "genre": "документальный"
                //            }
                //          ],
                //          "ratingKinopoisk": 9.4,
                //          "ratingImdb": null,
                //          "year": 2022,
                //          "type": "TV_SERIES",
                //          "posterUrl": "https://kinopoiskapiunofficial.tech/images/posters/kp/5260016.jpg",
                //          "posterUrlPreview": "https://kinopoiskapiunofficial.tech/images/posters/kp_small/5260016.jpg"
                //        },
                //        {
                //          "kinopoiskId": 1201206,
                //          "imdbId": null,
                //          "nameRu": null,
                //          "nameEn": null,
                //          "nameOriginal": "BTS: Blood Sweat & Tears",
                //          "countries": [
                //            {
                //              "country": "Корея Южная"
                //            }
                //          ],
                //          "genres": [
                //            {
                //              "genre": "музыка"
                //            },
                //            {
                //              "genre": "короткометражка"
                //            }
                //          ],
                //          "ratingKinopoisk": 9.4,
                //          "ratingImdb": null,
                //          "year": 2016,
                //          "type": "VIDEO",
                //          "posterUrl": "https://kinopoiskapiunofficial.tech/images/posters/kp/1201206.jpg",
                //          "posterUrlPreview": "https://kinopoiskapiunofficial.tech/images/posters/kp_small/1201206.jpg"
                //        },
                //        {
                //          "kinopoiskId": 1252447,
                //          "imdbId": "tt9257638",
                //          "nameRu": "Лорды раздевалки",
                //          "nameEn": null,
                //          "nameOriginal": "Lords of the Lockerroom",
                //          "countries": [
                //            {
                //              "country": "США"
                //            }
                //          ],
                //          "genres": [
                //            {
                //              "genre": "спорт"
                //            },
                //            {
                //              "genre": "для взрослых"
                //            }
                //          ],
                //          "ratingKinopoisk": 9.4,
                //          "ratingImdb": 9.4,
                //          "year": 1999,
                //          "type": "VIDEO",
                //          "posterUrl": "https://kinopoiskapiunofficial.tech/images/posters/kp/1252447.jpg",
                //          "posterUrlPreview": "https://kinopoiskapiunofficial.tech/images/posters/kp_small/1252447.jpg"
                //        },
                //        {
                //          "kinopoiskId": 952236,
                //          "imdbId": "tt5223716",
                //          "nameRu": "Hot Wheels. Мегатрасса",
                //          "nameEn": null,
                //          "nameOriginal": "Team Hot Wheels: Build the Epic Race",
                //          "countries": [
                //            {
                //              "country": "США"
                //            }
                //          ],
                //          "genres": [
                //            {
                //              "genre": "мультфильм"
                //            },
                //            {
                //              "genre": "детский"
                //            }
                //          ],
                //          "ratingKinopoisk": 9.3,
                //          "ratingImdb": 6.2,
                //          "year": 2015,
                //          "type": "FILM",
                //          "posterUrl": "https://kinopoiskapiunofficial.tech/images/posters/kp/952236.jpg",
                //          "posterUrlPreview": "https://kinopoiskapiunofficial.tech/images/posters/kp_small/952236.jpg"
                //        },
                //        {
                //          "kinopoiskId": 5493676,
                //          "imdbId": null,
                //          "nameRu": "Лапша и булочка",
                //          "nameEn": null,
                //          "nameOriginal": "Noodle and Bun",
                //          "countries": [
                //            {
                //              "country": "ЮАР"
                //            }
                //          ],
                //          "genres": [
                //            {
                //              "genre": "приключения"
                //            },
                //            {
                //              "genre": "комедия"
                //            },
                //            {
                //              "genre": "мультфильм"
                //            },
                //            {
                //              "genre": "семейный"
                //            }
                //          ],
                //          "ratingKinopoisk": 9.3,
                //          "ratingImdb": 9.2,
                //          "year": 2020,
                //          "type": "TV_SERIES",
                //          "posterUrl": "https://kinopoiskapiunofficial.tech/images/posters/kp/5493676.jpg",
                //          "posterUrlPreview": "https://kinopoiskapiunofficial.tech/images/posters/kp_small/5493676.jpg"
                //        },
                //        {
                //          "kinopoiskId": 962472,
                //          "imdbId": "tt5396486",
                //          "nameRu": "Hot Wheels. За гранью воображения",
                //          "nameEn": null,
                //          "nameOriginal": "Team Hot Wheels: The Skills to Thrill",
                //          "countries": [
                //            {
                //              "country": "США"
                //            }
                //          ],
                //          "genres": [
                //            {
                //              "genre": "мультфильм"
                //            },
                //            {
                //              "genre": "детский"
                //            }
                //          ],
                //          "ratingKinopoisk": 9.3,
                //          "ratingImdb": 6.9,
                //          "year": 2015,
                //          "type": "FILM",
                //          "posterUrl": "https://kinopoiskapiunofficial.tech/images/posters/kp/962472.jpg",
                //          "posterUrlPreview": "https://kinopoiskapiunofficial.tech/images/posters/kp_small/962472.jpg"
                //        },
                //        {
                //          "kinopoiskId": 1072974,
                //          "imdbId": "tt13535142",
                //          "nameRu": "Герои Энвелла",
                //          "nameEn": null,
                //          "nameOriginal": null,
                //          "countries": [
                //            {
                //              "country": "Россия"
                //            }
                //          ],
                //          "genres": [
                //            {
                //              "genre": "фантастика"
                //            },
                //            {
                //              "genre": "мультфильм"
                //            },
                //            {
                //              "genre": "детский"
                //            }
                //          ],
                //          "ratingKinopoisk": 9.3,
                //          "ratingImdb": null,
                //          "year": 2017,
                //          "type": "TV_SERIES",
                //          "posterUrl": "https://kinopoiskapiunofficial.tech/images/posters/kp/1072974.jpg",
                //          "posterUrlPreview": "https://kinopoiskapiunofficial.tech/images/posters/kp_small/1072974.jpg"
                //        },
                //        {
                //          "kinopoiskId": 1309325,
                //          "imdbId": null,
                //          "nameRu": "Космос",
                //          "nameEn": null,
                //          "nameOriginal": "",
                //          "countries": [
                //            {
                //              "country": "США"
                //            }
                //          ],
                //          "genres": [
                //            {
                //              "genre": "документальный"
                //            }
                //          ],
                //          "ratingKinopoisk": 9.3,
                //          "ratingImdb": null,
                //          "year": 2019,
                //          "type": "TV_SERIES",
                //          "posterUrl": "https://kinopoiskapiunofficial.tech/images/posters/kp/1309325.jpg",
                //          "posterUrlPreview": "https://kinopoiskapiunofficial.tech/images/posters/kp_small/1309325.jpg"
                //        },
                //        {
                //          "kinopoiskId": 674243,
                //          "imdbId": null,
                //          "nameRu": "Счастливые люди",
                //          "nameEn": null,
                //          "nameOriginal": null,
                //          "countries": [
                //            {
                //              "country": "Россия"
                //            }
                //          ],
                //          "genres": [
                //            {
                //              "genre": "документальный"
                //            }
                //          ],
                //          "ratingKinopoisk": 9.2,
                //          "ratingImdb": 8.7,
                //          "year": 2008,
                //          "type": "MINI_SERIES",
                //          "posterUrl": "https://kinopoiskapiunofficial.tech/images/posters/kp/674243.jpg",
                //          "posterUrlPreview": "https://kinopoiskapiunofficial.tech/images/posters/kp_small/674243.jpg"
                //        },
                //        {
                //          "kinopoiskId": 1003587,
                //          "imdbId": "tt6146460",
                //          "nameRu": "Гамильтон",
                //          "nameEn": null,
                //          "nameOriginal": "Hamilton's America",
                //          "countries": [
                //            {
                //              "country": "США"
                //            }
                //          ],
                //          "genres": [
                //            {
                //              "genre": "биография"
                //            },
                //            {
                //              "genre": "мюзикл"
                //            }
                //          ],
                //          "ratingKinopoisk": 9.2,
                //          "ratingImdb": 8.3,
                //          "year": 2016,
                //          "type": "FILM",
                //          "posterUrl": "https://kinopoiskapiunofficial.tech/images/posters/kp/1003587.jpg",
                //          "posterUrlPreview": "https://kinopoiskapiunofficial.tech/images/posters/kp_small/1003587.jpg"
                //        },
                //        {
                //          "kinopoiskId": 2500772,
                //          "imdbId": null,
                //          "nameRu": "Жизнь человека. Последнее интервью",
                //          "nameEn": null,
                //          "nameOriginal": null,
                //          "countries": [
                //            {
                //              "country": "Россия"
                //            }
                //          ],
                //          "genres": [
                //            {
                //              "genre": "документальный"
                //            }
                //          ],
                //          "ratingKinopoisk": 9.2,
                //          "ratingImdb": null,
                //          "year": 2020,
                //          "type": "FILM",
                //          "posterUrl": "https://kinopoiskapiunofficial.tech/images/posters/kp/2500772.jpg",
                //          "posterUrlPreview": "https://kinopoiskapiunofficial.tech/images/posters/kp_small/2500772.jpg"
                //        },
                //        {
                //          "kinopoiskId": 5444474,
                //          "imdbId": "tt28703544",
                //          "nameRu": "Шаранутый космос",
                //          "nameEn": null,
                //          "nameOriginal": "SolarBalls",
                //          "countries": [
                //            {
                //              "country": "США"
                //            },
                //            {
                //              "country": "Великобритания"
                //            },
                //            {
                //              "country": "Россия"
                //            }
                //          ],
                //          "genres": [
                //            {
                //              "genre": "драма"
                //            },
                //            {
                //              "genre": "фантастика"
                //            },
                //            {
                //              "genre": "комедия"
                //            },
                //            {
                //              "genre": "мультфильм"
                //            }
                //          ],
                //          "ratingKinopoisk": 9.2,
                //          "ratingImdb": 9.5,
                //          "year": 2022,
                //          "type": "TV_SERIES",
                //          "posterUrl": "https://kinopoiskapiunofficial.tech/images/posters/kp/5444474.jpg",
                //          "posterUrlPreview": "https://kinopoiskapiunofficial.tech/images/posters/kp_small/5444474.jpg"
                //        },
                //        {
                //          "kinopoiskId": 351771,
                //          "imdbId": "tt0276902",
                //          "nameRu": null,
                //          "nameEn": null,
                //          "nameOriginal": "Depeche Mode: Devotional",
                //          "countries": [
                //            {
                //              "country": "Великобритания"
                //            }
                //          ],
                //          "genres": [
                //            {
                //              "genre": "музыка"
                //            },
                //            {
                //              "genre": "документальный"
                //            },
                //            {
                //              "genre": "концерт"
                //            }
                //          ],
                //          "ratingKinopoisk": 9.2,
                //          "ratingImdb": 9.1,
                //          "year": 1993,
                //          "type": "VIDEO",
                //          "posterUrl": "https://kinopoiskapiunofficial.tech/images/posters/kp/351771.jpg",
                //          "posterUrlPreview": "https://kinopoiskapiunofficial.tech/images/posters/kp_small/351771.jpg"
                //        },
                //        {
                //          "kinopoiskId": 1111028,
                //          "imdbId": null,
                //          "nameRu": "Минифорс. Новые герои",
                //          "nameEn": null,
                //          "nameOriginal": "Miniforce: New Heroes Rise",
                //          "countries": [
                //            {
                //              "country": "Корея Южная"
                //            }
                //          ],
                //          "genres": [
                //            {
                //              "genre": "фантастика"
                //            },
                //            {
                //              "genre": "приключения"
                //            },
                //            {
                //              "genre": "мультфильм"
                //            },
                //            {
                //              "genre": "детский"
                //            }
                //          ],
                //          "ratingKinopoisk": 9.2,
                //          "ratingImdb": null,
                //          "year": 2016,
                //          "type": "FILM",
                //          "posterUrl": "https://kinopoiskapiunofficial.tech/images/posters/kp/1111028.jpg",
                //          "posterUrlPreview": "https://kinopoiskapiunofficial.tech/images/posters/kp_small/1111028.jpg"
                //        },
                //        {
                //          "kinopoiskId": 1339977,
                //          "imdbId": null,
                //          "nameRu": "Уровень тревоги: Полночь",
                //          "nameEn": null,
                //          "nameOriginal": "Threat Level Midnight: The Movie",
                //          "countries": [
                //            {
                //              "country": "США"
                //            },
                //            {
                //              "country": "Великобритания"
                //            }
                //          ],
                //          "genres": [
                //            {
                //              "genre": "боевик"
                //            },
                //            {
                //              "genre": "комедия"
                //            },
                //            {
                //              "genre": "короткометражка"
                //            }
                //          ],
                //          "ratingKinopoisk": 9.2,
                //          "ratingImdb": 9.6,
                //          "year": 2011,
                //          "type": "FILM",
                //          "posterUrl": "https://kinopoiskapiunofficial.tech/images/posters/kp/1339977.jpg",
                //          "posterUrlPreview": "https://kinopoiskapiunofficial.tech/images/posters/kp_small/1339977.jpg"
                //        },
                //        {
                //          "kinopoiskId": 45319,
                //          "imdbId": "tt0216434",
                //          "nameRu": "Жил-был пёс",
                //          "nameEn": null,
                //          "nameOriginal": null,
                //          "countries": [
                //            {
                //              "country": "СССР"
                //            }
                //          ],
                //          "genres": [
                //            {
                //              "genre": "комедия"
                //            },
                //            {
                //              "genre": "мультфильм"
                //            },
                //            {
                //              "genre": "семейный"
                //            },
                //            {
                //              "genre": "короткометражка"
                //            }
                //          ],
                //          "ratingKinopoisk": 9.2,
                //          "ratingImdb": 8.4,
                //          "year": 1982,
                //          "type": "FILM",
                //          "posterUrl": "https://kinopoiskapiunofficial.tech/images/posters/kp/45319.jpg",
                //          "posterUrlPreview": "https://kinopoiskapiunofficial.tech/images/posters/kp_small/45319.jpg"
                //        },
                //        {
                //          "kinopoiskId": 77044,
                //          "imdbId": null,
                //          "nameRu": "Друзья",
                //          "nameEn": null,
                //          "nameOriginal": "Friends",
                //          "countries": [
                //            {
                //              "country": "США"
                //            }
                //          ],
                //          "genres": [
                //            {
                //              "genre": "мелодрама"
                //            },
                //            {
                //              "genre": "комедия"
                //            }
                //          ],
                //          "ratingKinopoisk": 9.2,
                //          "ratingImdb": 8.9,
                //          "year": 1994,
                //          "type": "TV_SERIES",
                //          "posterUrl": "https://kinopoiskapiunofficial.tech/images/posters/kp/77044.jpg",
                //          "posterUrlPreview": "https://kinopoiskapiunofficial.tech/images/posters/kp_small/77044.jpg"
                //        },
                //        {
                //          "kinopoiskId": 1399205,
                //          "imdbId": "tt7866314",
                //          "nameRu": null,
                //          "nameEn": null,
                //          "nameOriginal": "BTS: Bon Voyage",
                //          "countries": [
                //            {
                //              "country": "Корея Южная"
                //            }
                //          ],
                //          "genres": [
                //            {
                //              "genre": "реальное ТВ"
                //            }
                //          ],
                //          "ratingKinopoisk": 9.2,
                //          "ratingImdb": 9.4,
                //          "year": 2016,
                //          "type": "TV_SHOW",
                //          "posterUrl": "https://kinopoiskapiunofficial.tech/images/posters/kp/1399205.jpg",
                //          "posterUrlPreview": "https://kinopoiskapiunofficial.tech/images/posters/kp_small/1399205.jpg"
                //        },
                //        {
                //          "kinopoiskId": 1007472,
                //          "imdbId": null,
                //          "nameRu": "Планета Земля 2",
                //          "nameEn": null,
                //          "nameOriginal": "Planet Earth II",
                //          "countries": [
                //            {
                //              "country": "США"
                //            },
                //            {
                //              "country": "Франция"
                //            },
                //            {
                //              "country": "Великобритания"
                //            },
                //            {
                //              "country": "Германия"
                //            },
                //            {
                //              "country": "Китай"
                //            }
                //          ],
                //          "genres": [
                //            {
                //              "genre": "документальный"
                //            }
                //          ],
                //          "ratingKinopoisk": 9.2,
                //          "ratingImdb": 9.5,
                //          "year": 2016,
                //          "type": "MINI_SERIES",
                //          "posterUrl": "https://kinopoiskapiunofficial.tech/images/posters/kp/1007472.jpg",
                //          "posterUrlPreview": "https://kinopoiskapiunofficial.tech/images/posters/kp_small/1007472.jpg"
                //        },
                //        {
                //          "kinopoiskId": 1043658,
                //          "imdbId": null,
                //          "nameRu": "Шоу Грязного Фрэнка",
                //          "nameEn": null,
                //          "nameOriginal": "The Filthy Frank Show",
                //          "countries": [
                //            {
                //              "country": "США"
                //            },
                //            {
                //              "country": "Австралия"
                //            },
                //            {
                //              "country": "Япония"
                //            }
                //          ],
                //          "genres": [
                //            {
                //              "genre": "комедия"
                //            },
                //            {
                //              "genre": "короткометражка"
                //            }
                //          ],
                //          "ratingKinopoisk": 9.2,
                //          "ratingImdb": 9.2,
                //          "year": 2011,
                //          "type": "TV_SERIES",
                //          "posterUrl": "https://kinopoiskapiunofficial.tech/images/posters/kp/1043658.jpg",
                //          "posterUrlPreview": "https://kinopoiskapiunofficial.tech/images/posters/kp_small/1043658.jpg"
                //        }
                //      ]
                //    """);
                var seedMovies = new List<Movie>();
                seedMovies.Add(new Movie()
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
                    Type = FilmType.MINI_SERIES,
                    PosterUrl = "https://kinopoiskapiunofficial.tech/images/posters/kp/5493676.jpg",
                    PosterUrlPreview = "https://kinopoiskapiunofficial.tech/images/posters/kp_small/5493676.jpg"
                }
);
                foreach (var movie in seedMovies)
                {
                    Movies.Add(movie);
                }
            }

        }

        // Runtime constructor
        public HomeViewModel(IMovieService movieService) : this()
        {
            _movieService = movieService;

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
    }

}


