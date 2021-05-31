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
    public class CarController : ControllerBase
    {
        private readonly ICarServ serv;
        public CarController(ICarServ serv)
        {
            this.serv = serv ?? throw new ArgumentNullException(nameof(serv));
        }
        [HttpGet("all")]
        public List<Car> Get()
        {
            return serv.All();
        }
        [HttpGet("get/{id}")]
        public Car Id(int id)
        {
            return serv.Id(id);
        }
        [HttpPost("add")]
        public void Post([FromBody] CarDTO car)
        {
            serv.Add(car);
        }
        [HttpPut("edit/{id}")]
        public void Put([FromBody] CarDTO car, int id)
        {
            serv.Edit(car, id);
        }
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            serv.Delete(id);
        }
    }
}
