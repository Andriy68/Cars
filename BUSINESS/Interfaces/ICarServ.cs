using System;
using System.Collections.Generic;
using System.Text;
using DATA.Models;
using BUSINESS.DTO;

namespace BUSINESS.Interfaces
{
    public interface ICarServ
    {
        List<Car> All();
        Car Id(int Id);
        void Add(CarDTO car);
        void Edit(CarDTO car, int Id);
        void Delete(int Id);
    }
}
