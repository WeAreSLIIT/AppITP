using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        private new InventryMangementSystemDbContext _context;

        public SectionRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
            this._context = Context;
        }

        public Section GetName(string Name)
        {
            return this._context.Sections.SingleOrDefault(pn => pn.SectionName == Name);
        }
    }
}
