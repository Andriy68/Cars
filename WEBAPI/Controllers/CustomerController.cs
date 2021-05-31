using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DATA.Models;
using BUSINESS.Interfaces;
using BUSINESS.DTO;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServ serv;
        public CustomerController(ICustomerServ serv)
        {
            this.serv = serv ?? throw new ArgumentNullException(nameof(serv));
        }
        [HttpGet("all")]
        public List<Customer> Get()
        {
            return serv.All();
        }
        [HttpGet("get/{id}")]
        public Customer Id(int id)
        {
            return serv.Id(id);
        }
        [HttpPost("add")]
        public void Post([FromBody] CustomerDTO customer)
        {
            serv.Add(customer);
        }
        [HttpPut("edit/{id}")]
        public void Put([FromBody] CustomerDTO customer, int id)
        {
            serv.Edit(customer, id);
        }
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            serv.Delete(id);
        }
    }
}
