using System.Collections.Generic;
using DATA.Models;
using DATA.Interfaces;
using BUSINESS.Interfaces;
using BUSINESS.DTO;
using BUSINESS.Validation;
using Microsoft.Extensions.Configuration;
using AutoMapper;

namespace BUSINESS.Services
{
    public class DescServ : IDescServ
    {
        private IUnitOfWork Data { get; set; }
        private readonly IConfiguration config;
        private Mapper mapper;
        private DescValidator validator { get; set; }
        public DescServ(IUnitOfWork unit, IConfiguration conf)
        {
            Data = unit;
            config = conf;
            validator = new DescValidator();
        }
        public List<CarDesc> All()
        {
            return Data.Descriptions.All();
        }
        public CarDesc Id(int Id)
        {
            return Data.Descriptions.Id(Id);
        }
        public void Add(DescDTO desc)
        {
            var res = validator.Validate(desc);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<DescDTO, CarDesc>()));
                Data.Descriptions.Add(mapper.Map<DescDTO, CarDesc>(desc));
            }
            Data.Save();
        }
        public void Edit(DescDTO desc, int Id)
        {
            var res = validator.Validate(desc);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<DescDTO, CarDesc>()));
                Data.Descriptions.Edit(mapper.Map<DescDTO, CarDesc>(desc), Id);
            }
            Data.Save();
        }
        public void Delete(int Id)
        {
            Data.Descriptions.Delete(Id);
            Data.Save();
        }
    }
}
