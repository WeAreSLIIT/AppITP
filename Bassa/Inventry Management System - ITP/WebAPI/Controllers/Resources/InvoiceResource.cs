using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public long? PurchasedBy { get; set; }
        //public InvoiceDeal InvoiceDeal { get; set; }

        public ICollection<int> Products { get; set; }
        public ICollection<int> PaymentMethods { get; set; }

        public InvoiceResource()
        {
            Products = new HashSet<int>();
            PaymentMethods = new HashSet<int>();
        }
    }
}