using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_Management.IRepositories;
using Inventory_Management.Models.Promotion;

namespace Inventory_Management.Models.IRepositories
{
	public interface IPromotionTypeRepository : IRepository<PromotionType>
	{
	}
}