using System;
using System.Collections.Generic;
using System.Text;

namespace DATA.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Contacts { get; set; }
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
