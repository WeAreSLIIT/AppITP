using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class InvoiceDealRepository:Repository<InvoiceDeal>, IInvoiceDealRepository
    {
        public InvoiceDealRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
        }
    }
}
