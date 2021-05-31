using System;
using System.Collections.Generic;
using System.Text;
using DATA.Models;
using BUSINESS.DTO;

namespace BUSINESS.Interfaces
{
    public interface ISellerServ
    {
        List<Seller> All();
        Seller Id(int Id);
        void Add(SellerDTO seller);
        void Edit(SellerDTO seller, int Id);
        void Delete(int Id);
    }
}
