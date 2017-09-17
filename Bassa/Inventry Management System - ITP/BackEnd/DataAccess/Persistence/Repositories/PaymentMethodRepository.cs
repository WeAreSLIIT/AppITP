using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class PaymentMethodRepository : Repository<PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
        }
    }
}
