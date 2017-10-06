using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class InvoiceProductRepository : Repository<InvoiceProduct>, IInvoiceProductRepository
    {
        public InvoiceProductRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
        }
    }
}
