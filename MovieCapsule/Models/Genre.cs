using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCapsule.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
