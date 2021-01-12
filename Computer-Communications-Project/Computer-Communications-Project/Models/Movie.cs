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
        
        [Required]
        public string MovieName { get; set; }
        [Required]
        public string AgeLimet { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public double Price { get; set; }
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public DateTime Date { get; set; }

        public double? Discount { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        public TimeSpan Time { get; set; }
        [Key, Column(Order = 2)]
        [Required]
        public string HallName { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }

        public string src { get; set; }
        
    }
}