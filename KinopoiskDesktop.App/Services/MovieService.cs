using KinopoiskDesktop.App.Services.IService;
using KinopoiskDesktop.Domain.Enums;
using KinopoiskDesktop.Domain.Managers;
using KinopoiskDesktop.Domain.Models;
using KinopoiskDesktop.Integrations.KinopoiskUnofficialApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KinopoiskDesktop.App.Services
{
    public class MovieService : IMovieService
    {
        private readonly IKinopoiskClient _kinopoiskApiClient;
        private readonly IMovieManager _movieManager;

        public MovieService(IKinopoiskClient kinopoiskApiClient, IMovieManager movieManager)
        {
            _kinopoiskApiClient = kinopoiskApiClient;
            _movieManager = movieManager;
        }

        public async Task<IEnumerable<AppUserMovie>> GetAllMoviesAsync()
        {
            var response = await _kinopoiskApiClient.Films2([1], [1], null, null, null, null, null, null, null, null, null);
            var apiMovies = response.Items.Select(x => new AppUserMovie()
            {
                IsWatched = true,
                Rating = 4.6,
                Movie = new Movie
                {
                    KinopoiskId = x.KinopoiskId,
                    ImdbId = x.ImdbId,
                    NameRu = x.NameRu,
                    NameEn = x.NameEn,
                    NameOriginal = x.NameOriginal,
                    Countries = x.Countries.Select(c => new Domain.Models.Country { Name = c.Country1 }).ToList(),
                    Genres = x.Genres.Select(g => new Domain.Models.Genre { Name = g.Genre1 }).ToList(),
                    RatingKinopoisk = x.RatingKinopoisk,
                    RatingImdb = x.RatingImdb,
                    Year = x.Year as int?,
                    Type = (Domain.Enums.FilmType)(int)x.Type,
                    PosterUrl = x.PosterUrl,
                    PosterUrlPreview = x.PosterUrlPreview,
                }
            }).ToList();

            //await _movieManager.SyncMoviesWithApiAsync(apiMovies);
            //var movies = await _movieManager.GetMoviesAsync(apiMovies);

            return apiMovies;
        }

        public Task<IEnumerable<AppUserMovie>> GetFavoritesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AppUserMovie> GetMovieByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AppUserMovie> GetMovieByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppUserMovie>> GetWatchedMoviesAsync()
        {
            throw new NotImplementedException();
        }

        public Task MarkAsFavoriteAsync(AppUserMovie movie)
        {
            throw new NotImplementedException();
        }

        public Task MarkAsWatchedAsync(AppUserMovie movie)
        {
            throw new NotImplementedException();
        }

        public Task RateMovieAsync(AppUserMovie movie)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromFavoritesAsync(AppUserMovie movie)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromWatchedAsync(AppUserMovie movie)
        {
            throw new NotImplementedException();
        }
    }
}
