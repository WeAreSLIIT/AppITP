using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class WastageRepository : Repository<Wastage>, IWastageRepository
    {
        public WastageRepository(InventryMangementSystemDbContext context) : base(context)
        {
        }
    }
}
