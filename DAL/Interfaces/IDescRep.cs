using System;
using System.Collections.Generic;
using System.Text;
using DATA.Models;

namespace DATA.Interfaces
{
    public interface IDescRep
    {
        List<CarDesc> All();
        CarDesc Id(int id);
        void Add(CarDesc desc);
        void Edit(CarDesc esc, int Id);
        void Delete(int Id);
    }
}
