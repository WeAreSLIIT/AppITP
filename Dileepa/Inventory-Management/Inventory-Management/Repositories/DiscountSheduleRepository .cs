using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Inventory_Management.IRepositories;
using Inventory_Management.Models.Discount;
using Inventory_Management.Models.IRepositories;

namespace Inventory_Management.Repositories
{
	public class DiscountSheduleRepository : Repository<DiscountShedule> ,IDiscountSheduleRepository
	{
		public DiscountSheduleRepository(DbContext context) : base(context)
		{
		}

		

		public float PriceWithDiscount(float OriginalPrice, DiscountMethod status ,float DiscountAmount  )
		{

			if ( status==DiscountMethod.fixedPrice)
			{
				float PriceWithDiscount = OriginalPrice - DiscountAmount;
				return PriceWithDiscount;

			}
			else
			{
				float PriceWithDiscount = OriginalPrice - ((OriginalPrice * DiscountAmount) / 100);
				return PriceWithDiscount;
			}


		}
	}
}