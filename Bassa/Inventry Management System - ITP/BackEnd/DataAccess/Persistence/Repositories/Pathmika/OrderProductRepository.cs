using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class OrderProductRepository : Repository<OrderProduct>, IOrderProductRepository
    {
        public OrderProductRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
        }
    }
}
