using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskDesktop.Domain.Models
{
    public class Genre : BaseEntity<int>
    {
        public string Name { get; set; }

        public ICollection<MovieGenre>? MovieGenres { get; set; }
    }

}
