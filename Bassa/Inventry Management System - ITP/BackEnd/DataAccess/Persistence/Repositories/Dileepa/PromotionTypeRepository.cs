using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence.Repositories
{
    public class PromotionTypeRepository : Repository<PromotionType>, IPromotionTypeRepository
    {
        public PromotionTypeRepository(InventryMangementSystemDbContext context) : base(context)
        {

        }
    }
}
