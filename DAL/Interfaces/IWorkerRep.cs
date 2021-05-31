using System;
using System.Collections.Generic;
using System.Text;
using DATA.Models;

namespace DATA.Interfaces
{
    public interface IWorkerRep
    {
        List<Worker> All();
        Worker Id(int id);
        void Add(Worker worker);
        void Edit(Worker worker, int Id);
        void Delete(int Id);
    }
}
