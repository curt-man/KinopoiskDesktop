namespace KinopoiskDesktop.Domain.Models
{

    /// <summary>
    /// Represents an application user.
    /// </summary>
    public class AppUser : EntityBase<Guid>
    {
        /// <summary>
        /// The first name of the user.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// The last name of the user.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// The second name of the user.
        /// </summary>
        public string? SecondName { get; set; }

        /// <summary>
        /// The email of the user.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// The username of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The hashed password of the user.
        /// </summary>
        public byte[] PasswordHash { get; set; }

        /// <summary>
        /// The salt used to hash the password.
        /// </summary>
        public byte[] PasswordSalt { get; set; }

        /// <summary>
        /// The last login date and time of the user.
        /// </summary>
        public DateTime? LoggedAt { get; set; }

        /// <summary>
        /// The collection of movies associated with the user.
        /// </summary>
        public ICollection<AppUserMovie>? AppUserMovies { get; set; }
    }
}
