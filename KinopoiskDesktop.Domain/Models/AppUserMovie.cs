using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KinopoiskDesktop.Domain.Models
{
    /// <summary>
    /// Represents a many-to-many relationship between an application user and a movie.
    /// </summary>
    [PrimaryKey(nameof(AppUserId), nameof(MovieId))]
    public class AppUserMovie
    {
        /// <summary>
        /// The ID of the user.
        /// </summary>
        [Required]
        public Guid AppUserId { get; set; }

        /// <summary>
        /// The user associated with the movie.
        /// </summary>
        public AppUser? AppUser { get; set; }

        /// <summary>
        /// The ID of the movie.
        /// </summary>
        [Required]
        public int MovieId { get; set; }

        /// <summary>
        /// The movie associated with the user.
        /// </summary>
        public Movie? Movie { get; set; }

        /// <summary>
        /// Indicates whether the movie is marked as a favorite.
        /// </summary>
        public bool IsFavorite { get; set; } = false;

        /// <summary>
        /// Indicates whether the movie has been watched.
        /// </summary>
        public bool IsWatched { get; set; } = false;

        /// <summary>
        /// The rating given to the movie by the user.
        /// </summary>
        public double? Rating { get; set; }
    }
}
