using Computer_Communications_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Computer_Communications_Project.ViewModel
{
    public class OrderViewModel
    {
        public List<Order> Orders { get; set; }
        public Order Order { get; set; }
    }
}