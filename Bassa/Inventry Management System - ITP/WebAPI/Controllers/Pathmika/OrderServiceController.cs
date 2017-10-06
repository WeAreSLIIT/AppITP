using DataAccess.Core;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class OrderServiceController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public OrderServiceController()
        {
            this._unitOfWork = new UnitOfWork();

        }



        // GET api/Order
        [HttpGet]
        public IEnumerable<OrderService> GetOrderService()
        {
            return this._unitOfWork.OrderServices.GetAll();
        }
        // GET api/Order/1
        [HttpGet]
        public IHttpActionResult GetOrderServices(int id)
        {
            var orderser = this._unitOfWork.OrderServices.Get(id);
            if (orderser == null)
            {
                return Content(HttpStatusCode.NotFound, "NotFound");
            }
            return Content(HttpStatusCode.OK, orderser);
        }

        //POST api/Order/2
        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertOrderService(OrderService orderservice)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, "Not valid");
            }
            this._unitOfWork.OrderServices.Add(orderservice);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, "Insertion Successfull");
        }

        //PUT api/Order/4
        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateOrderService(int id, OrderService ordderservice)
        {
            if (!ModelState.IsValid)
                return Content(HttpStatusCode.BadRequest, "Error");
            var orderserviceInDb = this._unitOfWork.OrderServices.Get(id);

            if (orderserviceInDb == null)
                return Content(HttpStatusCode.NotFound, "Error");

            orderserviceInDb.ServiceType = ordderservice.ServiceType;


            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, "Update sucessfull");
        }

        //DELETE api/Order/4
        [HttpDelete]
        public IHttpActionResult DeleteOrderService(int id)
        {
            var orderserviceInDb = this._unitOfWork.OrderServices.Get(id);

            if (orderserviceInDb == null)
                Content(HttpStatusCode.NotFound, "Not Found");
            this._unitOfWork.OrderServices.Remove(orderserviceInDb);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, "Successfully removed");
        }
    }
}
