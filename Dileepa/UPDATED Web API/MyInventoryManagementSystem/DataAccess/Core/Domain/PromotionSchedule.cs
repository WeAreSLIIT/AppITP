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
	public class PromotionSchedule
	{
		
		[Key]
		public long PromoSheduleId { get; set; }

		[ForeignKey("PromotionType")]
		public long PromoTypeId { set; get; }

		public PromotionType PromotionType { get; set; }

		public string PromoShedulePublicId { get; set; }

		[Required (ErrorMessage = "Item Code Required")]
		public string PromoSheduleItemCode { set; get; }

		[Required(ErrorMessage = "Name Required")]
		public string PromoSheduleName { set; get; }

		[Required(ErrorMessage = "Type Required")]
		public string PromoSheduleType { set; get; }

		public string SpecialStock { set; get; }

		[StringLength(255)]
		public string PromoSheduleDescription { set; get; }

		[Required(ErrorMessage = "Promotion Introduce Date Required")]
		public long PromoSheduleFrom { set; get; }

		[Required(ErrorMessage = "Promotion Expiry Date Required")]
		public long PromoSheduleTo { set; get; }

		
	}
}
