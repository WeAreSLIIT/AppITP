using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers.Resources
{
    public class CreateInvoiceResource
    {
        [Required]
        [MaxLength(20)]
        public string InvoiceId { get; set; }
        
        public long? Time { get; set; }

        [Required]
        public float FullPayment { get; set; }
        [Required]
        public float Discount { get; set; }
        [Required]
        public float Payed { get; set; }
        [Required]
        public float Balance { get; set; }

        [Required]
        public long IssuedBy { get; set; }

        public long? PurchasedBy { get; set; }
        public long? InvoiceDeal { get; set; }

        [Required]
        public CounterResource Counter { get; set; }

        [Required]
        public ICollection<InvoiceProductResource> Products { get; set; }
        [Required]
        public ICollection<string> PaymentMethods { get; set; }

        public CreateInvoiceResource()
        {
            Products = new HashSet<InvoiceProductResource>();
            PaymentMethods = new HashSet<string>();
        }
    }
}