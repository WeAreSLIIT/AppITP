using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class CreditRepository : Repository<Credit>, ICreditRepository
    {
        private new InventryMangementSystemDbContext _context;

        public CreditRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
            this._context = Context;
        }
    }
}
