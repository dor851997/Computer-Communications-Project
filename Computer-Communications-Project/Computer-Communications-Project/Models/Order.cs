using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Computer_Communications_Project.Models
{
    public class Order
    {
        public int? OrderID { get; set; }
        [Required]
        public string MovieName { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string HallName { get; set; }
        [Required]
        [Key]
        [Column(Order = 0)]
        public int LineSeat { get; set; }
        [Required]
        [Key]
        [Column(Order = 1)]
        public int RowSeat { get; set; }
        [Required]
        [Key]
        [Column(Order = 2)]
        public DateTime Date { get; set; }

    }
}