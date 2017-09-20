using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management.Models.Discount
{
	public class DiscountSheduleRepository
	{
		IMS_DBContext ims = new IMS_DBContext();

		public List<DiscountShedule> GetDiscountShedule()
		{
			return ims.DiscountShedules.ToList();
		}
		public void InsertDiscountShedule(DiscountShedule dShedule)
		{
			ims.DiscountShedules.Add(dShedule);
			ims.SaveChanges();
		}
		public void UpadateDiscountShedule(DiscountShedule dShedule)
		{
			DiscountShedule discountSheduleUpdate = ims.DiscountShedules.FirstOrDefault(x => x.ItemCode == dShedule.ItemCode);
			discountSheduleUpdate.OriginalPrice = dShedule.OriginalPrice;
			discountSheduleUpdate.DiscountType = dShedule.DiscountType;
			discountSheduleUpdate.PriceWithDiscount = dShedule.PriceWithDiscount;
			discountSheduleUpdate.From = dShedule.From;
			discountSheduleUpdate.To = dShedule.To;
		}
		public void DeleteDiscountShedule(DiscountShedule dShedule)
		{
			DiscountShedule discountSheduleDelete= ims.DiscountShedules.FirstOrDefault(x => x.-temCode == dShedule.itemCode);
			ims.DiscountShedules.Remove(discountSheduleDelete);
			ims.SaveChanges();

		}
	
		
	}
}