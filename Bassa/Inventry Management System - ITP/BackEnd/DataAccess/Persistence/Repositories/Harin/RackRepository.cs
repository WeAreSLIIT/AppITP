using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class RackRepository : Repository<Rack>, IRackRepository
    {
        private new InventryMangementSystemDbContext _context;

        public RackRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
            this._context = Context;
        }

        public Rack GetName(string Name)
        {
            return this._context.Racks.SingleOrDefault(pn => pn.RackName == Name);
        }
    }
}
