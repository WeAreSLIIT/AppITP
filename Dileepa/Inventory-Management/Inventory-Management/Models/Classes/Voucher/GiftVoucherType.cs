using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management.Models.Voucher
{
	public class GiftVoucherType
	{
		public string GiftVoucherTypePublicId { set; get; }
		public long GiftVoucherTypeId { set; get; }
		public string GiftVoucherTypeName { set; get; }
		public float GiftVoucherTypeAmount { set; get; }
		public string GiftVoucherTypeDescription { set; get; }
		public int GiftVoucherTypeNoOfDays { set; get; }
	}
}