using DataAccess.Core;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class SupplierPaymentController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public SupplierPaymentController()
        {
            this._unitOfWork = new UnitOfWork();

        }



        // GET api/SupplierPayment
        [HttpGet]
        public IEnumerable<SupplierPayment> GetSupplierPayment()
        {
            return this._unitOfWork.SupplierPayments.GetAll();
        }
        // GET api/SupplierPayment/1
        [HttpGet]
        public IHttpActionResult GetSupplier(int id)
        {
            var supplierpayment = this._unitOfWork.SupplierPayments.Get(id);
            if (supplierpayment == null)
            {
                Content(HttpStatusCode.NotFound, $"SupplierPayment of ID '{id}' is not found");
            }
            return Content(HttpStatusCode.Created, supplierpayment);
        }

        //POST api/SupplierPayment/2
        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertSupplierPayment(SupplierPayment supplierpayment)
        {
            if (!ModelState.IsValid)
            {
                Content(HttpStatusCode.NotAcceptable, "Insert valid payment details");
            }
            this._unitOfWork.SupplierPayments.Add(supplierpayment);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, "Insertion is successfull");
        }
    }
}
