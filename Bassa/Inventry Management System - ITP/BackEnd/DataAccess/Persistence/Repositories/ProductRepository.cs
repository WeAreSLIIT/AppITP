using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private new InventryMangementSystemDbContext _context;

        public ProductRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
            this._context = Context;
        }

        public Product Get(string PublicID)
        {
            return this._context.Products.SingleOrDefault(p => p.ProductPublicID == PublicID);
        }
    }
}
