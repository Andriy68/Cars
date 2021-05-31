using System;
using System.Collections.Generic;
using System.Text;
using DATA.Models;
using BUSINESS.DTO;

namespace BUSINESS.Interfaces
{
    public interface IOrderServ
    {
        List<Order> All();
        Order Id(int Id);
        void Add(OrderDTO order);
        void Edit(OrderDTO order, int Id);
        void Delete(int Id);
    }
}
