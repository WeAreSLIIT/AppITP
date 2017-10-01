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
    public class ReturnController : ApiController
    {
        private UnitOfWork _unitOfWork;
        public ReturnController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        [HttpPost]
        public IHttpActionResult InsertReturn(ReturnStock ReturnStock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this._unitOfWork.ReturnStocks.Add(ReturnStock);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.Created, "Details entered successfully");
        }

        [HttpGet]
        public IHttpActionResult GetStock(int StockId)
        {
            Stock StockDetails = this._unitOfWork.Stocks.Get(StockId);
            if (StockDetails == null)
            {
                return Content(HttpStatusCode.NotFound, "No matching item(s) found");
            }
            return Content(HttpStatusCode.Found, StockDetails);
        }

        [HttpDelete]
        public IHttpActionResult DeleteReturns(int PublicId)
        {
            var ReturnStockInDb = this._unitOfWork.ReturnStocks.Get(PublicId);

            if (ReturnStockInDb == null)
                return Content(HttpStatusCode.NotFound, " '{PublicId}' not found");
            //throw new HttpResponseException(HttpStatusCode.NotFound);
            this._unitOfWork.ReturnStocks.Remove(ReturnStockInDb);
            this._unitOfWork.Complete();

            return Content(HttpStatusCode.OK, " '{PublicId}' Deleted");
        }
    }
}
