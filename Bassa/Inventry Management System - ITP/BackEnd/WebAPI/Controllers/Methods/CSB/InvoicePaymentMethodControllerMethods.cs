using DataAccess.Core;
using DataAccess.Core.Domain;
using System.Collections.Generic;
using WebAPI.Controllers.Resources;
using System.Linq;

namespace WebAPI.Controllers.Methods
{
    public class InvoicePaymentMethodControllerMethods
    {
        private IUnitOfWork _unitOfWork;

        public InvoicePaymentMethodControllerMethods(IUnitOfWork UnitOfWork)
        {
            this._unitOfWork = UnitOfWork;
        }

        public ICollection<InvoicePaymentMethod> MapListInvoicePaymentMethodResourcesToListInvoicePaymentMethods(ICollection<InvoicePaymentMethodResource> InvoicePaymentMethodResources)
        {
            if (InvoicePaymentMethodResources == null || InvoicePaymentMethodResources.Count == 0)
                return null;

            InvoicePaymentMethodResource TempInvoicePaymentMethodResource = InvoicePaymentMethodResources.Where(ipmr => ipmr.Amount <= 0).SingleOrDefault();
            if (TempInvoicePaymentMethodResource != null)
                return null;

            ICollection<string> PaymentMethodNames = new List<string>();
            PaymentMethodNames = InvoicePaymentMethodResources.Select(ipmr => ipmr.Method).ToList();

            if (PaymentMethodNames == null || PaymentMethodNames.Count == 0)
                return null;

            ICollection<PaymentMethod> PaymentMethods = new List<PaymentMethod>();
            PaymentMethods = new PaymentMethodControllerMethods(this._unitOfWork).MapPaymentMethodNamesToPaymentMethods(PaymentMethodNames).ToList();

            if (PaymentMethods == null || PaymentMethods.Count == 0)
                return null;

            ICollection<InvoicePaymentMethod> InvoicePaymentMethods = new List<InvoicePaymentMethod>();

            foreach (PaymentMethod PaymentMethod in PaymentMethods)
            {
                float Amount = InvoicePaymentMethodResources.Where(ipmr => ipmr.Method == PaymentMethod.PaymentMethodName).Select(ipmr => ipmr.Amount).SingleOrDefault();

                InvoicePaymentMethod Temp = new InvoicePaymentMethod()
                {
                    Amount = Amount,
                    PaymentMethodID = PaymentMethod.PaymentMethodID
                };

                InvoicePaymentMethods.Add(Temp);
            }

            return InvoicePaymentMethods;
        }

        public ICollection<InvoicePaymentMethodResource> MapListInvoicePaymentMethodsToListInvoicePaymentMethodResources(ICollection<InvoicePaymentMethod> InvoicePaymentMethods)
        {
            if (InvoicePaymentMethods == null || InvoicePaymentMethods.Count == 0)
                return null;

            ICollection<InvoicePaymentMethodResource> InvoicePaymentMethodResources = new List<InvoicePaymentMethodResource>();

            ICollection<PaymentMethod> PaymentMethods = new List<PaymentMethod>();
            PaymentMethods = new PaymentMethodControllerMethods(this._unitOfWork).MapPaymentMethodIDsToPaymentMethods(InvoicePaymentMethods.Select(ipm => ipm.PaymentMethodID).ToList());

            foreach (InvoicePaymentMethod InvoicePaymentMethod in InvoicePaymentMethods)
            {
                string PaymentMethodName = PaymentMethods.Where(pm => pm.PaymentMethodID == InvoicePaymentMethod.PaymentMethodID).Select(pm => pm.PaymentMethodName).SingleOrDefault();

                InvoicePaymentMethodResource InvoicePaymentMethodResource = new InvoicePaymentMethodResource()
                {
                    Method = PaymentMethodName,
                    Amount = InvoicePaymentMethod.Amount
                };

                InvoicePaymentMethodResources.Add(InvoicePaymentMethodResource);
            }

            return InvoicePaymentMethodResources;
        }
    }
}