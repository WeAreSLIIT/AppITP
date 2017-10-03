using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Core.Validations;

namespace DataAccess.Core.Domain
{
	public class DiscountType
	{
		[Key]
		public long DiscountTypeId { get; set; }

		public string DiscountTypePublicId { get; set; }

		[Required(ErrorMessage = "Discount Type Name Required ")]
		public string DiscountTypeName { get; set; }

		[Required(ErrorMessage = "Discount Type TimeSpan Required ")]
		public long DiscountTimeSpan { get; set; }

		[Required(ErrorMessage = "Discount Type Tax Required ")]
		public float DiscountTypeTax { get; set; }

		 ICollection<DiscountSchedule> DiscountSchedules { get; set; }
	}
}
