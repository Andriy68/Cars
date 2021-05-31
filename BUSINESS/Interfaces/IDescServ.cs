using System;
using System.Collections.Generic;
using System.Text;
using DATA.Models;
using BUSINESS.DTO;

namespace BUSINESS.Interfaces
{
    public interface IDescServ
    {
        List<CarDesc> All();
        CarDesc Id(int Id);
        void Add(DescDTO desc);
        void Edit(DescDTO desc, int Id);
        void Delete(int Id);
    }
}
