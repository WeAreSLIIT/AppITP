using System.Collections.Generic;

namespace Models.Core
{
    public class Invoice
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
        
        public Counter Counter { get; set; }
        
        public ICollection<InvoiceProduct> Products { get; set; }
        public ICollection<InvoicePaymentMethod> Payments { get; set; }

        public Invoice()
        {
            Products = new HashSet<InvoiceProduct>();
            Payments = new HashSet<InvoicePaymentMethod>();
        }
    }
}
