using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private new InventryMangementSystemDbContext _context;

        public CategoryRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
            this._context = Context;
        }

        public Category GetName(string Name)
        {
            return this._context.Categories.SingleOrDefault(pn => pn.CategoryName == Name);
        }
    }
}
