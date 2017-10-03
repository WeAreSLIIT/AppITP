using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Inventory_Management.Models.Discount;
using Inventory_Management.Models.IRepositories;

namespace Inventory_Management.Repositories
{
	public class DiscountTypeRepository : Repository<DiscountType>,IDiscountTypeRepository
	{
		public DiscountTypeRepository(DbContext context) : base(context)
		{

		}
	}
}