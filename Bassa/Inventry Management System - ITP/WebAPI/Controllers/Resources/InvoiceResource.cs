using System.Collections.Generic;

namespace WebAPI.Controllers.Resources
{
    public class InvoiceResource
    {
        public long InvoiceID { get; set; }
        public string InvoicePublicID { get; set; }
        public long Time { get; set; }
        public float FullPayment { get; set; }
        public float Discount { get; set; }
        public float Payed { get; set; }
        public float Balance { get; set; }

        public long IssuedByID { get; set; }
        public EmployeeResource IssuedBy { get; set; }

        public InvoiceCustomerResource InvoiceCustomer { get; set; }
        public InvoiceDealResource InvoiceDeal { get; set; }

        public ICollection<InvoiceProductResource> InvoiceProducts { get; set; }
        public ICollection<CreatePaymentMethodResource> PaymentMethods { get; set; }

        public InvoiceResource()
        {
            InvoiceProducts = new HashSet<InvoiceProductResource>();
            PaymentMethods = new HashSet<CreatePaymentMethodResource>();
        }
    }
}