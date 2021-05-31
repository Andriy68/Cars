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
    public class OrderServ : IOrderServ
    {
        private IUnitOfWork Data { get; set; }
        private readonly IConfiguration config;
        private Mapper mapper;
        private OrderValidator validator { get; set; }
        public OrderServ(IUnitOfWork unit, IConfiguration conf)
        {
            Data = unit;
            config = conf;
            validator = new OrderValidator();
        }
        public List<Order> All()
        {
            return Data.Orders.All();
        }
        public Order Id(int Id)
        {
            return Data.Orders.Id(Id);
        }
        public void Add(OrderDTO order)
        {
            var res = validator.Validate(order);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<OrderDTO, Order>()));
                Data.Orders.Add(mapper.Map<OrderDTO, Order>(order));
            }
            Data.Save();
        }
        public void Edit(OrderDTO order, int Id)
        {
            var res = validator.Validate(order);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<OrderDTO, Order>()));
                Data.Orders.Edit(mapper.Map<OrderDTO, Order>(order), Id);
            }
            Data.Save();
        }
        public void Delete(int Id)
        {
            Data.Orders.Delete(Id);
            Data.Save();
        }
    }
}
