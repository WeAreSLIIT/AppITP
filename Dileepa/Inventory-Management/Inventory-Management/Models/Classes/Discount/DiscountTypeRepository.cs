using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management.Models.Discount
{

	public class DiscountTypeRepository
	{
		IMS_DBContext ims = new IMS_DBContext();

		//Display
		public List<DiscountType> GetDiscount()
		{
			return ims.DiscountTypes.ToList();
		}

		//Insert 
		public void InsertDiscount(DiscountType discount)
		{
			ims.DiscountTypes.Add(discount);
			ims.SaveChanges();
		}
		//Update
		public void UpdateDiscount(DiscountType discount)
		{
			DiscountType discountUodate = ims.DiscountTypes.FirstOrDefault(x => x.id == discount.id);
			discountUodate.name = discount.name;
			discountUodate.period = discount.period;
			discountUodate.tax = discount.tax;

			ims.SaveChanges();
		}
		//Delete
		public void DeleteDiscount(DiscountType discount)
		{
			DiscountType discountDelete = ims.DiscountTypes.FirstOrDefault(x => x.id == discount.id);
			ims.DiscountTypes.Remove(discountDelete);
			ims.SaveChanges();
		}
	}
}
