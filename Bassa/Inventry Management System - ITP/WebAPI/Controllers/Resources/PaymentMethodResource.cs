using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers.Resources
{
    public class PaymentMethodResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Note { get; set; }
    }
}