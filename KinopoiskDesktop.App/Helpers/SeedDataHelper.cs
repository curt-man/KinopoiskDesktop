using KinopoiskDesktop.Domain.Enums;
using KinopoiskDesktop.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskDesktop.App.Helpers
{
    public static class SeedDataHelper
    {
        
        public static List<AppUserMovie>? InitializeDesignTimeMovies()
        {
            List<AppUserMovie> seedMovies = null;
            
                seedMovies = new List<AppUserMovie>()
                {
                    new AppUserMovie()
                    {
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
                            Countries = new List<MovieCountry> { new MovieCountry { Country = new Country { Name = "Россия" } }},
                            Genres = new List<MovieGenre> { new MovieGenre { Genre = new Genre { Name = "музыка" } }},
                            RatingKinopoisk = 9.4,
                            RatingImdb = null,
                            Year = 2022,
                            Type = FilmType.TV_SERIES,
                            PosterUrl = "https://kinopoiskapiunofficial.tech/images/posters/kp/5260016.jpg",
                            PosterUrlPreview = "https://kinopoiskapiunofficial.tech/images/posters/kp_small/5260016.jpg"
                        },
                    },
                    new AppUserMovie
                    {
                        IsFavorite = false,
                        IsWatched = false,
                        Rating = null,
                        Movie = new Movie
                        {
                            KinopoiskId = 1201206,
                            ImdbId = null,
                            NameRu = null,
                            NameEn = null,
                            NameOriginal = "BTS: Blood Sweat & Tears",
                            Countries = new List<MovieCountry> { new MovieCountry { Country = new Country { Name = "Россия" } }},

                            Genres = new List<MovieGenre> {
                                new MovieGenre
                                {
                                    Genre = new Genre { Name = "музыка" },
                                },
                                new MovieGenre
                                {
                                    Genre = new Genre { Name = "короткометражка" }
                                }
                            },
                            RatingKinopoisk = 9.4,
                            RatingImdb = null,
                            Year = 2016,
                            Type = FilmType.VIDEO,
                            PosterUrl = "https://kinopoiskapiunofficial.tech/images/posters/kp/1201206.jpg",
                            PosterUrlPreview = "https://kinopoiskapiunofficial.tech/images/posters/kp_small/1201206.jpg"
                        }
                    },
                    new AppUserMovie
                    {
                        IsFavorite = false,
                        IsWatched = false,
                        Rating = null,
                        Movie = new Movie
                        {
                            KinopoiskId = 952236,
                            ImdbId = "tt5223716",
                            NameRu = "Hot Wheels. Мегатрасса",
                            NameEn = null,
                            NameOriginal = "Team Hot Wheels: Build the Epic Race",
                            Countries = new List<MovieCountry>
                            {
                                new MovieCountry { Country = new Country { Name = "США" } }
                            },
                            Genres = new List<MovieGenre>
                            {
                                new MovieGenre { Genre = new Genre { Name = "мультфильм" } },
                                new MovieGenre { Genre = new Genre { Name = "детский" } }
                            },
                            RatingKinopoisk = 9.3,
                            RatingImdb = 6.2,
                            Year = 2015,
                            Type = FilmType.FILM,
                            PosterUrl = "https://kinopoiskapiunofficial.tech/images/posters/kp/952236.jpg",
                            PosterUrlPreview = "https://kinopoiskapiunofficial.tech/images/posters/kp_small/952236.jpg"
                        }
                    },
                    new AppUserMovie
                    {
                        IsFavorite = false,
                        IsWatched = true,
                        Rating = null,
                        Movie = new Movie
                        {
                            KinopoiskId = 5493676,
                            ImdbId = null,
                            NameRu = "Лапша и булочка",
                            NameEn = null,
                            NameOriginal = "Noodle and Bun",
                            Countries = new List<MovieCountry>
                            {
                                new MovieCountry { Country = new Country { Name = "ЮАР" } }
                            },
                            Genres = new List<MovieGenre>
                            {
                                new MovieGenre { Genre = new Genre { Name = "приключения" } },
                                new MovieGenre { Genre = new Genre { Name = "комедия" } },
                                new MovieGenre { Genre = new Genre { Name = "мультфильм" } },
                                new MovieGenre { Genre = new Genre { Name = "семейный" } }
                            },
                            RatingKinopoisk = 9.3,
                            RatingImdb = 9.2,
                            Year = 2020,
                            Type = FilmType.TV_SERIES,
                            PosterUrl = "https://kinopoiskapiunofficial.tech/images/posters/kp/5493676.jpg",
                            PosterUrlPreview = "https://kinopoiskapiunofficial.tech/images/posters/kp_small/5493676.jpg"
                        }
                    },
                    new AppUserMovie
                    {
                        IsFavorite = false,
                        IsWatched = true,
                        Rating = null,
                        Movie = new Movie
                        {
                            KinopoiskId = 962472,
                            ImdbId = "tt5396486",
                            NameRu = "Hot Wheels. За гранью воображения",
                            NameEn = null,
                            NameOriginal = "Team Hot Wheels: The Skills to Thrill",
                            Countries = new List<MovieCountry>
                            {
                                new MovieCountry { Country = new Country { Name = "США" } }
                            },
                            Genres = new List<MovieGenre>
                            {
                                new MovieGenre { Genre = new Genre { Name = "мультфильм" } },
                                new MovieGenre { Genre = new Genre { Name = "детский" } }
                            },
                            RatingKinopoisk = 9.3,
                            RatingImdb = 6.9,
                            Year = 2015,
                            Type = FilmType.FILM,
                            PosterUrl = "https://kinopoiskapiunofficial.tech/images/posters/kp/962472.jpg",
                            PosterUrlPreview = "https://kinopoiskapiunofficial.tech/images/posters/kp_small/962472.jpg"
                        }
                    },
                    new AppUserMovie
                    {
                        IsFavorite = true,
                        IsWatched = true,
                        Rating = 7,
                        Movie = new Movie
                        {
                            KinopoiskId = 1072974,
                            ImdbId = "tt13535142",
                            NameRu = "Герои Энвелла",
                            NameEn = null,
                            NameOriginal = null,
                            Countries = new List<MovieCountry>
                            {
                                new MovieCountry { Country = new Country { Name = "Россия" } }
                            },
                            Genres = new List<MovieGenre>
                            {
                                new MovieGenre { Genre = new Genre { Name = "фантастика" } },
                                new MovieGenre { Genre = new Genre { Name = "мультфильм" } },
                                new MovieGenre { Genre = new Genre { Name = "детский" } }
                            },
                            RatingKinopoisk = 9.3,
                            RatingImdb = null,
                            Year = 2017,
                            Type = FilmType.TV_SERIES,
                            PosterUrl = "https://kinopoiskapiunofficial.tech/images/posters/kp/1072974.jpg",
                            PosterUrlPreview = "https://kinopoiskapiunofficial.tech/images/posters/kp_small/1072974.jpg"
                        }
                    },
                    new AppUserMovie
                    {
                        IsFavorite = false,
                        IsWatched = true,
                        Rating = 5,
                        Movie = new Movie
                        {
                            KinopoiskId = 1309325,
                            ImdbId = null,
                            NameRu = "Космос",
                            NameEn = null,
                            NameOriginal = "",
                            Countries = new List<MovieCountry>
                            {
                                new MovieCountry { Country = new Country { Name = "США" } }
                            },
                            Genres = new List<MovieGenre>
                            {
                                new MovieGenre { Genre = new Genre { Name = "документальный" } }
                            },
                            RatingKinopoisk = 9.3,
                            RatingImdb = null,
                            Year = 2019,
                            Type = FilmType.TV_SERIES,
                            PosterUrl = "https://kinopoiskapiunofficial.tech/images/posters/kp/1309325.jpg",
                            PosterUrlPreview = "https://kinopoiskapiunofficial.tech/images/posters/kp_small/1309325.jpg"
                        }
                    },
                    new AppUserMovie
                    {
                        IsFavorite = false,
                        IsWatched = false,
                        Rating = null,
                        Movie = new Movie
                        {
                            KinopoiskId = 674243,
                            ImdbId = null,
                            NameRu = "Счастливые люди",
                            NameEn = null,
                            NameOriginal = null,
                            Countries = new List<MovieCountry>
                            {
                                new MovieCountry { Country = new Country { Name = "Россия" } }
                            },
                            Genres = new List<MovieGenre>
                            {
                                new MovieGenre { Genre = new Genre { Name = "документальный" } }
                            },
                            RatingKinopoisk = 9.2,
                            RatingImdb = 8.7,
                            Year = 2008,
                            Type = FilmType.MINI_SERIES,
                            PosterUrl = "https://kinopoiskapiunofficial.tech/images/posters/kp/674243.jpg",
                            PosterUrlPreview = "https://kinopoiskapiunofficial.tech/images/posters/kp_small/674243.jpg"
                        }
                    },
                    new AppUserMovie
                    {
                        IsFavorite = false,
                        IsWatched = true,
                        Rating = 1,
                        Movie = new Movie
                        {
                            KinopoiskId = 1003587,
                            ImdbId = "tt6146460",
                            NameRu = "Гамильтон",
                            NameEn = null,
                            NameOriginal = "Hamilton's America",
                            Countries = new List<MovieCountry>
                            {
                                new MovieCountry { Country = new Country { Name = "США" } }
                            },
                            Genres = new List<MovieGenre>
                            {
                                new MovieGenre { Genre = new Genre { Name = "биография" } },
                                new MovieGenre { Genre = new Genre { Name = "мюзикл" } }
                            },
                            RatingKinopoisk = 9.2,
                            RatingImdb = 8.3,
                            Year = 2016,
                            Type = FilmType.FILM,
                            PosterUrl = "https://kinopoiskapiunofficial.tech/images/posters/kp/1003587.jpg",
                            PosterUrlPreview = "https://kinopoiskapiunofficial.tech/images/posters/kp_small/1003587.jpg"
                        }
                    },
                    new AppUserMovie
                    {
                        IsFavorite = false,
                        IsWatched = false,
                        Rating = null,
                        Movie = new Movie
                        {
                            KinopoiskId = 1201206,
                            ImdbId = null,
                            NameRu = null,
                            NameEn = null,
                            NameOriginal = "BTS: Blood Sweat & Tears",
                            Countries = new List<MovieCountry>
                            {
                                new MovieCountry { Country = new Country { Name = "Россия" } }
                            },
                            Genres = new List<MovieGenre>
                            {
                                new MovieGenre { Genre = new Genre { Name = "музыка" } },
                                new MovieGenre { Genre = new Genre { Name = "короткометражка" } }
                            },
                            RatingKinopoisk = 9.4,
                            RatingImdb = null,
                            Year = 2016,
                            Type = FilmType.VIDEO,
                            PosterUrl = "https://kinopoiskapiunofficial.tech/images/posters/kp/1201206.jpg",
                            PosterUrlPreview = "https://kinopoiskapiunofficial.tech/images/posters/kp_small/1201206.jpg"
                        }
                    }
                };

            return seedMovies;
        }
    }
}
