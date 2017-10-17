using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class SystemRepository : Repository<SystemDetails>, ISystemRepository
    {
        public SystemRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
        }
    }
}
