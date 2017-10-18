using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class LoyaltyProgramRepository : Repository<LoyaltyProgram>, ILoyaltyProgramRepository
    {
        public LoyaltyProgramRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
        }
    }
}
