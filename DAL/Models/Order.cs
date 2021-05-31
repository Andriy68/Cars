using System;
using System.Collections.Generic;
using System.Text;

namespace DATA.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public List<Worker> Workers { get; set; } = new List<Worker>();
    }
}
