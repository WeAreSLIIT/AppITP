using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class PromotionScheduleRepository : Repository<PromotionSchedule>, IPromotionScheduleRepository
    {
        public PromotionScheduleRepository(InventryMangementSystemDbContext context) : base(context)
        {

        }
    }
}
