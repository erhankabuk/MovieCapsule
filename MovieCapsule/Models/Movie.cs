using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCapsule.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required,MaxLength(250)]
        public string Title { get; set; }     
        public int Year { get; set; }
        public decimal Rating { get; set; }

        public ICollection<Genre> Genres{ get; set; }
    }
}
