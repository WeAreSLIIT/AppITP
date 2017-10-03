using System;
using Inventory_Management_System.IRepositories;

namespace Inventory_Management_System
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderProductRepository OrderProducts { get; }
        IOrderRepository Orders { get; }
        IOrderServiceRepository OrderServices { get; }
        ISupplierRepository Suppliers { get; }
        IServiceSupplierRepository ServiceSuppliers { get; }
        IProductSupplierRepository ProductSuppliers { get; }
        ISupplierPaymentRepository SupplierPayments { get; }
      

        int Complete();
    }
}