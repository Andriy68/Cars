using System.Collections.Generic;
using DATA.Models;
using DATA.Interfaces;
using BUSINESS.Validation;
using BUSINESS.Interfaces;
using Microsoft.Extensions.Configuration;
using BUSINESS.DTO;
using AutoMapper;

namespace BUSINESS.Services
{
    public class WorkerServ : IWorkerServ
    {
        private IUnitOfWork Data { get; set; }
        private readonly IConfiguration config;
        private Mapper mapper;
        private WorkerValidator validator { get; set; }
        public WorkerServ(IUnitOfWork unit, IConfiguration conf)
        {
            Data = unit;
            config = conf;
            validator = new WorkerValidator();
        }
        public List<Worker> All()
        {
            return Data.Workers.All();
        }
        public Worker Id(int Id)
        {
            return Data.Workers.Id(Id);
        }
        public void Add(WorkerDTO worker)
        {
            var res = validator.Validate(worker);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<WorkerDTO, Worker>()));
                Data.Workers.Add(mapper.Map<WorkerDTO, Worker>(worker));
            }
            Data.Save();
        }
        public void Edit(WorkerDTO worker, int Id)
        {
            var res = validator.Validate(worker);
            if (res.IsValid)
            {
                mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<WorkerDTO, Worker>()));
                Data.Workers.Edit(mapper.Map<WorkerDTO, Worker>(worker), Id);
            }
            Data.Save();
        }
        public void Delete(int Id)
        {
            Data.Workers.Delete(Id);
            Data.Save();
        }
    }
}
