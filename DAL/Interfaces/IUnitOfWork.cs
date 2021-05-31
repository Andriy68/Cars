using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace DATA.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICarRep Cars { get; }
        ICustomerRep Customers { get; }
        IDescRep Descriptions { get; }
        IOrderRep Orders { get; }
        ISellerRep Sellers { get; }
        IWorkerRep Workers { get; }
        int Save();
        void Dispose();
    }
}
