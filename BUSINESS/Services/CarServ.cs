using System.Collections.Generic;
using DATA.Models;
using DATA.Interfaces;
using BUSINESS.Interfaces;
using BUSINESS.DTO;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using BUSINESS.Validation;
namespace BUSINESS.Services
{
    public class CarServ : ICarServ
    {
        private IUnitOfWork Data { get; set; }
        private readonly IConfiguration config;
        private Mapper mapper;
        private CarValidator validator { get; set; }
        public CarServ(IUnitOfWork unit, IConfiguration conf)
        {
            Data = unit;
            config = conf;
            validator = new CarValidator();
        }
        public List<Car> All()
        {
            return Data.Cars.All();
        }
        public Car Id(int Id)
        {
            return Data.Cars.Id(Id);
        }
        public void Add(CarDTO car)
        {
            var res = validator.Validate(car);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<CarDTO, Car>()));
                Data.Cars.Add(mapper.Map<CarDTO, Car>(car));
            }
            Data.Save();
        }
        public void Edit(CarDTO car, int Id)
        {
            var res = validator.Validate(car);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<CarDTO, Car>()));
                Data.Cars.Edit(mapper.Map<CarDTO, Car>(car), Id);
            }
            Data.Save();
        }
        public void Delete(int Id)
        {
            Data.Cars.Delete(Id);
            Data.Save();
        }
    }
}
