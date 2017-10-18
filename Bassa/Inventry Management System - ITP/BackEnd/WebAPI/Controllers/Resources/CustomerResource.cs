using System.Collections.Generic;

namespace WebAPI.Controllers.Resources
{
    public class CustomerResource
    {
        public long CustomerID { get; set; }

        public ICollection<InvoiceCustomerResource> Invoices { get; set; }

        public CustomerResource()
        {
            Invoices = new HashSet<InvoiceCustomerResource>();
        }
    }
}