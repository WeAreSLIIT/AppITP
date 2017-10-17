using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class SupplierPaymentRepository : Repository<SupplierPayment>, ISupplierPaymentRepository
    {
        public SupplierPaymentRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
        }
    }
}
