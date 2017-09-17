using System.Collections.Generic;

namespace DataAccess.Core.Domain
{
    public class InvoiceProduct
    {
        public long InvoiceID { get; set; }
        public ICollection<Invoice> Invoices { get; set; }

        public long ProductID { get; set; }
        public ICollection<PaymentMethod> PaymentMethods { get; set; }

        public float Quantity { get; set; }

        public InvoiceProduct()
        {
            Invoices = new HashSet<Invoice>();
            PaymentMethods = new HashSet<PaymentMethod>();
        }
    }
}
