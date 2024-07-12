using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KinopoiskDesktop.Domain.Models
{
    [PrimaryKey(nameof(AppUserId), nameof(MovieId))]
    public class AppUserMovie
    {
        [Required]
        public Guid AppUserId { get; set; }
        [Required]
        public int MovieId { get; set; }


        public bool IsFavorite { get; set; } = false;
        public bool IsWatched { get; set; } = false;
        public double? Rating { get; set; }

    }
}
