using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Core.Domain
{
    public class PromotionType
    {
        [Key]
        public long PromoTypeId { set; get; }

        public string PromoTypePublicId { set; get; }

        [Required(ErrorMessage = "Name Required")]
        public string PromoTypeName { set; get; }

        [Required(ErrorMessage = "TimeSpan Required")]
        public long PromoTimeSpan { get; set; }

        public ICollection<PromotionSchedule> PromotionSchedules { get; set; }
    }
}
