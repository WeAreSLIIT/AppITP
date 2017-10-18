using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Domain
{
    public class GiftVoucherType
    {

        [Key]
        public long GiftVoucherTypeId { set; get; }
        
        public string GiftVoucherTypePublicId { set; get; }

        [Required(ErrorMessage = "Name Required")]
        public string GiftVoucherTypeName { set; get; }

        [Required(ErrorMessage = "Amount Required")]
        public float GiftVoucherTypeAmount { set; get; }

        [Required(ErrorMessage = "Description Required")]
        [StringLength(255)]
        public string GiftVoucherTypeDescription { set; get; }

        [Required(ErrorMessage = "No Of Days Required")]
        public int GiftVoucherTypeNoOfDays { set; get; }

        [Required(ErrorMessage = "Expiration Status Required")]
        public byte GiftVoucherExpiration { get; set; }

        public ICollection<GiftVoucherIssue> GifyVoucherIssues { get; set; }

        public ExpireStatus ExpireStatus

        {
            get { return (ExpireStatus)(this.GiftVoucherExpiration); }
            set { this.GiftVoucherExpiration = (byte)value; }
        }
    }
}
