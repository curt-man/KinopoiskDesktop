using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskDesktop.Domain.Models
{
    public class Genre : BaseEntity<int>, ISyncableEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get; set; }
        public string Name { get; set; }

        public ICollection<MovieGenre>? MovieGenres { get; set; }

        public DateTime? SyncedAt { get; set; }
        public TimeSpan? SyncPeriod { get; set; }

        [NotMapped]
        public int SyncProperty => Id;
    }

}
