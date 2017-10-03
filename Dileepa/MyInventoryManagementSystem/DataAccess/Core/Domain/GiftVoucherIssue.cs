using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Core.Validations;

namespace DataAccess.Core.Domain
{
	public class GiftVoucherIssue
	{
		[Key]
		public long IssueGiftVoucherCode { set; get; }

		[ForeignKey("GiftVoucherType")]
		public long GiftVoucherTypeId { set; get; }

		public GiftVoucherType GiftVoucherType { get; set; }

		
		public string IssueGiftVoucherPublicCode { set; get; }

		public string IssueGiftVoucherTypeId { get; set; }

		[MyRequired(ErrorMessage = "Discount expiration date required ")]
		public float IssueGiftVoucherAmount { set; get; }

		[MyRequired(ErrorMessage = "Discount expiration date required ")]
		public string IssueGiftVoucherTo { set; get; }

		[MyRequired(ErrorMessage = "Email Address required ")]
		[CustomerEmailAddress]
		public string IssueGiftVoucherEmail { set; get; }

		[MyRequired(ErrorMessage = "Phone Number required ")]
		[PhoneNumber]
		public int IssueGiftVoucherPhone { set; get; }

		[MyRequired(ErrorMessage = "SKU required ")]
		public long IssueGiftVoucherSKU { set; get; }

		public byte GiftVoucherStatus { get; set; }

		public Status Status
		{
			get { return (Status) (this.GiftVoucherStatus); }
			set { this.GiftVoucherStatus = 2; }
		}
	}
}
public enum Status:byte
{
	redeemed = 1,
	issued = 2,
	expired = 3,
	renewed = 4
}
