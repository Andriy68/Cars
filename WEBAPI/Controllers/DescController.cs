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
    public class DescController : ControllerBase
    {
        private readonly IDescServ serv;
        public DescController(IDescServ serv)
        {
            this.serv = serv ?? throw new ArgumentNullException(nameof(serv));
        }
        [HttpGet("all")]
        public List<CarDesc> Get()
        {
            return serv.All();
        }
        [HttpGet("get/{id}")]
        public CarDesc Id(int id)
        {
            return serv.Id(id);
        }
        [HttpPost("add")]
        public void Post([FromBody] DescDTO desc)
        {
            serv.Add(desc);
        }
        [HttpPut("edit/{id}")]
        public void Put([FromBody] DescDTO desc, int id)
        {
            serv.Edit(desc, id);
        }
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            serv.Delete(id);
        }
    }
}
