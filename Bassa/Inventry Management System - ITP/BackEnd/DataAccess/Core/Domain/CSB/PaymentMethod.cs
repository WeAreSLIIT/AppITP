using System.Collections.Generic;

namespace DataAccess.Core.Domain
{
    public class PaymentMethod
    {
        public long PaymentMethodID { get; set; }
        public string PaymentMethodName { get; set; }
        public string PaymentMethodNote { get; set; }

        public ICollection<InvoicePaymentMethod> InvoicePaymentMethods { get; set; }

        public PaymentMethod()
        {
            InvoicePaymentMethods = new HashSet<InvoicePaymentMethod>();
        }
    }
}
