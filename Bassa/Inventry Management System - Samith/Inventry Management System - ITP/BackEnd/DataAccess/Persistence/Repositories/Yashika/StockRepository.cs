using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        public StockRepository(InventryMangementSystemDbContext context) : base(context)
        {
        }
    }
}
