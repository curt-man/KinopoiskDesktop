using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KinopoiskDesktop.Domain.Models
{
    /// <summary>
    /// Represents a country entity with attributes and relationships.
    /// </summary>
    public class Country : BaseEntity<int>, ISyncableEntity<int>
    {
        /// <summary>
        /// The ID of the country.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get; set; }

        /// <summary>
        /// The name of the country.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The movies associated with the country.
        /// </summary>
        public ICollection<MovieCountry>? MovieCountries { get; set; }

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
