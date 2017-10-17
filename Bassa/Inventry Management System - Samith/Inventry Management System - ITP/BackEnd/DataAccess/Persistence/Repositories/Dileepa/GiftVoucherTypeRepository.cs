using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class GiftVoucherTypeRepository : Repository<GiftVoucherType>, IGiftVoucherTypeRepository
    {
        public GiftVoucherTypeRepository(InventryMangementSystemDbContext context) : base(context)
        {

        }
    }
}
