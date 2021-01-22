using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Computer_Communications_Project.Models
{
    public class Hall
    {
        [Key]
        [Required]
        public string HallName { get; set; }
        [Required]
        public int RowNumber{ get; set; }
        [Required]
        public int ColNumber{ get; set; }

    }
}