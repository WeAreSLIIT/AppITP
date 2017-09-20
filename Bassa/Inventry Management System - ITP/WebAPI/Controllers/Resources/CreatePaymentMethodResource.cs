using System.Collections.Generic;

namespace WebAPI.Controllers.Resources
{
    public class CreatePaymentMethodResource
    {
        public long PaymentMethodID { get; private set; }
        public string PaymentMethodName { get; set; }
    }
}