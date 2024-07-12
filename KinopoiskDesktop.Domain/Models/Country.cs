using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskDesktop.Domain.Models
{
    public class Country : BaseEntity<int>
    {
        public string Name { get; set; }

        public ICollection<MovieCountry>? MovieCountries { get; set; }
    }

}
