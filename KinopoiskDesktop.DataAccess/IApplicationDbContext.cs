using KinopoiskDesktop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskDesktop.DataAccess
{
    public interface IApplicationDbContext
    {
        DbContext DbContext { get; }
        DbSet<AppUserMovie> AppUsersMovies { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<MovieCountry> MoviesCountries { get; set; }
        DbSet<MovieGenre> MoviesGenres { get; set; }
        DbSet<AppUser> AppUsers { get; set; }

    }
}
