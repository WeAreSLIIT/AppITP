using DataAccess.Core;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class CreditsController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public CreditsController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        // Get api/credit
        public IHttpActionResult GetCredit()
        {
            ICollection<Credit> credit = new List<Credit>();
            credit = this._unitOfWork.Credits.GetAll().ToList();

            if (credit == null || credit.Count == 0)
                return Content(HttpStatusCode.NotFound, "No Credit(s) to show");

            return Content(HttpStatusCode.Found, credit);
        }

        // GET api/credit/1
        [HttpGet]
        public IHttpActionResult GetCredit(int id)
        {
            var credit = this._unitOfWork.Credits.Get(id);
            if (credit == null)
            {
                return Content(HttpStatusCode.NotFound, "No matching results found");
            }
            return Content(HttpStatusCode.Found, credit);

        }

        //POST api/credit
        [HttpPost]
        public IHttpActionResult InsertCredit(Credit credit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this._unitOfWork.Credits.Add(credit);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.Created, "New Credit Limit Added");
        }

        // PUT api/credit/4
        [HttpPut]
        public IHttpActionResult UpdateCredit(long id, Credit credit)
        {

            if (!ModelState.IsValid)
                return BadRequest();
            var customer = this._unitOfWork.Customers.Get(id);
            var creditInDb = this._unitOfWork.Credits.Get(customer.Credits.CustomerID);

            if (creditInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{id}' not found");
            creditInDb.CreditLimit = credit.CreditLimit;
            creditInDb.ExpireDate = credit.ExpireDate;



            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, $"'{id}' Updated");
        }

        //DELETE api/credit/4
        [HttpDelete]
        public IHttpActionResult DeleteCredit(int id)
        {
            var creditInDb = this._unitOfWork.Credits.Get(id);

            if (creditInDb == null)
                return Content(HttpStatusCode.NotFound, $"'{id}' not found");
            this._unitOfWork.Credits.Remove(creditInDb);
            this._unitOfWork.Complete();

            return Content(HttpStatusCode.OK, $"'{id}' Deleted");
        }
    }
}
