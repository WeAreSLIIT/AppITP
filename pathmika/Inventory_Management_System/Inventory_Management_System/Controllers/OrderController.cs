using Inventory_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Inventory_Management_System.Controllers
{
    public class OrderController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public OrderController()
        {
            this._unitOfWork = new UnitOfWork();

        }



        // GET api/Order
        [HttpGet]
        public IEnumerable<Order> GetOrder()
        {
            return this._unitOfWork.Orders.GetAll();
        }
        // GET api/Order/1
        [HttpGet]
        public Order GetOrder(int id)
        {
            var order = this._unitOfWork.Orders.Get(id);
            if (order == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return order;
        }

        //POST api/Order/2
        [System.Web.Http.HttpPost]
        public Order InsertOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            this._unitOfWork.Orders.Add(order);
            this._unitOfWork.Complete();
            return order;
        }

        //PUT api/Order/4
        [HttpPut]
        public void UpdateOrder(int id, Order ordder)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var orderInDb = this._unitOfWork.Orders.Get(id);

            if (orderInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            orderInDb.OrderDate = ordder.OrderDate;
            orderInDb.CompanyName = ordder.CompanyName; 

            this._unitOfWork.Complete();
        }

        //DELETE api/Order/4
        [HttpDelete]
        public void DeleteOrder(int id)
        {
            var orderInDb = this._unitOfWork.Orders.Get(id);

            if (orderInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            this._unitOfWork.Orders.Remove(orderInDb);
            this._unitOfWork.Complete();
        }

       
    }
}
