using System.ComponentModel.DataAnnotations;

namespace KinopoiskDesktop.Domain.Models
{
    /// <summary>
    /// Represents a base entity with common properties.
    /// </summary>
    /// <typeparam name="T">The type of the entity's identifier.</typeparam>
    public class BaseEntity<T>
    {
        /// <summary>
        /// The identifier of the entity.
        /// </summary>
        [Key]
        public virtual T Id { get; set; }

        /// <summary>
        /// The date and time when the entity was created.
        /// </summary>
        [Required]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The date and time when the entity was last updated.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// The date and time when the entity was deleted.
        /// </summary>
        public DateTime? DeletedAt { get; set; }
    }
}
