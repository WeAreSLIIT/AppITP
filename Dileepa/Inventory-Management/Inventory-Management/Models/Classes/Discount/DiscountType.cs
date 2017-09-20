using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management.Models.Discount
{
	public class DiscountType
	{
		public long DiscountTypeId { get; set; }
		public string DiscountTypePublicId { get; set; }
		public string DiscountTypeName { get; set; }
		public long DiscountTimeSpan { get; set; }
		public float DiscountTypeTax { get; set; }

	}
}