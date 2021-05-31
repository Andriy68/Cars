using System;
using System.Collections.Generic;
using System.Text;

namespace DATA.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Contacts { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
