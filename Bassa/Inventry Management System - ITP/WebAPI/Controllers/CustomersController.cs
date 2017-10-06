using DataAccess.Core;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class CustomersController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public CustomersController()
        {
            this._unitOfWork = new UnitOfWork();

        }

        // Get api/customer
        public IHttpActionResult GetCustomer()
        {
            ICollection<Customer> customer = new List<Customer>();
            customer = this._unitOfWork.Customers.GetAll().ToList();

            if (customer == null || customer.Count == 0)
                return Content(HttpStatusCode.NotFound, "No Customer(s) to show");

            return Content(HttpStatusCode.Found, customer);
        }
        // GET api/customer/1
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = this._unitOfWork.Customers.Get(id);
            if (customer == null)
            {
                return Content(HttpStatusCode.NotFound, "No matching results found");
            }
            return Content(HttpStatusCode.Found, customer);

        }

        //POST api/customer
        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this._unitOfWork.Customers.Add(customer);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.Created, "New Customer Added");


        }
        // PUT api/customer/4
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customerInDb = this._unitOfWork.Customers.Get(id);

            if (customerInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{id}' not found");
            customerInDb.FirstName = customer.FirstName;
            customerInDb.LastName = customer.LastName;
            customerInDb.Email = customer.Email;
            customerInDb.City = customer.City;
            customerInDb.DOB = customer.DOB;
            customerInDb.Phone = customer.Phone;
            customerInDb.Password = customer.Password;

            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, $"'{id}' Updated");
        }

        //DELETE api/customer/4
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = this._unitOfWork.Customers.Get(id);

            if (customerInDb == null)
                return Content(HttpStatusCode.NotFound, $"'{id}' not found");
            this._unitOfWork.Customers.Remove(customerInDb);
            this._unitOfWork.Complete();

            return Content(HttpStatusCode.OK, $"'{id}' Deleted");
        }
    }
}
