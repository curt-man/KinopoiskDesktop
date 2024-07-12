using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskDesktop.Domain.Models
{
    public class Movie : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string PosterUrl { get; set; }

    }

}
