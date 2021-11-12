using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCapsule.Models
{
    public class HomeViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<SelectListItem> Genres { get; set; }
        public int? SelectedGenreId { get; set; }
        public string SearchCriteria { get; set; }
    }
}
