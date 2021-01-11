using System.ComponentModel.DataAnnotations;


namespace Computer_Communications_Project.Models
{
    public class Admin
    {
        [Key]
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
