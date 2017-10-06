using System;
using DataAccess.Core;
using DataAccess.Core.Repositories;
using DataAccess.Persistence.Repositories;

namespace DataAccess.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventryMangementSystemDbContext _context;

        #region CSB's
        
        public ICounterRepository Counters { get; private set; }
        public IInvoiceCustomerRepository InvoiceCustomers { get; private set; }
        public IInvoiceDealDiscountRepository InvoiceDealDiscounts { get; private set; }
        public IInvoiceDealRepository InvoiceDeals { get; private set; }
        public IInvoiceEmployeeDiscountRepository InvoiceEmployeeDiscounts { get; private set; }
        public IInvoiceProductRepository InvoiceProducts { get; private set; }
        public IInvoiceRepository Invoices { get; private set; }
        public IPaymentMethodRepository PaymentMethods { get; private set; }
        public IInvoicePaymentMethodRepository InvoicePaymentMethods { get; private set; }

        #endregion

        #region Samith's

        public IBranchRepository Branches { get; private set; }
        public IEmployeeRepository Employees { get; private set; }


        #endregion

        #region Dileepa's

        public IDiscountRepository Discounts { get; private set; }


        #endregion

        #region Harin's

        public IProductRepository Products { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public ISubCategoryRepository SubCategories { get; private set; }
        public ISectionRepository Sections { get; private set; }
        public IRackRepository Racks { get; private set; }

        #endregion

        #region Kavi's

        public ICustomerRepository Customers { get; private set; }


        #endregion

        #region Pathmika's



        #endregion

        #region Yashika's



        #endregion


        //public UnitOfWork(InventryMangementSystemDbContext Context)
        public UnitOfWork()
        {
            this._context = new InventryMangementSystemDbContext();

            Employees = new EmployeeRepository(this._context);
            Branches = new BranchRepository(this._context);

            Customers = new CustomerRepository(this._context);

            Discounts = new DiscountRepository(this._context);

            Counters = new CounterRepository(this._context);
            InvoiceCustomers = new InvoiceCustomerRepository(this._context);
            InvoiceDealDiscounts = new InvoiceDealDiscountRepository(this._context);
            InvoiceDeals = new InvoiceDealRepository(this._context);
            InvoiceEmployeeDiscounts = new InvoiceEmployeeDiscountRepository(this._context);
            InvoiceProducts = new InvoiceProductRepository(this._context);
            Invoices = new InvoiceRepository(this._context);
            PaymentMethods = new PaymentMethodRepository(this._context);
            InvoicePaymentMethods = new InvoicePaymentMethodRepository(this._context);

            Products = new ProductRepository(this._context);
            Categories = new CategoryRepository(this._context);
            SubCategories = new SubCategoryRepository(this._context);
            Sections = new SectionRepository(this._context);
            Racks = new RackRepository(this._context);
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
