using DataAccess.Core;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net;
using WebAPI.Controllers.Methods;
using WebAPI.Controllers.Resources;
using System;

namespace WebAPI.Controllers
{
    public class PaymentMethodController : ApiController
    {
        private IUnitOfWork _unitOfWork;
        private PaymentMethodControllerMethods _paymentMethodControllerMethods;

        public PaymentMethodController()
        {
            this._unitOfWork = new UnitOfWork();
            this._paymentMethodControllerMethods = new PaymentMethodControllerMethods(this._unitOfWork);
        }

        public IHttpActionResult Get()
        {
            try
            {
                ICollection<PaymentMethod> PaymentMethods = new List<PaymentMethod>();
                PaymentMethods = this._unitOfWork.PaymentMethods.GetAll().ToList();
                this._unitOfWork.Dispose();

                ICollection<PaymentMethodResource> PaymentMethodResources = new List<PaymentMethodResource>();
                PaymentMethodResources = this._paymentMethodControllerMethods.MapListPaymentMethodToListPaymentMethodResource(PaymentMethods);

                if (PaymentMethodResources == null || PaymentMethodResources.Count == 0)
                    return Content(HttpStatusCode.NoContent, "No Payment Method(s) to show");

                return Content(HttpStatusCode.Found, PaymentMethodResources);
            }
            catch
            {
                return Content(HttpStatusCode.Conflict, "Something went wrong");
            }
        }

        public IHttpActionResult Get(string Id)
        {
            try
            {
                PaymentMethod PaymentMethod = this._unitOfWork.PaymentMethods.Get(Id);

                PaymentMethodResource PaymentMethodResource = this._paymentMethodControllerMethods.MapPaymentMethodToPaymentMethodResource(PaymentMethod);

                if (PaymentMethodResource == null)
                    return Content(HttpStatusCode.NotFound, $"Payment Method, named '{Id}' not found");

                return Content(HttpStatusCode.Found, PaymentMethodResource);
            }
            catch
            {
                return Content(HttpStatusCode.Conflict, "Something went wrong");
            }
        }

        public IHttpActionResult Post([FromBody]PaymentMethodResource NewPaymentMethodResource)
        {
            try
            {
                PaymentMethod NewPaymentMethod = this._paymentMethodControllerMethods.MapCreatePaymentMethodResourceToPaymentMethod(NewPaymentMethodResource);

                if (NewPaymentMethod == null)
                    return Content(HttpStatusCode.NotAcceptable, "Payment Method name already exists or data not acceptable");

                this._unitOfWork.PaymentMethods.Add(NewPaymentMethod);
                this._unitOfWork.Complete();

                return Content(HttpStatusCode.Created, "New Payment Method created");
            }
            catch
            {
                return Content(HttpStatusCode.Conflict, "Something went wrong");
            }
        }

        public IHttpActionResult Put([FromUri]string Id, [FromBody]PaymentMethodResource UpdatedPaymentMethodResource)
        {
            try
            {
                PaymentMethod CurrentPaymentMethod = this._unitOfWork.PaymentMethods.Get(Id);

                if (CurrentPaymentMethod == null)
                    return Content(HttpStatusCode.NotFound, $"Payment Method, named '{Id}' not found");

                if (!CurrentPaymentMethod.PaymentMethodName.Equals(UpdatedPaymentMethodResource.Name))
                    return Content(HttpStatusCode.Unauthorized, "Can't change Payment Method's Name");

                if (CurrentPaymentMethod.PaymentMethodNote == null || (CurrentPaymentMethod.PaymentMethodNote.Trim()).Equals(String.Empty))
                    return Content(HttpStatusCode.Unauthorized, "Payment Method's Note can't be empty");

                if (CurrentPaymentMethod.PaymentMethodNote.Equals(UpdatedPaymentMethodResource.Note.Trim()))
                    return Content(HttpStatusCode.NotModified, $"Payment Method named '{Id}' already up-to date");

                CurrentPaymentMethod.PaymentMethodNote = UpdatedPaymentMethodResource.Note;
                this._unitOfWork.Complete();

                return Content(HttpStatusCode.OK, $"Payment Method, named '{Id}' updated");
            }
            catch
            {
                return Content(HttpStatusCode.Conflict, "Something went wrong");
            }
        }

        public IHttpActionResult Delete(string Id)
        {
            try
            {
                PaymentMethod PaymentMethod = this._unitOfWork.PaymentMethods.Get(Id);

                if (PaymentMethod == null)
                    return Content(HttpStatusCode.NotFound, $"Payment Method, named '{Id}' not found");

                this._unitOfWork.PaymentMethods.Remove(PaymentMethod);
                this._unitOfWork.Complete();

                return Content(HttpStatusCode.OK, $"Payment Method, named '{Id}' Deleted");
            }
            catch
            {
                return Content(HttpStatusCode.Conflict, "Something went wrong");
            }
        }
    }
}
