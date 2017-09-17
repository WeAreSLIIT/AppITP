using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
        }
    }
}
