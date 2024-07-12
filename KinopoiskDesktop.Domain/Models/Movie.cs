using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KinopoiskDesktop.Domain.Enums;

namespace KinopoiskDesktop.Domain.Models
{
    public class Movie : BaseEntity<int>, ISyncableEntity
    {

        public int KinopoiskId { get; set; }

        public string KinopoiskHDId { get; set; }

        public string ImdbId { get; set; }


        public string NameRu { get; set; }

        public string NameEn { get; set; }

        public string NameOriginal { get; set; }

        [Required]
        public string PosterUrl { get; set; }

        [Required]
        public string PosterUrlPreview { get; set; }

        public string CoverUrl { get; set; }

        public string LogoUrl { get; set; }


        public int ReviewsCount { get; set; }

        public double? RatingKinopoisk { get; set; }

        public int? RatingKinopoiskVoteCount { get; set; }

        public double? RatingImdb { get; set; }

        public int? RatingImdbVoteCount { get; set; }

        public double? RatingFilmCritics { get; set; }

        public int? RatingFilmCriticsVoteCount { get; set; }


        [Required]
        public string WebUrl { get; set; }

        public int? Year { get; set; }

        public int? FilmLength { get; set; }

        public string Slogan { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public string EditorAnnotation { get; set; }

        public FilmProductionStatus? ProductionStatus { get; set; }

        [Required]
        public FilmType Type { get; set; }

        public string RatingMpaa { get; set; }

        public string RatingAgeLimits { get; set; }

        public int? StartYear { get; set; }

        public int? EndYear { get; set; }

        public bool? Serial { get; set; }

        public bool? ShortFilm { get; set; }

        public bool? Completed { get; set; }


        public DateTime? SyncedAt   { get; set; }
        public TimeSpan? SyncPeriod { get; set; }

        public ICollection<Country> Countries { get; set; } = new HashSet<Country>();

        public ICollection<Genre> Genres { get; set; } = new HashSet<Genre>();

        public ICollection<AppUserMovie> MovieAppUsers { get; set; }

    }


}
