using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KinopoiskDesktop.Domain.Models
{
    /// <summary>
    /// Represents a genre entity with attributes and relationships.
    /// </summary>
    public class Genre : EntityBase<int>, ISyncableEntity<int>
    {
        /// <summary>
        /// The ID of the genre.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get; set; }

        /// <summary>
        /// The name of the genre.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The movies associated with the genre.
        /// </summary>
        public ICollection<MovieGenre>? MovieGenres { get; set; }

        /// <summary>
        /// The last synchronization date and time.
        /// </summary>
        public DateTime? SyncedAt { get; set; }

        /// <summary>
        /// The synchronization period.
        /// </summary>
        public TimeSpan? SyncPeriod { get; set; }

        /// <summary>
        /// The synchronization property (ID).
        /// </summary>
        [NotMapped]
        public int SyncProperty => Id;
    }

}
