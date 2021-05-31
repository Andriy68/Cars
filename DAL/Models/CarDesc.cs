using System;
using System.Collections.Generic;
using System.Text;

namespace DATA.Models
{
    public class CarDesc
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
    }
}
