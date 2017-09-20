using System.Collections.Generic;

namespace DataAccess.Core.Domain
{
    public class InvoiceControlApp
    {
        public long ID { get; set; }
        public string Username { get; set; }

        public ICollection<Invoice> Invoices { get; set; }

        public InvoiceControlApp()
        {
            Invoices = new HashSet<Invoice>();
        }
    }
}
