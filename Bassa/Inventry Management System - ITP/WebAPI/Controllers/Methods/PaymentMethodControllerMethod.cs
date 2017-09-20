using DataAccess.Core;
using DataAccess.Core.Domain;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Controllers.Resources;

namespace WebAPI.Controllers.Methods
{
    public class PaymentMethodControllerMethod
    {
        private IUnitOfWork _unitOfWork;

        public PaymentMethodControllerMethod(IUnitOfWork UnitOfWork)
        {
            this._unitOfWork = UnitOfWork;
        }

        public PaymentMethod MapCreatePaymentMethodResourceToPaymentMethod(CreatePaymentMethodResource CreatePaymentMethodResource)
        {
            if (CreatePaymentMethodResource == null || CreatePaymentMethodResource.PaymentMethodID == 0)
                return null;

            PaymentMethod PaymentMethod = new PaymentMethod()
            {
                PaymentMethodID = CreatePaymentMethodResource.PaymentMethodID,
                PaymentMethodName = CreatePaymentMethodResource.PaymentMethodName
            };

            return PaymentMethod;
        }

        public bool ValidatePaymentMethodIDs(ICollection<long> PaymentMethodIDs)
        {
            if (PaymentMethodIDs == null || PaymentMethodIDs.Count == 0)
                return false;

            ICollection<PaymentMethod> PaymentMethods = this._unitOfWork.PaymentMethods.Search(pm => PaymentMethodIDs.Contains(pm.PaymentMethodID)).ToList();

            if (PaymentMethods == null || PaymentMethods.Count == 0 || PaymentMethods.Count != PaymentMethodIDs.Count)
                return false;

            return true;
        }
    }
}