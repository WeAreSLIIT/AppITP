using Models.Core;
using Models.Persistence;
using Styles.Controler;
using System.Collections.Generic;
using System.Linq;

namespace WPF.Mappings
{
    public class PaymentMethodMapping
    {
        public PaymentSearchItem PaymentMethodToPaymentSearchItem(PaymentMethod PaymentMethod)
        {
            return new PaymentSearchItem()
            {
                PaymentName = PaymentMethod.Name,
                PaymentDescription = PaymentMethod.Note
            };
        }

        public PaymentMethod PaymentMethodToPaymentSearchItem(PaymentSearchItem PaymentSearchItem)
        {
            if (PaymentSearchItem == null)
                return null;

            return InventryMangementSystemDbContext.PaymentMethods.SingleOrDefault(pm => pm.Name.Equals(PaymentSearchItem.PaymentName));
        }
    }
}
