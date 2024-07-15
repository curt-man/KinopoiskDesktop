using KinopoiskDesktop.DataAccess;
using KinopoiskDesktop.Domain.Enums;
using KinopoiskDesktop.Domain.IManagers;
using KinopoiskDesktop.Domain.Managers;
using KinopoiskDesktop.Domain.Models;
using KinopoiskDesktop.Domain.SearchFilters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskDesktop.DomainImplementation.Managers
{
    public class MovieManager : IMovieManager
    {
        private readonly IApplicationDbContext _context;

        public MovieManager(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AppUserMovie>> GetFavoritesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AppUserMovie> GetMovieByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AppUserMovie> GetMovieByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppUserMovie>> GetMoviesAsync(IEnumerable<Movie> apiMovies, Guid userId)
        {
            var existingMovies = _context.Movies.Where(x => apiMovies.Contains(x)).Include(x => x.MovieAppUsers.Where(x => x.AppUserId == userId));

            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppUserMovie>> GetMoviesAsync(IEnumerable<Movie> apiMovies)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppUserMovie>> GetWatchedMoviesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task MarkAsFavoriteAsync(AppUserMovie movie)
        {
            throw new NotImplementedException();
        }

        public async Task MarkAsWatchedAsync(AppUserMovie movie)
        {
            throw new NotImplementedException();
        }

        public async Task RateMovieAsync(AppUserMovie movie)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveFromFavoritesAsync(AppUserMovie movie)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveFromWatchedAsync(AppUserMovie movie)
        {
            throw new NotImplementedException();
        }



        public async Task SyncWithApiAsync<TEntity, TId>(IEnumerable<TEntity> apiEntities)
            where TEntity : BaseEntity<TId>, ISyncableEntity<TId>
        {
            var apiEntitiesIds = apiEntities.Select(e => e.SyncProperty).ToList();

            var existingEntities = await _context.DbContext.Set<TEntity>()
                .ToListAsync();

            var existingEntityDict = existingEntities
                .Where(e => apiEntitiesIds.Contains(e.SyncProperty))
                .ToDictionary(e => e.SyncProperty);

            var entitiesToUpdate = new List<TEntity>();
            var entitiesToInsert = new List<TEntity>();

            foreach (var apiEntity in apiEntities)
            {
                apiEntity.SyncedAt = DateTime.UtcNow;
                apiEntity.SyncPeriod = TimeSpan.FromMinutes(60);

                if (existingEntityDict.TryGetValue(apiEntity.SyncProperty, out var existingEntity))
                {
                    existingEntity.UpdatedAt = DateTime.UtcNow;
                    entitiesToUpdate.Add(existingEntity);
                }
                else
                {
                    apiEntity.CreatedAt = DateTime.UtcNow;
                    entitiesToInsert.Add(apiEntity);
                }
            }

            _context.DbContext.Set<TEntity>().UpdateRange(entitiesToUpdate);
            _context.DbContext.Set<TEntity>().AddRange(entitiesToInsert);

            await _context.DbContext.SaveChangesAsync();
        }

        public async Task SyncMoviesWithApiAsync(IEnumerable<Movie> apiMovies)
        {
            var apiMovieIds = apiMovies.Select(m => m.KinopoiskId).ToList();

            var existingMovies = await _context.Movies
                .Where(m => apiMovieIds.Contains(m.KinopoiskId))
                .ToListAsync();

            var existingMovieDict = existingMovies.ToDictionary(m => m.KinopoiskId);

            var moviesToUpdate = new List<Movie>();
            var moviesToInsert = new List<Movie>();

            foreach (var apiMovie in apiMovies)
            {
                if (existingMovieDict.TryGetValue(apiMovie.KinopoiskId, out var existingMovie))
                {
                    existingMovie.UpdatedAt = DateTime.UtcNow;
                    existingMovie.SyncedAt = DateTime.UtcNow;
                    existingMovie.SyncPeriod = TimeSpan.FromMinutes(3);
                    moviesToUpdate.Add(existingMovie);
                }
                else
                {
                    apiMovie.SyncedAt = DateTime.UtcNow;
                    apiMovie.SyncPeriod = TimeSpan.FromMinutes(3);
                    apiMovie.CreatedAt = DateTime.UtcNow;
                    moviesToInsert.Add(apiMovie);
                }
            }

            _context.Movies.UpdateRange(moviesToUpdate);
            _context.Movies.AddRange(moviesToInsert);

            await _context.DbContext.SaveChangesAsync();

        }

        public List<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public List<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }
    }
}
