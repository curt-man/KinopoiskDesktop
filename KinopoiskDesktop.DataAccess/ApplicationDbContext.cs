using KinopoiskDesktop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KinopoiskDesktop.DataAccess
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<MovieGenre> MoviesGenres { get; set; }
        public DbSet<MovieCountry> MoviesCountries { get; set; }
        public DbSet<AppUserMovie> AppUsersMovies { get; set; }

        public DbContext DbContext => this;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }

}
