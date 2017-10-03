using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace InventoryMgmt.Controllers
{
    public class RecountController : ApiController
    {
        private UnitOfWork _unitOfWork;

        public RecountController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        [HttpPut]
        public IHttpActionResult UpdateStatus(int Id, Recount RecountStock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var RecountStockInDb = this._unitOfWork.Recounts.Get(Id);

            if (RecountStockInDb == null)
                return Content(HttpStatusCode.NotFound, " '{Id}' not found");

            RecountStockInDb.Status = RecountStock.Status;

            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, " '{Id}' Updated");
             
        }
    }
}
