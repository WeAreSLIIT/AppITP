using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management.Models.Promotion
{
	public class PromotionSheduleRepository
	{
		IMS_DBContext ims = new IMS_DBContext();
		public List<PromotionShedule> promotionShedule()
		{
			return ims.PromotionShedules.ToList();
		}
		public void InsertPromotionShedule(PromotionShedule promotionShedule)
		{
			ims.PromotionShedules.Add(promotionShedule);
			ims.SaveChanges();
		}
		public void UpdatePromotionShedule(PromotionShedule promotionShedule)
		{
			PromotionShedule PromotionSheduleUpdate = ims.PromotionShedules.FirstOrDefault(x => x.itemCode == promotionShedule.itemCode);
			PromotionSheduleUpdate.name = promotionShedule.name;
			PromotionSheduleUpdate.specialStock = promotionShedule.specialStock;
			PromotionSheduleUpdate.description = promotionShedule.description;
			PromotionSheduleUpdate.type = promotionShedule.type;
			PromotionSheduleUpdate.from = promotionShedule.from;
			PromotionSheduleUpdate.to = promotionShedule.to;

			ims.SaveChanges();
		}
		public void DeletePromotionShedule(PromotionShedule promotionShedule)
		{
			PromotionShedule PromotionSheduleDelete= ims.PromotionShedules.FirstOrDefault(x => x.itemCode == promotionShedule.itemCode);
			ims.PromotionShedules.Remove(promotionShedule);
			ims.SaveChanges();
		}
	}
}