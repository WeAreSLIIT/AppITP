using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class ReturnRepository : Repository<ReturnStock>, IReturnRepository
    {
        public ReturnRepository(InventryMangementSystemDbContext context) : base(context)
        {
        }
    }
}
