using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class PrivilegeRepository : Repository<Privilege>, IPrivilegeRepository
    {
        public PrivilegeRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
        }
    }
}
