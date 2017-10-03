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
	public class PromotionType
	{
		
		[Key]
		public long PromoTypeId { set; get; }

		public string PromoTypePublicId { set; get; }

		[Required(ErrorMessage = "Name Required")]
		public string PromoTypeName { set; get; }

		[Required (ErrorMessage = "TimeSpan Required")]
		public long PromoTimeSpan { get; set; }

		public ICollection<PromotionSchedule> PromotionSchedules { get; set; }
	}
}
