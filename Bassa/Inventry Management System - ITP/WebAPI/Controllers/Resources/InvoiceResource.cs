using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers.Resources
{
    public class InvoiceResource
    {
        [Required]
        [MaxLength(20)]
        public string InvoiceId { get; set; }
        public long Time { get; set; }
        public float FullPayment { get; set; }
        public float Discount { get; set; }
        public float Payed { get; set; }
        public float Balance { get; set; }

        public long IssuedBy { get; set; }

        public long? PurchasedBy { get; set; }
        public long? InvoiceDeal { get; set; }

        public ICollection<InvoiceProductResource> Products { get; set; }
        public ICollection<long> PaymentMethods { get; set; }

        public InvoiceResource()
        {
            Products = new HashSet<InvoiceProductResource>();
            PaymentMethods = new HashSet<long>();
        }
    }
}