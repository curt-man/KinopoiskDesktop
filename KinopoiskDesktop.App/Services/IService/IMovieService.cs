using KinopoiskDesktop.Domain.Models;
using KinopoiskDesktop.Domain.SearchFilters;

namespace KinopoiskDesktop.App.Services.IService
{
    /// <summary>
    /// Service for managing movies, ratings, and user preferences
    /// </summary>
    public interface IMovieService
    {
        /// <summary>
        /// Get user movies by filter
        /// </summary>
        /// <param name="filter">Movie filter</param>
        /// <returns></returns>
        Task<IEnumerable<AppUserMovie>> GetMoviesByFilterAsync(MovieFilter? filter = null);

        Task AddToFavoritesAsync(AppUserMovie movie);
        Task RemoveFromFavoritesAsync(AppUserMovie movie);
        Task<IEnumerable<AppUserMovie>> GetFavoritesByFilterAsync(MovieFilter? filter = null);

        Task MarkAsWatchedAsync(AppUserMovie movie);
        Task MarkAsUnwatchedAsync(AppUserMovie movie);
        Task<IEnumerable<AppUserMovie>> GetWatchedMoviesAsync();

        Task RateMovieAsync(AppUserMovie movie);

        /// <summary>
        /// Synchronize information in local database with API
        /// </summary>
        /// <returns></returns>
        Task SyncWithApiAsync();

        /// <summary>
        /// Get all countries
        /// </summary>
        /// <returns></returns>
        List<Country> GetCountries();

        /// <summary>
        /// Get all genres
        /// </summary>
        /// <returns></returns>
        List<Genre> GetGenres();

    }
}
