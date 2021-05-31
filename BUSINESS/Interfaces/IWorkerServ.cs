using System;
using System.Collections.Generic;
using System.Text;
using DATA.Models;
using BUSINESS.DTO;

namespace BUSINESS.Interfaces
{
    public interface IWorkerServ
    {
        List<Worker> All();
        Worker Id(int Id);
        void Add(WorkerDTO worker);
        void Edit(WorkerDTO worker, int Id);
        void Delete(int Id);
    }
}
