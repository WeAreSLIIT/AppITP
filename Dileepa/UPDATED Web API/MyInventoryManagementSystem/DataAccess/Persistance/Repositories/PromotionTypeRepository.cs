using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistance.Repositories
{
	public class PromotionTypeRepository : Repository<PromotionType>, IPromotionTypeRepository
	{
		public PromotionTypeRepository(MyInventoryManagementSystemDbContext context) : base(context)
		{

		}
	}
}
