using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers.Resources
{
    public class InvoiceResource
    {
        public string InvoiceId { get; set; }
        public long Time { get; set; }
        public float FullPayment { get; set; }
        public float Discount { get; set; }
        public float Payed { get; set; }
        public float Balance { get; set; }
        
        public long IssuedBy { get; set; }
        public CounterResource Counter { get; set; }

        public long? PurchasedBy { get; set; }
        public long? InvoiceDeal { get; set; }
        
        public ICollection<ProductResoure> Products { get; set; }
        public ICollection<InvoicePaymentMethodResource> Payments { get; set; }

        public InvoiceResource()
        {
            Products = new HashSet<ProductResoure>();
            Payments = new HashSet<InvoicePaymentMethodResource>();
        }
    }
}