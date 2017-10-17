using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class InvoiceEmployeeDiscountRepository : Repository<InvoiceEmployeeDiscount>, IInvoiceEmployeeDiscountRepository
    {
        public InvoiceEmployeeDiscountRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
        }
    }
}
