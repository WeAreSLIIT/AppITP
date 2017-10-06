using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class TransOutRepository : Repository<TransOut>, ITransOutRepository
    {
        public TransOutRepository(InventryMangementSystemDbContext context) : base(context)
        {
        }
    }
}
