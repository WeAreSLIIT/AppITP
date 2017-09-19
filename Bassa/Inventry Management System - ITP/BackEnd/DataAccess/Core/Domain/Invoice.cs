using System.Collections.Generic;

namespace DataAccess.Core.Domain
{
    public class Invoice
    {
        public long InvoiceID { get; set; }
        public string PublicID { get; set; }
        public long Time { get; set; }
        public float FullPayment { get; set; }
        public float Discount { get; set; }
        public float Payed { get; set; }
        public float Balance { get; set; }
        
        public long IssuedByID { get; set; } 
        public Employee IssuedBy { get; set; }

        public InvoiceCustomer InvoiceCustomer { get; set; }
        public InvoiceDeal InvoiceDeal { get; set; }

        public ICollection<InvoiceProduct> InvoiceProducts { get; set; }
        public ICollection<PaymentMethod> PaymentMethods { get; set; }

        public Invoice()
        {
            InvoiceProducts = new HashSet<InvoiceProduct>();
            PaymentMethods = new HashSet<PaymentMethod>();
        }
    }
}
