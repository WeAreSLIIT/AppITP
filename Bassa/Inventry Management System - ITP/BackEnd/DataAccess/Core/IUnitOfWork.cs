using System;
using DataAccess.Core.Repositories;

namespace DataAccess.Core
{
    public interface IUnitOfWork : IDisposable
    {
        #region CSB's

        IInvoiceCustomerRepository InvoiceCustomers { get; }
        IInvoiceDealDiscountRepository InvoiceDealDiscounts { get; }
        IInvoiceDealRepository InvoiceDeals { get; }
        IInvoiceEmployeeDiscountRepository InvoiceEmployeeDiscounts { get; }
        IInvoiceProductRepository InvoiceProducts { get; }
        IInvoiceRepository Invoices { get; }
        IInvoicePaymentMethodRepository InvoicePaymentMethods { get; }
        IPaymentMethodRepository PaymentMethods { get; }
        ICounterRepository Counters { get; }

        #endregion

        #region Samith's

        IBranchRepository Branches { get; }
        IEmployeeRepository Employees { get; }

        #endregion

        #region Harin's

        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        ISubCategoryRepository SubCategories { get; }
        ISectionRepository Sections { get; }
        IRackRepository Racks { get; }

        #endregion

        #region Kavi's

        ICustomerRepository Customers { get; }

        #endregion

        #region Dileepa's

        IDiscountRepository Discounts { get; }

        #endregion

        #region Pathmika's

        #endregion

        #region Yashika's

        #endregion
        

        int Complete();
    }
}
