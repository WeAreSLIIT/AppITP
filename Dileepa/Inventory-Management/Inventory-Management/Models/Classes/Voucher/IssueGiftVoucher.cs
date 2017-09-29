using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management.Models.Voucher
{
	public class IssueGiftVoucher
	{
		public string IssueGiftVoucherPublicCode { set; get; }
		public long IssueGiftVoucherCode { set; get; }
		public string IssueGiftVoucherTypeId { get; set; }
		public float IssueGiftVoucherAmount { set; get; }
		public string IssueGiftVoucherTo { set; get; }
		public string IssueGiftVoucherEmail { set; get; }
		public int IssueGiftVoucherPhone { set; get; }
		public long IssueGiftVoucherSKU { set; get; }
			public enum Status
		{
			redeemed=1, 
			issued=2,
			expired=3,
			renewed=4
		}
	}
}