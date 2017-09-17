using DataAccess.Core;
using DataAccess.Core.Repositories;
using DataAccess.Persistence.Repositories;

namespace DataAccess.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventryMangementSystemDbContext _context;

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

        public UnitOfWork(InventryMangementSystemDbContext Context)
        {
            this._context = Context;

            Customers = new CustomerRepository(Context);
            Discounts = new DiscountRepository(Context);
            Employees = new EmployeeRepository(Context);
            InvoiceCustomers = new InvoiceCustomerRepository(Context);
            InvoiceDealDiscounts = new InvoiceDealDiscountRepository(Context);
            InvoiceDeals = new InvoiceDealRepository(Context);
            InvoiceEmployeeDiscounts = new InvoiceEmployeeDiscountRepository(Context);
            InvoiceProducts = new InvoiceProductRepository(Context);
            Invoices = new InvoiceRepository(Context);
            Products = new ProductRepository(Context);
            PaymentMethods = new PaymentMethodRepository(Context);

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
