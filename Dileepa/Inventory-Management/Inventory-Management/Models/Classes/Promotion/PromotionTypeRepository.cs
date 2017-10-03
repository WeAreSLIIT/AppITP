using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management.Models.Promotion
{
	public class PromotionTypeRepository
	{
		IMS_DBContext ims = new IMS_DBContext();

		public List<PromotionType>GetPromotionType()
		{
			return ims.PromotionTypes.ToList();
		}

		public void InsertPromotionType(PromotionType promotionType)
		{
			ims.PromotionTypes.Add(promotionType);
			ims.SaveChanges();
		}
		public void UpdatePromotionType(PromotionType promotionType)
		{
			PromotionType promotionTypeUpdate = ims.PromotionTypes.FirstOrDefault(x => x.id == promotionType.id);
			promotionTypeUpdate.name = promotionType.name;
			promotionTypeUpdate.from = promotionType.from;
			promotionTypeUpdate.to = promotionType.to;

			ims.SaveChanges();
		}
		public void DeletePromotionType(PromotionType promotionType)
		{
			PromotionType promotionTypeUpdate = ims.PromotionTypes.FirstOrDefault(x => x.id == promotionType.id);
			ims.PromotionTypes.Remove(promotionTypeUpdate);
			ims.SaveChanges();
		}
	}
}