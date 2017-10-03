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

		[MyRequired(ErrorMessage = "Discount Type Name Required ")]
		public string DiscountTypeName { get; set; }

		[MyRequired(ErrorMessage = "Discount Type TimeSpan Required ")]
		public long DiscountTimeSpan { get; set; }

		[MyRequired(ErrorMessage = "Discount Type Tax Required ")]
		public float DiscountTypeTax { get; set; }

		public ICollection<DiscountSchedule> DiscountSchedules { get; set; }
	}
}
