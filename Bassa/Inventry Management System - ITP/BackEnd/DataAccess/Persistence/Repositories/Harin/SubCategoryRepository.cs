using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
    {
        private new InventryMangementSystemDbContext _context;

        public SubCategoryRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
            this._context = Context;
        }

        public SubCategory GetName(string Name)
        {
            return this._context.SubCategories.SingleOrDefault(pn => pn.SubCategoryName == Name);
        }
    }
}
