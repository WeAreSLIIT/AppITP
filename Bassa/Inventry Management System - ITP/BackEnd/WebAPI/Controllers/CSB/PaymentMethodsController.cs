using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net;
using DataAccess.Core;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using WebAPI.Controllers.Methods;
using WebAPI.Controllers.Resources;

namespace WebAPI.Controllers
{
    // api/PaymentMethods
    public class PaymentMethodsController : ApiController
    {
        private IUnitOfWork _unitOfWork;
        private PaymentMethodControllerMethods _paymentMethodControllerMethods;

        public PaymentMethodsController()
        {
            this._unitOfWork = new UnitOfWork();
            this._paymentMethodControllerMethods = new PaymentMethodControllerMethods(this._unitOfWork);
        }

        [HttpGet]
        public IHttpActionResult GetAllPaymentMethods()
        {
            try
            {
                ICollection<PaymentMethod> PaymentMethods = new List<PaymentMethod>();
                PaymentMethods = this._unitOfWork.PaymentMethods.GetAll().ToList();
                this._unitOfWork.Dispose();

                ICollection<PaymentMethodResource> PaymentMethodResources = new List<PaymentMethodResource>();
                PaymentMethodResources = this._paymentMethodControllerMethods.MapListPaymentMethodToListPaymentMethodResource(PaymentMethods);

                //if (PaymentMethodResources == null || PaymentMethodResources.Count == 0)
                //    return Content(HttpStatusCode.NoContent, "No Payment Method(s) to show");

                return Content(HttpStatusCode.OK, PaymentMethodResources);
            }
            catch
            {
                return Content(HttpStatusCode.Conflict, "Something went wrong");
            }
        }

        [HttpGet]
        public IHttpActionResult GetPaymentMethodByID(string Id)
        {
            try
            {
                PaymentMethod PaymentMethod = this._unitOfWork.PaymentMethods.Get(Id);

                PaymentMethodResource PaymentMethodResource = this._paymentMethodControllerMethods.MapPaymentMethodToPaymentMethodResource(PaymentMethod);

                if (PaymentMethodResource == null)
                    return Content(HttpStatusCode.NotFound, $"Payment Method, named '{Id}' not found");

                return Content(HttpStatusCode.OK, PaymentMethodResource);
            }
            catch
            {
                return Content(HttpStatusCode.Conflict, "Something went wrong");
            }
        }

        [Route("api/PaymentMethods/Search/{Key}")]
        [HttpGet]
        public IHttpActionResult SearchPaymentMethods(string Key)
        {
            try
            {
                if (Key == null || Key.Trim().Equals(String.Empty))
                    return Content(HttpStatusCode.NotAcceptable, "Seach key word not acceptable");

                Key = Key.Trim().ToLower();

                ICollection<PaymentMethod> PaymentMethods = new List<PaymentMethod>();
                PaymentMethods = this._unitOfWork.PaymentMethods.Search(pm => pm.PaymentMethodName.ToLower().Contains(Key) || pm.PaymentMethodNote.ToLower().Contains(Key)).ToList();

                ICollection<PaymentMethodResource> PaymentMethodResources = new List<PaymentMethodResource>();
                PaymentMethodResources = this._paymentMethodControllerMethods.MapListPaymentMethodToListPaymentMethodResource(PaymentMethods);

                if (PaymentMethodResources == null || PaymentMethodResources.Count == 0)
                    return Content(HttpStatusCode.NotFound, "No matching item(s) found");

                return Content(HttpStatusCode.OK, PaymentMethodResources);
            }
            catch
            {
                return Content(HttpStatusCode.Conflict, "Something went wrong");
            }
        }

        [HttpPost]
        public IHttpActionResult AddNewPaymentMethod([FromBody]PaymentMethodResource NewPaymentMethodResource)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PaymentMethod NewPaymentMethod = this._paymentMethodControllerMethods.MapCreatePaymentMethodResourceToPaymentMethod(NewPaymentMethodResource);

                    if (NewPaymentMethod == null)
                        return Content(HttpStatusCode.NotAcceptable, "Payment Method name already exists or data not acceptable");

                    this._unitOfWork.PaymentMethods.Add(NewPaymentMethod);
                    this._unitOfWork.TableVersions.DatabaseTableUpdated(DatabaseTable.PaymentMethod, TimeConverterMethods.GetCurrentTimeInLong());
                    this._unitOfWork.Complete();

                    return Content(HttpStatusCode.OK, "New Payment Method created");
                }
                else
                    return BadRequest();
            }
            catch
            {
                return Content(HttpStatusCode.Conflict, "Something went wrong");
            }
        }

        [HttpPut]
        public IHttpActionResult UpdatePaymentMethod([FromUri]string Id, [FromBody]PaymentMethodResource UpdatedPaymentMethodResource)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PaymentMethod CurrentPaymentMethod = this._unitOfWork.PaymentMethods.Get(Id);

                    if (CurrentPaymentMethod == null)
                        return Content(HttpStatusCode.NotFound, $"Payment Method, named '{Id}' not found");

                    if (!CurrentPaymentMethod.PaymentMethodName.Equals(UpdatedPaymentMethodResource.Name))
                        return Content(HttpStatusCode.Unauthorized, "Can't change Payment Method's Name");

                    if (CurrentPaymentMethod.PaymentMethodNote == null || (CurrentPaymentMethod.PaymentMethodNote.Trim()).Equals(String.Empty))
                        return Content(HttpStatusCode.Unauthorized, "Payment Method's Note can't be empty");

                    if (CurrentPaymentMethod.PaymentMethodNote.Equals(UpdatedPaymentMethodResource.Note.Trim()))
                        return Content(HttpStatusCode.OK, $"Payment Method named '{Id}' already up-to date");

                    CurrentPaymentMethod.PaymentMethodNote = UpdatedPaymentMethodResource.Note.Trim();
                    this._unitOfWork.TableVersions.DatabaseTableUpdated(DatabaseTable.PaymentMethod, TimeConverterMethods.GetCurrentTimeInLong());
                    this._unitOfWork.Complete();

                    return Content(HttpStatusCode.OK, $"Payment Method, named '{Id}' updated");
                }
                else
                    return BadRequest();

            }
            catch
            {
                return Content(HttpStatusCode.Conflict, "Something went wrong");
            }
        }

        [HttpDelete]
        public IHttpActionResult DeletePaymentMethodByID(string Id)
        {
            try
            {
                PaymentMethod PaymentMethod = this._unitOfWork.PaymentMethods.Get(Id);

                if (PaymentMethod == null)
                    return Content(HttpStatusCode.NotFound, $"Payment Method, named '{Id}' not found");

                this._unitOfWork.PaymentMethods.Remove(PaymentMethod);
                this._unitOfWork.TableVersions.DatabaseTableUpdated(DatabaseTable.PaymentMethod, TimeConverterMethods.GetCurrentTimeInLong());
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
