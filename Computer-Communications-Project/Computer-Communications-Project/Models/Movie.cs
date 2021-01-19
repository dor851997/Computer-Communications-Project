using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Computer_Communications_Project.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public string MovieName { get; set; }
        [Required]
        public string AgeLimit { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double Discount { get; set; }
        [Required]
        public string HallName { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        [Required]
        public string src { get; set; }
        [Required]
        public double Rating { get; set; }
    }
}