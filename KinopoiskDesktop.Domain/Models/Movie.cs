using System.ComponentModel.DataAnnotations.Schema;
using KinopoiskDesktop.Domain.Enums;

namespace KinopoiskDesktop.Domain.Models
{
    /// <summary>
    /// Represents a movie entity with various attributes and relationships.
    /// </summary>
    public class Movie : BaseEntity<int>, ISyncableEntity<int>
    {
        /// <summary>
        /// The Kinopoisk ID of the movie.
        /// </summary>
        public int KinopoiskId { get; set; }

        /// <summary>
        /// The Kinopoisk HD ID of the movie.
        /// </summary>
        public string? KinopoiskHDId { get; set; }

        /// <summary>
        /// The IMDb ID of the movie.
        /// </summary>
        public string? ImdbId { get; set; }

        /// <summary>
        /// The Russian name of the movie.
        /// </summary>
        public string? NameRu { get; set; }

        /// <summary>
        /// The English name of the movie.
        /// </summary>
        public string? NameEn { get; set; }

        /// <summary>
        /// The original name of the movie.
        /// </summary>
        public string? NameOriginal { get; set; }

        /// <summary>
        /// The URL of the movie's poster.
        /// </summary>
        public string? PosterUrl { get; set; }

        /// <summary>
        /// The URL of the movie's poster preview.
        /// </summary>
        public string? PosterUrlPreview { get; set; }

        /// <summary>
        /// The URL of the movie's cover image.
        /// </summary>
        public string? CoverUrl { get; set; }

        /// <summary>
        /// The URL of the movie's logo image.
        /// </summary>
        public string? LogoUrl { get; set; }

        /// <summary>
        /// The number of reviews for the movie.
        /// </summary>
        public int ReviewsCount { get; set; }

        /// <summary>
        /// The Kinopoisk rating of the movie.
        /// </summary>
        public double? RatingKinopoisk { get; set; }

        /// <summary>
        /// The number of votes for the Kinopoisk rating.
        /// </summary>
        public int? RatingKinopoiskVoteCount { get; set; }

        /// <summary>
        /// The IMDb rating of the movie.
        /// </summary>
        public double? RatingImdb { get; set; }

        /// <summary>
        /// The number of votes for the IMDb rating.
        /// </summary>
        public int? RatingImdbVoteCount { get; set; }

        /// <summary>
        /// The rating given by film critics.
        /// </summary>
        public double? RatingFilmCritics { get; set; }

        /// <summary>
        /// The number of votes for the film critics' rating.
        /// </summary>
        public int? RatingFilmCriticsVoteCount { get; set; }

        /// <summary>
        /// The web URL for the movie.
        /// </summary>
        public string? WebUrl { get; set; }

        /// <summary>
        /// The release year of the movie.
        /// </summary>
        public int? Year { get; set; }

        /// <summary>
        /// The length of the film in minutes.
        /// </summary>
        public int? FilmLength { get; set; }

        /// <summary>
        /// The slogan of the movie.
        /// </summary>
        public string? Slogan { get; set; }

        /// <summary>
        /// The description of the movie.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The short description of the movie.
        /// </summary>
        public string? ShortDescription { get; set; }

        /// <summary>
        /// The editor's annotation for the movie.
        /// </summary>
        public string? EditorAnnotation { get; set; }

        /// <summary>
        /// The production status of the film.
        /// </summary>
        public FilmProductionStatus? ProductionStatus { get; set; }

        /// <summary>
        /// The type of the film.
        /// </summary>
        public FilmType? Type { get; set; }

        /// <summary>
        /// The MPAA rating of the movie.
        /// </summary>
        public string? RatingMpaa { get; set; }

        /// <summary>
        /// The age rating of the movie.
        /// </summary>
        public string? RatingAgeLimits { get; set; }

        /// <summary>
        /// The start year of the movie (for series).
        /// </summary>
        public int? StartYear { get; set; }

        /// <summary>
        /// The end year of the movie (for series).
        /// </summary>
        public int? EndYear { get; set; }

        /// <summary>
        /// Indicates if the movie is a serial.
        /// </summary>
        public bool? Serial { get; set; }

        /// <summary>
        /// Indicates if the movie is a short film.
        /// </summary>
        public bool? ShortFilm { get; set; }

        /// <summary>
        /// Indicates if the movie is completed.
        /// </summary>
        public bool? Completed { get; set; }

        /// <summary>
        /// The last synchronization date and time.
        /// </summary>
        public DateTime? SyncedAt { get; set; }

        /// <summary>
        /// The synchronization period.
        /// </summary>
        public TimeSpan? SyncPeriod { get; set; }

        /// <summary>
        /// The countries associated with the movie.
        /// </summary>
        public ICollection<MovieCountry>? Countries { get; set; }

        /// <summary>
        /// The genres associated with the movie.
        /// </summary>
        public ICollection<MovieGenre>? Genres { get; set; }

        /// <summary>
        /// The users associated with the movie.
        /// </summary>
        public ICollection<AppUserMovie>? MovieAppUsers { get; set; }

        /// <summary>
        /// The synchronization property (Kinopoisk ID).
        /// </summary>
        [NotMapped]
        public int SyncProperty => KinopoiskId;
    }
}
