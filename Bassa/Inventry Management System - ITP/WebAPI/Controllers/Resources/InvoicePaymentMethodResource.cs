using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers.Resources
{
    public class InvoicePaymentMethodResource
    {
        [Required]
        [MaxLength(50)]
        public string Method { get; set; }
        [Required]
        public float Amount { get; set; }
    }
}