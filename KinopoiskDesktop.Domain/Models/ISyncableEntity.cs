namespace KinopoiskDesktop.Domain.Models
{

    /// <summary>
    /// Interface for entities that can be synchronized.
    /// </summary>
    /// <typeparam name="T">The type of the synchronization property.</typeparam>
    public interface ISyncableEntity<T>
    {
        /// <summary>
        /// The last synchronization date and time.
        /// </summary>
        public DateTime? SyncedAt { get; set; }

        /// <summary>
        /// The synchronization period.
        /// </summary>
        public TimeSpan? SyncPeriod { get; set; }

        /// <summary>
        /// The property used for synchronization.
        /// </summary>
        public T SyncProperty { get; }
    }

}
