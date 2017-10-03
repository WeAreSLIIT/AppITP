using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management.Models.Promotion
{
	public class PromotionType
	{
		public string PromoTypePublicId { set; get; }
		public long PromoTypeId { set; get; }
		public string PromoTypeName { set; get; }
		public long PromoTimeSpan { get; set; }

	}
}