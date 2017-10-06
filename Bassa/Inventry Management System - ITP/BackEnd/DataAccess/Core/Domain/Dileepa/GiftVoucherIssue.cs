using DataAccess.Core.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Required(ErrorMessage = "Discount expiration date required ")]
        public float IssueGiftVoucherAmount { set; get; }

        [Required(ErrorMessage = "Discount expiration date required ")]
        public string IssueGiftVoucherTo { set; get; }

        [Required(ErrorMessage = "Email Address required ")]
        [CustomerEmailAddress]
        public string IssueGiftVoucherEmail { set; get; }

        [Required(ErrorMessage = "Phone Number required ")]
        [PhoneNumber]
        public int IssueGiftVoucherPhone { set; get; }

        [Required(ErrorMessage = "SKU required ")]
        public long IssueGiftVoucherSKU { set; get; }

        public byte GiftVoucherStatus { get; set; }

        public Status Status
        {
            get { return (Status)(this.GiftVoucherStatus); }
            set { this.GiftVoucherStatus = 2; }
        }
    }
}
