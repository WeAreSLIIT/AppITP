using System.Collections.Generic;

namespace DataAccess.Core.Domain
{
    public class Customer
    {
        public long CustomerID { get; set; }

        public ICollection<InvoiceCustomer> Invoices { get; set; }

        public Customer()
        {
            Invoices = new HashSet<InvoiceCustomer>();
        }
    }
}
