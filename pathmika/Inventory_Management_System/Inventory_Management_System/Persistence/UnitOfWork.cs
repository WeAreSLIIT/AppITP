using Inventory_Management_System.Persistence; 
using Inventory_Management_System.IRepositories;
using Inventory_Management_System.Persistence.Repositories;

namespace Inventory_Management_System
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Inventory_Management_System_DbContext _context;

        public IOrderRepository Orders { get; private set; }
        public IOrderServiceRepository OrderServices { get; private set; }
        public IOrderProductRepository OrderProducts { get; private set; }
        public ISupplierRepository Suppliers { get; private set; }
        public IProductSupplierRepository ProductSuppliers { get; private set; }
        public IServiceSupplierRepository ServiceSuppliers { get; private set; }
        public ISupplierPaymentRepository SupplierPayments { get; private set; }
       

        public UnitOfWork()
        {

            this._context = new Inventory_Management_System_DbContext();
            Orders = new OrderRepository(this._context);
            OrderServices    =new OrderServiceRepository(this._context);
            OrderProducts    =new OrderProductRepository(this._context);
            Suppliers        =new SupplierRepository(this._context);
            ProductSuppliers =new ProductSupplierRepository(this._context);
            ServiceSuppliers =new ServiceSupplierRepository(this._context);
            SupplierPayments =new SupplierPaymentRepository(this._context);
            

        }


        public int Complete()
        {
            return this._context.SaveChanges();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}