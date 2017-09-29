using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management.Models.Discount
{
	public class DiscountShedule
	{
		public string DiscountShedulePublicId { get; set; }
		public long DiscountSheduleId { get; set; }
		public string DiscountSheduleItemCode { set; get; }
		public float OriginalPrice { set; get; }
		public float PriceWithDiscount { set; get; }
		public long DiscountSheduleFrom { set; get; }
		public long DiscountSheduleTo { set; get; }
		public float DiscountAmount { set; get; }
		public byte Method { get; set; }
		public DiscountType DiscountType { get; set; }


		public DiscountMethod DiscountMethod
		{
			get { return (DiscountMethod)(this.Method); }
			set { this.Method = (byte) value; } 
		}
	}

	}

	public enum DiscountMethod:byte
		{

		fixedPrice=1,
		percentage=2

		}
//float ReducePrice()
		
	
}