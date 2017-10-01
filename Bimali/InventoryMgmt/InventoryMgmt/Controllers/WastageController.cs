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
    public class WastageController : ApiController
    {
        private UnitOfWork _unitOfWork;
        public WastageController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        [HttpPost]
        public IHttpActionResult InsertTransOut(Wastage Wastage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this._unitOfWork.Wastages.Add(Wastage);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.Created, "Details entered successfully");
        }

        [HttpDelete]
        public IHttpActionResult DeleteWastage(int PublicId)
        {
            var WastageStockInDb = this._unitOfWork.Wastages.Get(PublicId);

            if (WastageStockInDb == null)
                return Content(HttpStatusCode.NotFound, " '{PublicId}' not found");
            //throw new HttpResponseException(HttpStatusCode.NotFound);
            this._unitOfWork.Wastages.Remove(WastageStockInDb);
            this._unitOfWork.Complete();

            return Content(HttpStatusCode.OK, " '{PublicId}' Deleted");
        }
    }
}
