using Inventory_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Inventory_Management_System.Controllers
{
    public class OrderProductController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public OrderProductController()
        {
            this._unitOfWork = new UnitOfWork();

        }



        // GET api/Order
        [HttpGet]
        public IEnumerable<OrderProduct> GetOrderProduct()
        {
            return this._unitOfWork.OrderProducts.GetAll();
        }
        // GET api/Order/1
        [HttpGet]
        public IHttpActionResult GetOrderProduct(int id)
        {
            var orderpro = this._unitOfWork.OrderProducts.Get(id);
            if (orderpro == null)
            {
                Content(HttpStatusCode.NotFound, "No order found");
            }
            return Content(HttpStatusCode.OK, orderpro);
        }

        //POST api/Order/2
        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertSerOrder(OrderProduct orderpro)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.Created,"Insert a valid order ");
            }
            this._unitOfWork.OrderProducts.Add(orderpro);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK,"Insertion sucessfull");
        }

        //PUT api/Order/4
        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateOrderProduct(int id, Order ordder)
        {
            if (!ModelState.IsValid)
                return Content(HttpStatusCode.BadRequest, "Not valid");
            var orderInDb = this._unitOfWork.OrderProducts.Get(id);

            if (orderInDb == null)
                return Content(HttpStatusCode.NotFound, "Not found");

            orderInDb.OrderDate = ordder.OrderDate;
            orderInDb.CompanyName = ordder.CompanyName;

            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, "UpdatedSucessfully");
        }

        //DELETE api/Order/4
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteOrderProduct(int id)
        {
            var orderproInDb = this._unitOfWork.OrderProducts.Get(id);

            if (orderproInDb == null)
                return Content(HttpStatusCode.NotFound,"Not found");
            this._unitOfWork.OrderProducts.Remove(orderproInDb);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK,"sucessfully removed");
        }
    }
}
