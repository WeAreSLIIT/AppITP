using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class PreorderRepository : Repository<Preorder>, IPreorderRepository
    {
        public PreorderRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
        }
    }
}
