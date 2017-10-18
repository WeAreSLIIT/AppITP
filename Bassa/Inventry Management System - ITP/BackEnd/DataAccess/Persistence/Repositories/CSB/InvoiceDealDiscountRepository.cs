using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class InvoiceDealDiscountRepository : Repository<InvoiceDealDiscount>, IInvoiceDealDiscountRepository
    {
        public InvoiceDealDiscountRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
        }
    }
}
