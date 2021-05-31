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
    public class CustomerServ : ICustomerServ
    {
        private IUnitOfWork Data { get; set; }
        private readonly IConfiguration config;
        private Mapper mapper;
        private CustomerValidator validator { get; set; }
        public CustomerServ(IUnitOfWork unit, IConfiguration conf)
        {
            Data = unit;
            config = conf;
            validator = new CustomerValidator();
        }
        public List<Customer> All()
        {
            return Data.Customers.All();
        }
        public Customer Id(int Id)
        {
            return Data.Customers.Id(Id);
        }
        public void Add(CustomerDTO customer)
        {
            var res = validator.Validate(customer);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<CustomerDTO, Customer>()));
                Data.Customers.Add(mapper.Map<CustomerDTO, Customer>(customer));
            }
            Data.Save();
        }
        public void Edit(CustomerDTO customer, int Id)
        {
            var res = validator.Validate(customer);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<CustomerDTO, Customer>()));
                Data.Customers.Edit(mapper.Map<CustomerDTO, Customer>(customer), Id);
            }
            Data.Save();
        }
        public void Delete(int Id)
        {
            Data.Customers.Delete(Id);
            Data.Save();
        }
    }
}
