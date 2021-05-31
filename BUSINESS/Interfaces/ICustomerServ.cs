using System;
using System.Collections.Generic;
using System.Text;
using DATA.Models;
using BUSINESS.DTO;

namespace BUSINESS.Interfaces
{
    public interface ICustomerServ
    {
        List<Customer> All();
        Customer Id(int Id);
        void Add(CustomerDTO customer);
        void Edit(CustomerDTO customer, int Id);
        void Delete(int Id);
    }
}
