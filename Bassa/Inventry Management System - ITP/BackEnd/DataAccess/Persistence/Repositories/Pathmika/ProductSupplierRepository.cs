using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class ProductSupplierRepository : Repository<ProductSupplier>, IProductSupplierRepository
    {
        public ProductSupplierRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
        }
    }
}
