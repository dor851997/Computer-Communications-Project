using Computer_Communications_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Computer_Communications_Project.ViewModel
{
    public class MovieViewModel
    {
        public List<Movie> Movies { get; set; }
        public Movie movieName { get; set; }
    }
}