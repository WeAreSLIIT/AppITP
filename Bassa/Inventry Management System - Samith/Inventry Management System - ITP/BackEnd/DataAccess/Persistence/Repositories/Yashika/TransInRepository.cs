using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class TransInRepository : Repository<TransInStock>, ITransInRepository
    {
        public TransInRepository(InventryMangementSystemDbContext context) : base(context)
        {
        }
    }
}
