using KinopoiskDesktop.App.Services.IService;
using KinopoiskDesktop.Domain.Enums;
using KinopoiskDesktop.Domain.Managers;
using KinopoiskDesktop.Domain.Models;
using KinopoiskDesktop.Domain.SearchFilters;


namespace KinopoiskDesktop.App.Services
{
    public class MovieService : IMovieService
    {
        private readonly Integrations.KinopoiskUnofficialApi.IKinopoiskClient _kinopoiskApiClient;
        private readonly IMovieManager _movieManager;
        private Dictionary<string, Country> _countryDictionary = new Dictionary<string, Country>();
        private Dictionary<string, Genre> _genreDictionary = new Dictionary<string, Genre>();
        private bool IsSynced = false;


        public MovieService(Integrations.KinopoiskUnofficialApi.IKinopoiskClient kinopoiskApiClient, IMovieManager movieManager)
        {
            _kinopoiskApiClient = kinopoiskApiClient;
            _movieManager = movieManager;
            var sync = SyncWithApiAsync();
        }

        public async Task<IEnumerable<AppUserMovie>> GetMoviesByFilterAsync(MovieFilter? filter = null)
        {
            IEnumerable<AppUserMovie> userMovies = null;
            try
            {
                userMovies = await _movieManager.GetUserMoviesByFilter(filter);
            }
            catch (Exception)
            {

            }

            if (userMovies == null || userMovies.Count()<filter?.PageSize || userMovies.Any(x => (DateTime.UtcNow - x.Movie.SyncedAt) > x.Movie.SyncPeriod))
            {
                try
                {
                    var response = await _kinopoiskApiClient.Films2(filter?.Countries,
                                                                    filter?.Genres,
                                                                    (Integrations.KinopoiskUnofficialApi.Order2?)filter?.Order,
                                                                    (Integrations.KinopoiskUnofficialApi.Type3?)filter?.Type,
                                                                    filter?.RatingFrom,
                                                                    filter?.RatingTo,
                                                                    filter?.YearFrom,
                                                                    filter?.YearTo,
                                                                    filter?.ImdbId,
                                                                    filter?.Keyword,
                                                                    filter?.Page);

                    IEnumerable<Movie>? searchResult = response.Items.Select(x => new Movie
                    {
                        KinopoiskId = x.KinopoiskId,
                        ImdbId = x.ImdbId,
                        NameRu = x.NameRu,
                        NameEn = x.NameEn,
                        NameOriginal = x.NameOriginal,
                        Countries = x.Countries.Select(c=> new MovieCountry { Country = _countryDictionary.GetValueOrDefault(c.Country1)}).ToList(),
                        Genres = x.Genres.Select(c=> new MovieGenre { Genre = _genreDictionary.GetValueOrDefault(c.Genre1)}).ToList(),
                        RatingKinopoisk = x.RatingKinopoisk,
                        RatingImdb = x.RatingImdb,
                        Year = x.Year as int?,
                        Type = (FilmType)(int)x.Type,
                        PosterUrl = x.PosterUrl,
                        PosterUrlPreview = x.PosterUrlPreview,
                    });
                    await _movieManager.SyncMoviesWithApiAsync(searchResult);
                    userMovies = await _movieManager.GetUserMoviesForApi(searchResult);

                }
                catch (Exception)
                {
                    // Log the exception
                }
            }

            return userMovies;
        }

        public async Task SyncWithApiAsync()
        {
            if(IsSynced)
            {
                return;
            }
            try
            {
                var response = await _kinopoiskApiClient.Filters();
                IEnumerable<Country>? apiCountries = response.Countries.Select(x => new Country
                {
                    Id = x.Id,
                    Name = x.Country
                });
                IEnumerable<Genre>? apiGenres = response.Genres.Select(x => new Genre
                {
                    Id = x.Id,
                    Name = x.Genre
                });

                await _movieManager.SyncWithApiAsync<Country, int>(apiCountries);
                await _movieManager.SyncWithApiAsync<Genre, int>(apiGenres);

                _countryDictionary = _movieManager.GetCountries().ToDictionary(x => x.Name);
                _genreDictionary = _movieManager.GetGenres().ToDictionary(x => x.Name);

                IsSynced = true;
            }
            catch (Exception)
            {
                // Log the exception
            }
        }


        public async Task<IEnumerable<AppUserMovie>> GetFavoritesByFilterAsync(MovieFilter? filter)
        {
            return await _movieManager.GetUserMoviesByFilter(filter);
        }

        public async Task<IEnumerable<AppUserMovie>> GetWatchedMoviesAsync()
        {
            return await _movieManager.GetWatchedMoviesAsync();
        }

        public async Task<bool> ToggleFavoriteAsync(AppUserMovie movie)
        {
            movie.IsFavorite = !movie.IsFavorite;
            return await _movieManager.ToggleFavoriteAsync(movie);
        }


        public async Task<bool> ToggleWatchedAsync(AppUserMovie movie)
        {
            movie.IsWatched = !movie.IsWatched;
            return await _movieManager.ToggleWatchedAsync(movie);
        }


        public async Task RateMovieAsync(AppUserMovie movie)
        {
            await _movieManager.RateMovieAsync(movie);
        }


        public List<Country> GetCountries()
        {
            return _countryDictionary.Values.ToList();
        }

        public List<Genre> GetGenres()
        {
            return _genreDictionary.Values.ToList();
        }
    }
}
