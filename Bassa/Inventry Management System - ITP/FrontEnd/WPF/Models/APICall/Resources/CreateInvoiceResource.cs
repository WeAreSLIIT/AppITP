using System.Collections.Generic;

namespace Models.APICall.Resources
{
    public class CreateInvoiceResource
    {
        public string InvoiceId { get; set; }

        public long? Time { get; set; }
        
        public float FullPayment { get; set; }
        public float Discount { get; set; }
        public float Payed { get; set; }
        public float Balance { get; set; }
        
        public long IssuedBy { get; set; }

        public long? PurchasedBy { get; set; }
        public long? InvoiceDeal { get; set; }
        
        public CounterResource Counter { get; set; }
        
        public ICollection<InvoiceProductResource> Products { get; set; }
        public ICollection<InvoicePaymentMethodResource> Payments { get; set; }

        public CreateInvoiceResource()
        {
            Products = new HashSet<InvoiceProductResource>();
            Payments = new HashSet<InvoicePaymentMethodResource>();
        }
    }
}
