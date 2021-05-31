using System;
using System.Collections.Generic;
using System.Text;
using DATA.Models;

namespace DATA.Interfaces
{
    public interface IOrderRep
    {
        List<Order> All();
        Order Id(int id);
        void Add(Order order);
        void Edit(Order order, int Id);
        void Delete(int Id);
    }
}
