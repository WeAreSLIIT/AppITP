using System;
using DataAccess.Core.Repositories;

namespace DataAccess.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBranchRepository Branches { get; }
        ICounterRepository Counters { get; }
        ICustomerRepository Customers { get; }
        IDiscountRepository Discounts { get; }
        IEmployeeRepository Employees { get; }
        IInvoiceCustomerRepository InvoiceCustomers { get; }
        IInvoiceDealDiscountRepository InvoiceDealDiscounts { get; }
        IInvoiceDealRepository InvoiceDeals { get; }
        IInvoiceEmployeeDiscountRepository InvoiceEmployeeDiscounts { get; }
        IInvoiceProductRepository InvoiceProducts { get; }
        IInvoiceRepository Invoices { get; }
        IProductRepository Products { get; }
        IPaymentMethodRepository PaymentMethods { get; }

        int Complete();
    }
}
