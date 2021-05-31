using DATA.Interfaces;
using DATA.Context;
using DATA.Repos;

namespace DATA.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext context;
        public ICarRep Cars { get; }
        public ICustomerRep Customers { get; }
        public IDescRep Descriptions { get; }
        public IOrderRep Orders { get; }
        public ISellerRep Sellers { get; }
        public IWorkerRep Workers { get; }
        public UnitOfWork(MyContext context)
        {
            this.context = context;
            Cars = new CarRep(context);
            Customers = new CustomerRep(context);
            Descriptions = new DescRep(context);
            Orders = new OrderRep(context);
            Sellers = new SellerRep(context);
            Workers = new WorkerRep(context);
        }
        public int Save()
        {
            return context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
