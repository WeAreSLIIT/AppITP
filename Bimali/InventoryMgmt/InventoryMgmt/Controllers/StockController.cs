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
    public class StockController : ApiController
    {
        private UnitOfWork _unitOfWork;

        public StockController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        [Route("api/Stock/Get")]
        [HttpGet]
        public IHttpActionResult GetStock()
        {
            ICollection<Stock> Stocks = new List<Stock>();
            Stocks = this._unitOfWork.Stocks.GetAll().ToList();
            if (Stocks == null || Stocks.Count == 0)
                return Content(HttpStatusCode.NotFound, "No Stock(s) to show");

            return Content(HttpStatusCode.Found, Stocks);
        }

        //[HttpGet]
        //public IHttpActionResult GetStock(int PublicStockId )
        //{
        //    Stock Stock = this._unitOfWork.Stocks.Get(PublicStockId);
        //    if (Stock == null)
        //    {
        //        return Content(HttpStatusCode.NotFound, "No matching item(s) found");
        //    }
        //    return Content(HttpStatusCode.Found, Stock);
        //}

        [Route("api/Stock/GetStock/{id}")]
        [HttpGet]
        public IHttpActionResult GetStock(int id)
        {

            var Stock = this._unitOfWork.Stocks.Get(id);
            if (Stock == null)
            {
                return Content(HttpStatusCode.NotFound, "No matching item(s) found");
            }
            return Content(HttpStatusCode.Found, Stock);
        }

        [Route("api/Stock/Search/{ItemId}")]
        [HttpGet]
        public IHttpActionResult GetStockByItem([FromUri]string ItemId)
        {
            //return Ok();
            if (ItemId == null || ItemId.Trim().Equals(String.Empty))
                return Content(HttpStatusCode.NotAcceptable, "Search Item Code not valid");

            ICollection<Stock> Stocks = new List<Stock>();
            Stocks = this._unitOfWork.Stocks.Search(s=>s.PublicItemCode.Contains(ItemId)).ToList();
            if (Stocks == null )
            {
                return Content(HttpStatusCode.NotFound, "No matching item(s) found");
            }
            return Content(HttpStatusCode.Found, Stocks);
        }


        [HttpPost]
        public IHttpActionResult InsertStock(Stock NewStock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this._unitOfWork.Stocks.Add(NewStock);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.Created, "New Stock Inserted");
        }

        [HttpPut]
        public IHttpActionResult UpdateStock(Stock Stock)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var StockInDb = this._unitOfWork.Stocks.Get((int)Stock.StockID);

            if (StockInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{Stock.PublicStockID}' not found");

            StockInDb.UnitPrice = Stock.UnitPrice;

            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, $" '{Stock.PublicStockID}' Updated");
        }

        [HttpPut]
        public IHttpActionResult IssueGoods(int Quantity,Stock Stock)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var StockInDb = this._unitOfWork.Stocks.Get((int)Stock. StockID);
            if (StockInDb == null)
                return Content(HttpStatusCode.NotFound, $"'{Stock.PublicStockID}' not found");

            StockInDb.PresentQty = StockInDb.PresentQty - Quantity;

            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, $"'{Stock.PublicStockID}' Updated");
        }

        [HttpDelete]
    
        public IHttpActionResult DeleteStock(int id)
        {
           var StockInDb = this._unitOfWork.Stocks.Get(id);
            if (StockInDb==null)
                return Content(HttpStatusCode.NotFound, $" '{id}' not found");
            this._unitOfWork.Stocks.Remove(StockInDb);
            this._unitOfWork.Complete();


            return Content(HttpStatusCode.OK, $" '{id}' Deleted");
        }



    }
}
