using System;
using System.Collections.Generic;
using System.Text;
using DATA.Models;

namespace DATA.Interfaces
{
    public interface ICustomerRep
    {
        List<Customer> All();
        Customer Id(int id);
        void Add(Customer customer);
        void Edit(Customer customer, int Id);
        void Delete(int Id);
    }
}
