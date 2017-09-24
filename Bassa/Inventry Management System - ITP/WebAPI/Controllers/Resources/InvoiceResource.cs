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
        public long BranchID { get; set; }

        public long? PurchasedBy { get; set; }
        public long? InvoiceDeal { get; set; }
        
        public ICollection<string> Products { get; set; }
        public ICollection<string> PaymentMethods { get; set; }

        public InvoiceResource()
        {
            Products = new HashSet<string>();
            PaymentMethods = new HashSet<string>();
        }
    }
}