using DataAccess.Core;
using DataAccess.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WebAPI.Controllers.Resources;

namespace WebAPI.Controllers.Methods
{
    public class PaymentMethodControllerMethods
    {
        private IUnitOfWork _unitOfWork;
        private readonly string _paymentMethodNameRegexString = @"^[a-z0-9_@.-]{1,50}$";
        private Regex _paymentMethodNamePattern;

        public PaymentMethodControllerMethods(IUnitOfWork UnitOfWork)
        {
            this._unitOfWork = UnitOfWork;
            this._paymentMethodNamePattern = new Regex(this._paymentMethodNameRegexString, RegexOptions.IgnoreCase);
        }

        #region Map CreatePaymentMethodResource to PaymentMethod

        public PaymentMethod MapCreatePaymentMethodResourceToPaymentMethod(PaymentMethodResource PaymentMethodResource)
        {
            if (PaymentMethodResource == null || PaymentMethodResource.Name == null || (PaymentMethodResource.Name.Trim()).Equals(String.Empty) ||
                PaymentMethodResource.Note == null || (PaymentMethodResource.Note.Trim()).Equals(String.Empty))
                return null;

            if (!this._paymentMethodNamePattern.IsMatch(PaymentMethodResource.Name.Trim()))
                return null;

            PaymentMethod CheckPaymentMethod = this._unitOfWork.PaymentMethods.Get(PaymentMethodResource.Name);

            if (CheckPaymentMethod != null)
                return null;

            PaymentMethod PaymentMethod = new PaymentMethod()
            {
                PaymentMethodName = PaymentMethodResource.Name.Trim(),
                PaymentMethodNote = PaymentMethodResource.Note.Trim()
            };

            return PaymentMethod;
        }

        #endregion

        #region Map PaymentMethodResource to PaymentMethod

        public PaymentMethod MapPaymentMethodResourceToPaymentMethod(PaymentMethodResource PaymentMethodResource)
        {
            if (PaymentMethodResource == null || PaymentMethodResource.Name == null || (PaymentMethodResource.Name.Trim()).Equals(String.Empty) ||
                PaymentMethodResource.Note == null || (PaymentMethodResource.Note.Trim()).Equals(String.Empty))
                return null;

            PaymentMethod CheckPaymentMethod = this._unitOfWork.PaymentMethods.Get(PaymentMethodResource.Name.Trim());

            if (CheckPaymentMethod == null)
                return null;

            PaymentMethod PaymentMethod = new PaymentMethod()
            {
                PaymentMethodName = PaymentMethodResource.Name.Trim(),
                PaymentMethodNote = PaymentMethodResource.Note.Trim()
            };

            return PaymentMethod;
        }

        #endregion

        #region Map PaymentMethod to PaymentMethodResource

        public PaymentMethodResource MapPaymentMethodToPaymentMethodResource(PaymentMethod PaymentMethod)
        {
            if (PaymentMethod == null || PaymentMethod.PaymentMethodName == null || PaymentMethod.PaymentMethodName.Equals(String.Empty))
                return null;

            PaymentMethodResource PaymentMethodResource = new PaymentMethodResource()
            {
                Name = PaymentMethod.PaymentMethodName,
                Note = PaymentMethod.PaymentMethodNote
            };

            return PaymentMethodResource;
        }

        #endregion

        #region Map List of PaymentMethodResource to List of PaymentMethod

        public ICollection<PaymentMethod> MapListPaymentMethodResourceToListPaymentMethod(ICollection<PaymentMethodResource> PaymentMethodResources)
        {
            if (PaymentMethodResources == null || PaymentMethodResources.Count == 0)
                return null;

            ICollection<string> PaymentMethodNames = new List<string>();

            PaymentMethodNames = PaymentMethodResources.Select(pmr => pmr.Name).ToList();

            if (this.ValidatePaymentMethodNames(PaymentMethodNames))
            {
                return this._unitOfWork.PaymentMethods.Search(pm => PaymentMethodNames.Contains(pm.PaymentMethodName)).ToList();
            }
            else
                return null;
        }

        #endregion

        #region Map List of PaymentMethod to List of PaymentMethodResource

        public ICollection<PaymentMethodResource> MapListPaymentMethodToListPaymentMethodResource(ICollection<PaymentMethod> PaymentMethods)
        {
            if (PaymentMethods == null || PaymentMethods.Count == 0)
                return null;

            ICollection<PaymentMethodResource> PaymentMethodResources = new List<PaymentMethodResource>();

            foreach (PaymentMethod PaymentMethod in PaymentMethods)
            {
                PaymentMethodResource PaymentMethodResource = this.MapPaymentMethodToPaymentMethodResource(PaymentMethod);

                if (PaymentMethodResource == null)
                    return null;

                PaymentMethodResources.Add(PaymentMethodResource);
            }

            return PaymentMethodResources;
        }

        #endregion

        #region Validate List of PaymentMethod IDs

        public bool ValidatePaymentMethodIDs(ICollection<long> PaymentMethodIDs)
        {
            if (PaymentMethodIDs == null || PaymentMethodIDs.Count == 0)
                return false;

            ICollection<PaymentMethod> PaymentMethods = this._unitOfWork.PaymentMethods.Search(pm => PaymentMethodIDs.Contains(pm.PaymentMethodID)).ToList();

            if (PaymentMethods == null || PaymentMethods.Count == 0 || PaymentMethods.Count != PaymentMethodIDs.Count)
                return false;

            return true;
        }

        #endregion

        #region Validate List of PaymentMethod Names

        public bool ValidatePaymentMethodNames(ICollection<string> PaymentMethodNames)
        {
            if (PaymentMethodNames == null || PaymentMethodNames.Count == 0)
                return false;

            ICollection<PaymentMethod> PaymentMethods = this._unitOfWork.PaymentMethods.Search(pm => PaymentMethodNames.Contains(pm.PaymentMethodName)).ToList();

            if (PaymentMethods == null || PaymentMethods.Count == 0 || PaymentMethods.Count != PaymentMethodNames.Count)
                return false;

            return true;
        }

        #endregion
    }
}