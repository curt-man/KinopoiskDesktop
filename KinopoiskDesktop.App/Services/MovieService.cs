using KinopoiskDesktop.App.Services.IService;
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

        public MovieService(IKinopoiskClient kinopoiskApiClient)
        {
            _kinopoiskApiClient = kinopoiskApiClient;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            var response = await _kinopoiskApiClient.Films2([1], [1], null, null, null, null, null, null, null, null, null);
            var movies = response.Items.Select(x => new Movie
            {
                KinopoiskId = x.KinopoiskId,
                NameRu = x.NameRu,
                NameEn = x.NameEn,
                Year = x.Year as int?,
                PosterUrl = x.PosterUrl,
                RatingKinopoisk = x.RatingKinopoisk,
                Genres = x.Genres.Select(g => new Domain.Models.Genre { Name = g.Genre1 }).ToList()
            });

            return movies;
        }

        public Task<Movie> GetMovieByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
