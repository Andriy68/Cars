using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DATA.Models;
using BUSINESS.Interfaces;
using BUSINESS.DTO;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerServ serv;
        public WorkerController(IWorkerServ serv)
        {
            this.serv = serv ?? throw new ArgumentNullException(nameof(serv));
        }
        [HttpGet("all")]
        public List<Worker> Get()
        {
            return serv.All();
        }
        [HttpGet("get/{id}")]
        public Worker Id(int id)
        {
            return serv.Id(id);
        }
        [HttpPost("add")]
        public void Post([FromBody] WorkerDTO order)
        {
            serv.Add(order);
        }
        [HttpPut("edit/{id}")]
        public void Put([FromBody] WorkerDTO order, int id)
        {
            serv.Edit(order, id);
        }
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            serv.Delete(id);
        }
    }
}
