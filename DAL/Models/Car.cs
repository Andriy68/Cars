using System;
using System.Collections.Generic;
using System.Text;

namespace DATA.Models
{
    public class Car
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int SellerID { get; set; }
        public Seller Seller { get; set; }
        public CarDesc Description { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
