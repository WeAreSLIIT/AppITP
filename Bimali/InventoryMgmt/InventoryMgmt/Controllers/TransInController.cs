using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryMgmt.Controllers
{
    public class TransInController : ApiController
    {
        private UnitOfWork _unitOfWork;
        public TransInController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        [HttpPost]
        public IHttpActionResult InsertTransOut(TransInStock TransInStock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this._unitOfWork.TransInStocks.Add(TransInStock);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.Created, "Transfer-In stock details entered successfully");
        }

        [HttpDelete]
        public IHttpActionResult DeleteTransIn(int PublicId)
        {
            var TransInStockInDb = this._unitOfWork.TransInStocks.Get(PublicId);

            if (TransInStockInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{PublicId}' not found");
            //throw new HttpResponseException(HttpStatusCode.NotFound);
            this._unitOfWork.TransInStocks.Remove(TransInStockInDb);
            this._unitOfWork.Complete();

            return Content(HttpStatusCode.OK, $" '{PublicId}' Deleted");
        }
    }
}
