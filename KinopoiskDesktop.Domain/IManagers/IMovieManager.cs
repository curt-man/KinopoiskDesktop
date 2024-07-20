using KinopoiskDesktop.Domain.Models;
using KinopoiskDesktop.Domain.SearchFilters;

namespace KinopoiskDesktop.Domain.Managers
{
    public interface IMovieManager
    {
        /// <summary>
        /// Get user movies information for the given API movies
        /// </summary>
        /// <param name="apiMovies">List of movies that came from API</param>
        /// <returns>List of movies with user information attached</returns>
        Task<IEnumerable<AppUserMovie>> GetUserMoviesForApi(IEnumerable<Movie> apiMovies);

        /// <summary>
        /// Get user movies by filter
        /// </summary>
        /// <param name="filter">Movie filter</param>
        /// <returns></returns>
        Task<IEnumerable<AppUserMovie>> GetUserMoviesByFilter(MovieFilter filter);

        Task<bool> ToggleFavoriteAsync(AppUserMovie movie);
        Task<IEnumerable<AppUserMovie>> GetFavoritesAsync();

        Task<bool> ToggleWatchedAsync(AppUserMovie movie);
        Task<IEnumerable<AppUserMovie>> GetWatchedMoviesAsync();

        Task RateMovieAsync(AppUserMovie movie);

        /// <summary>
        /// Synchronize movies information in local database with API
        /// </summary>
        /// <param name="apiMovies">List of movies that came from API</param>
        /// <returns></returns>
        Task SyncMoviesWithApiAsync(IEnumerable<Movie> apiMovies);

        /// <summary>
        /// Synchronize information in local database with API
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TId"></typeparam>
        /// <param name="apiEntity">List of API entities</param>
        /// <returns></returns>
        Task SyncWithApiAsync<TEntity, TId>(IEnumerable<TEntity> apiEntity) where TEntity : EntityBase<TId>, ISyncableEntity<TId>;

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
