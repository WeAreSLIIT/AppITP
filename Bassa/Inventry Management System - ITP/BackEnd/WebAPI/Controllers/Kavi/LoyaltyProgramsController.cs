using DataAccess.Core;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class LoyaltyProgramsController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public LoyaltyProgramsController()
        {
            this._unitOfWork = new UnitOfWork();
        }


        public IHttpActionResult GetLoyaltyProgram()
        {
            ICollection<LoyaltyProgram> loyaltyprogram = new List<LoyaltyProgram>();
            loyaltyprogram = this._unitOfWork.LoyaltyPrograms.GetAll().ToList();

            if (loyaltyprogram == null || loyaltyprogram.Count == 0)
                return Content(HttpStatusCode.NotFound, "No LoyaltyProgram(s) to show");

            return Content(HttpStatusCode.Found, loyaltyprogram);
        }
        // GET api/loyaltyprogram/1
        [HttpGet]
        public IHttpActionResult GetLoyaltyProgram(int id)
        {
            var loyaltyprogram = this._unitOfWork.LoyaltyProgram.Get(id);
            if (loyaltyprogram == null)
            {
                return Content(HttpStatusCode.NotFound, "No matching results found");
            }
            return Content(HttpStatusCode.Found, loyaltyprogram);

        }


        // POST api/loyaltyprogram
        [HttpPost]
        public IHttpActionResult InsertLoyaltyProgram(LoyaltyProgram loyaltyprogram)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, "Data is not Acceptable");
            }
            else if (this._unitOfWork.LoyaltyPrograms.Get(loyaltyprogram.LoyaltyProgramID) != null)
            {
                return Content(HttpStatusCode.BadRequest, "LoyaltyProgram is already Exist");
            }
            else
            {
                this._unitOfWork.LoyaltyPrograms.Add(loyaltyprogram);
                this._unitOfWork.Complete();
                return Content(HttpStatusCode.Created, "New Loyalty Program is Added");
            }
        }

        // PUT api/loyaltyprogram/4
        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateLoyaltyProgram(int id, LoyaltyProgram loyaltyprogram)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var loyaltyprogramInDb = this._unitOfWork.LoyaltyPrograms.Get(id);

            if (loyaltyprogramInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{id}' not found");
            loyaltyprogramInDb.Name = loyaltyprogram.Name;
            loyaltyprogramInDb.OffersLoyaltyCard = loyaltyprogram.OffersLoyaltyCard;
            loyaltyprogramInDb.ProductInclusion = loyaltyprogram.ProductInclusion;
            loyaltyprogramInDb.Description = loyaltyprogram.Description;
            loyaltyprogramInDb.CreatedDate = loyaltyprogram.CreatedDate;


            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, $"'{id}' Updated");
        }

        [HttpDelete]
        public IHttpActionResult RemoveLoyaltyProgram(LoyaltyProgram loyaltyprogram)
        {

            if (this._unitOfWork.LoyaltyPrograms.Get(loyaltyprogram.LoyaltyProgramID) == null)
            {
                return Content(HttpStatusCode.NotFound, $"Loyalty Program '{loyaltyprogram.LoyaltyProgramID}' not found");
            }
            else
            {
                this._unitOfWork.LoyaltyPrograms.Remove(loyaltyprogram);
                this._unitOfWork.Complete();

                return Content(HttpStatusCode.OK, $"Loyalty Program name '{loyaltyprogram.LoyaltyProgramID}' is Deleted ");

            }

        }

    }
}
