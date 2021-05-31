using System;
using System.Collections.Generic;
using System.Text;
using DATA.Models;

namespace DATA.Interfaces
{
    public interface ISellerRep
    {
        List<Seller> All();
        Seller Id(int id);
        void Add(Seller seller);
        void Edit(Seller seller, int Id);
        void Delete(int Id);
    }
}
