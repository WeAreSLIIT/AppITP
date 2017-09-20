using System.Collections.Generic;

namespace WebAPI.Controllers.Resources
{
    public class PaymentMethodResource
    {
        public long PaymentMethodID { get; private set; }
        public string PaymentMethodName { get; set; }

        public ICollection<InvoiceResource> Invoices { get; set; }

        public PaymentMethodResource()
        {
            Invoices = new HashSet<InvoiceResource>();
        }
    }
}