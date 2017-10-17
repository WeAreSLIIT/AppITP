using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class DiscountTypeRepository : Repository<DiscountType>, IDiscountTypeRepository
    {
        public DiscountTypeRepository(InventryMangementSystemDbContext context) : base(context)
        {

        }
    }
}
