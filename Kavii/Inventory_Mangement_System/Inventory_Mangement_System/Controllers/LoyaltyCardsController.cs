using Inventory_Mangement_System.IRepositories;
using Inventory_Mangement_System.Models;
using Inventory_Mangement_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Inventory_Mangement_System.Controllers
{
    public class LoyaltyCardsController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public LoyaltyCardsController()
        {
            this._unitOfWork = new UnitOfWork();

        }

        // Get api/loyaltycard
        public IHttpActionResult GetLoyaltyCard()
        {
            ICollection<LoyaltyCard> loyaltycard = new List<LoyaltyCard>();
            loyaltycard = this._unitOfWork.LoyaltyProgram.GetAll().ToList();

            if (loyaltycard == null || loyaltycard.Count == 0)
                return Content(HttpStatusCode.NotFound, "No LoyaltyCard(s) to show");

            return Content(HttpStatusCode.Found, loyaltycard);
        }
        // GET api/loyaltycard/1
        [HttpGet]
        public IHttpActionResult GetLoyaltyCard(int id)
        {
            var loyaltycard = this._unitOfWork.LoyaltyProgram.Get(id);
            if (loyaltycard == null)
            {
                return Content(HttpStatusCode.NotFound, "No matching results found");
            }
            return Content(HttpStatusCode.Found, loyaltycard);

        }

        //POST api/loyaltycard
        [HttpPost]
        public IHttpActionResult InsertLoyaltyCard(LoyaltyCard loyaltycard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this._unitOfWork.LoyaltyProgram.Add(loyaltycard);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.Created, "New LoyaltyCard Added");


        }
        // PUT api/loyaltycard/4
        [HttpPut]
        public IHttpActionResult UpdateLoyaltyCard(int id, LoyaltyCard loyaltycard)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var loyaltycardInDb = this._unitOfWork.LoyaltyProgram.Get(id);

            if (loyaltycardInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{id}' not found");
            loyaltycardInDb.Balance= loyaltycard.Balance;
            loyaltycardInDb.BelongsToLoyaltyProgram = loyaltycardInDb.BelongsToLoyaltyProgram;
            loyaltycardInDb.LoyaltyPoints = loyaltycardInDb.LoyaltyPoints;
            loyaltycardInDb.OwnedCustomer = loyaltycardInDb.OwnedCustomer;
            loyaltycardInDb.RedeemedPoints = loyaltycardInDb.RedeemedPoints;
            loyaltycardInDb.UnitCurrencyAmount = loyaltycardInDb.UnitCurrencyAmount;



            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, $"'{id}' Updated");
        }

        //DELETE api/loyaltycard/4
        [HttpDelete]
        public IHttpActionResult DeleteLoyaltyCard(int id)
        {
            var loyaltycardInDb = this._unitOfWork.LoyaltyProgram.Get(id);

            if (loyaltycardInDb == null)
                return Content(HttpStatusCode.NotFound, $"'{id}' not found");
            this._unitOfWork.LoyaltyProgram.Remove(loyaltycardInDb);
            this._unitOfWork.Complete();

            return Content(HttpStatusCode.OK, $"'{id}' Deleted");
        }


    }
}
