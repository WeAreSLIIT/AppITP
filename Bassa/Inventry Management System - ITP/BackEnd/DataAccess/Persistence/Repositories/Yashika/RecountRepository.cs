using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class RecountRepository : Repository<Recount>, IRecountRepository
    {
        public RecountRepository(InventryMangementSystemDbContext context) : base(context)
        {
        }
    }
}
