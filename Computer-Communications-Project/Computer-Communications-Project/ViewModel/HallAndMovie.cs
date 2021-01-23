using Computer_Communications_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Computer_Communications_Project.ViewModel
{
    public class HallAndMovie
    {
        public Movie Movie { get; set; }
        public Hall Hall { get; set; }
        public List<Order> Orders { get; set; }
    }
}