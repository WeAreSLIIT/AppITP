using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class InvoiceCustomerRepository : Repository<InvoiceCustomer>, IInvoiceCustomerRepository
    {
        public InvoiceCustomerRepository(InventryMangementSystemDbContext Context):base(Context)
        {
        }
    }
}
