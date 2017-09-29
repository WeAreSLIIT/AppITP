using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management.Models.Promotion
{
	public class PromotionShedule
	{
		public string PromoShedulePublicId { get; set; }
		public long PromoSheduleId { get; set; }
		public string PromoSheduleItemCode { set; get; }
		public string PromoSheduleName { set; get; }
		public string PromoSheduleType { set; get; }
		public string SpecialStock { set; get; }
		public string PromoSheduleDescription { set; get; }
		public long PromoSheduleFrom { set; get; }
		public long PromoSheduleTo { set; get; }


	}
}