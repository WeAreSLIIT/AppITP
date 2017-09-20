using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management.Models.Voucher
{
	public class RedeemGiftVoucher:GiftVoucherType
	{
		public long RedeemGiftVoucherId { get; set; }
		public string RedeemGiftVoucherPublicId { set; get; }

	}
	
}