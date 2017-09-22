using DataAccess.Core;
using DataAccess.Core.Repositories;
using DataAccess.Persistence.Repositories;

namespace DataAccess.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventryMangementSystemDbContext _context;

        public IBranchRepository Branches { get; private set; }
        public ICounterRepository Counters { get; private set; }
        public ICustomerRepository Customers { get; private set; }
        public IDiscountRepository Discounts { get; private set; }
        public IEmployeeRepository Employees { get; private set; }
        public IInvoiceCustomerRepository InvoiceCustomers { get; private set; }
        public IInvoiceDealDiscountRepository InvoiceDealDiscounts { get; private set; }
        public IInvoiceDealRepository InvoiceDeals { get; private set; }
        public IInvoiceEmployeeDiscountRepository InvoiceEmployeeDiscounts { get; private set; }
        public IInvoiceProductRepository InvoiceProducts { get; private set; }
        public IInvoiceRepository Invoices { get; private set; }
        public IProductRepository Products { get; private set; }
        public IPaymentMethodRepository PaymentMethods { get; private set; }

        //public UnitOfWork(InventryMangementSystemDbContext Context)
        public UnitOfWork()
        {
            this._context = new InventryMangementSystemDbContext();

            Branches = new BranchRepository(this._context);
            Counters = new CounterRepository(this._context);
            Customers = new CustomerRepository(this._context);
            Discounts = new DiscountRepository(this._context);
            Employees = new EmployeeRepository(this._context);
            InvoiceCustomers = new InvoiceCustomerRepository(this._context);
            InvoiceDealDiscounts = new InvoiceDealDiscountRepository(this._context);
            InvoiceDeals = new InvoiceDealRepository(this._context);
            InvoiceEmployeeDiscounts = new InvoiceEmployeeDiscountRepository(this._context);
            InvoiceProducts = new InvoiceProductRepository(this._context);
            Invoices = new InvoiceRepository(this._context);
            Products = new ProductRepository(this._context);
            PaymentMethods = new PaymentMethodRepository(this._context);
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
