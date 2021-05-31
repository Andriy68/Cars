using System;
using System.Collections.Generic;
using System.Text;
using DATA.Models;

namespace DATA.Interfaces
{
    public interface ICarRep
    {
        List<Car> All();
        Car Id(int id);
        void Add(Car car);
        void Edit(Car car, int Id);
        void Delete(int Id);
    }
}
