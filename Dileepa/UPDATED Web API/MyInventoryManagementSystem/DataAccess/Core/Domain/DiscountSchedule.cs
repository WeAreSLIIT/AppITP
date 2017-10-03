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
	public class DiscountSchedule
	{
		
		[Key]
		public long DiscountSheduleId { get; set; }
		[ForeignKey("DiscountType")]
		public long DiscountTypeId { get; set; }

		public DiscountType DiscountType { get; set; }

		
		public string DiscountShedulePublicId { get; set; }

		public string DiscountSheduleItemCode { set; get; }

		public float OriginalPrice { set; get; }
		public float PriceWithDiscount { set; get; }

		[Required(ErrorMessage = "Discount introduce date required ")]
		public long DiscountSheduleFrom { set; get; }

		[Required(ErrorMessage = "Discount expiration date required ")]
		public long DiscountSheduleTo { set; get; }

		[Required(ErrorMessage = "Discount amount required ")]
		public float DiscountAmount { set; get; }

		public  byte Method { get; set; }

		

		

		public  DiscountMethod DiscountMethod
		{
			get { return (DiscountMethod) (this.Method); }
			set { this.Method = (byte) value; }
		}


	}
}

public enum DiscountMethod : byte
	{

		fixedPrice = 1,
		percentage = 2

	}
	



	
