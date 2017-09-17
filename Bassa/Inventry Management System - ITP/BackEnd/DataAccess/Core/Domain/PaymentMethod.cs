using System.Collections.Generic;

namespace DataAccess.Core.Domain
{
    public class PaymentMethod
    {
        public long PaymentMethodID { get; private set; }
        public string PaymentMethodName { get; set; }

        public ICollection<Invoice> Invoices { get; set; }

        public PaymentMethod()
        {
            Invoices = new HashSet<Invoice>();
        }
    }
}
