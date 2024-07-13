using KinopoiskDesktop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskDesktop.DataAccess
{
    public class KinopoiskDbContext : DbContext
    {
        public KinopoiskDbContext(DbContextOptions<KinopoiskDbContext> options) : base(options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<MovieGenre> MoviesGenres { get; set; }
        public DbSet<MovieCountry> MoviesCountries { get; set; }
        public DbSet<AppUserMovie> AppUsersMovies { get; set; }



        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }

}
