using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Computer_Communications_Project.Models
{
    public class User
    {
        [Required]
        [Key]
        public string UserName { set; get; }
        [Required]
        public string Password { set; get; }
    }
}