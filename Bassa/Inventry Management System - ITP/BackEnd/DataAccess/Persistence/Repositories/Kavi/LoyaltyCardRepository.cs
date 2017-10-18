using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class LoyaltyCardRepository : Repository<LoyaltyCard>, ILoyaltyCardRepository
    {
        public LoyaltyCardRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
        }
    }
}
