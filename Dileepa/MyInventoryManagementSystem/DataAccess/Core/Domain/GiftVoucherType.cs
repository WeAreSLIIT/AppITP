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
	public class GiftVoucherType
	{
		
		[Key]
		public long GiftVoucherTypeId { set; get; }

		
		public string GiftVoucherTypePublicId { set; get; }

		[MyRequired(ErrorMessage = "Name Required")]
		public string GiftVoucherTypeName { set; get; }

		[MyRequired(ErrorMessage = "Amount Required")]
		public float GiftVoucherTypeAmount { set; get; }

		[MyRequired(ErrorMessage = "Description Required")]
		[StringLength(255)]
		public string GiftVoucherTypeDescription { set; get; }

		[MyRequired(ErrorMessage = "No Of Days Required")]
		public int GiftVoucherTypeNoOfDays { set; get; }

		[MyRequired(ErrorMessage = "Expiration Status Required")]
		public byte GiftVoucherExpiration { get; set; }

		public ICollection<GiftVoucherIssue> GifyVoucherIssues { get; set; }

		public  ExpireStatus  ExpireStatus

		{
			get { return (ExpireStatus)(this.GiftVoucherExpiration); }
			set { this.GiftVoucherExpiration = (byte)value; }
		}
	}
}
public enum ExpireStatus
{
	limited=1,
	unlimited = 2
	
}