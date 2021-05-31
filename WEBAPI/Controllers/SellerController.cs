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
    public class SellerController : ControllerBase
    {
        private readonly ISellerServ serv;
        public SellerController(ISellerServ serv)
        {
            this.serv = serv ?? throw new ArgumentNullException(nameof(serv));
        }
        [HttpGet("all")]
        public List<Seller> Get()
        {
            return serv.All();
        }
        [HttpGet("get/{id}")]
        public Seller Id(int id)
        {
            return serv.Id(id);
        }
        [HttpPost("add")]
        public void Post([FromBody] SellerDTO seller)
        {
            serv.Add(seller);
        }
        [HttpPut("edit/{id}")]
        public void Put([FromBody] SellerDTO seller, int id)
        {
            serv.Edit(seller, id);
        }
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            serv.Delete(id);
        }
    }
}
