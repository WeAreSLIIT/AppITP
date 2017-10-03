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
	public class DiscountTypeRepository : Repository<DiscountType>,IDiscountTypeRepository
	{
		public DiscountTypeRepository(MyInventoryManagementSystemDbContext context) : base(context)
		{

		}
	}
}
