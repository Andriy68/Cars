using System.Collections.Generic;
using DATA.Models;
using DATA.Interfaces;
using BUSINESS.Interfaces;
using BUSINESS.Validation;
using Microsoft.Extensions.Configuration;
using BUSINESS.DTO;
using AutoMapper;

namespace BUSINESS.Services
{
    public class SellerServ : ISellerServ
    {
        private IUnitOfWork Data { get; set; }
        private readonly IConfiguration config;
        private Mapper mapper;
        private SellerValidator validator { get; set; }
        public SellerServ(IUnitOfWork unit, IConfiguration conf)
        {
            Data = unit;
            config = conf;
            validator = new SellerValidator();
        }
        public List<Seller> All()
        {
            return Data.Sellers.All();
        }
        public Seller Id(int Id)
        {
            return Data.Sellers.Id(Id);
        }
        public void Add(SellerDTO seller)
        {
            var res = validator.Validate(seller);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<SellerDTO, Seller>()));
                Data.Sellers.Add(mapper.Map<SellerDTO, Seller>(seller));
            }
            Data.Save();
        }
        public void Edit(SellerDTO seller, int Id)
        {
            var res = validator.Validate(seller);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<SellerDTO, Seller>()));
                Data.Sellers.Edit(mapper.Map<SellerDTO, Seller>(seller), Id);
            }
            Data.Save();
        }
        public void Delete(int Id)
        {
            Data.Sellers.Delete(Id);
            Data.Save();
        }
    }
}
