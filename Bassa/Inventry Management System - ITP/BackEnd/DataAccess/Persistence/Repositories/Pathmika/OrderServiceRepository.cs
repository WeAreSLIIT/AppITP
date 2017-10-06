using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class OrderServiceRepository : Repository<OrderService>, IOrderServiceRepository
    {
        public OrderServiceRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
        }
    }
}
