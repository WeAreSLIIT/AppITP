using DataAccess.Core;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Net;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class DiscountTypeController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public DiscountTypeController()
        {
            this._unitOfWork = new UnitOfWork();

        }

        //// GET api/DiscountType
        //public IHttpActionResult GetDiscount()
        //{
        //	ICollection<DiscountSchedule> Discounts = new List<DiscountSchedule>();
        //	Discounts = this._unitOfWork.DiscountSchedules.GetAll().ToList();
        //	if (Discounts == null || Discounts.Count == 0)
        //		return Content(HttpStatusCode.NoContent, "No Discount Method(s) to show");

        //	return Content(HttpStatusCode.Found, Discounts);
        //}
        //// GET api/DiscountSchedule/1
        //public IHttpActionResult GetDiscount(int id)
        //{
        //	var discount = this._unitOfWork.DiscountSchedules.Get(id);
        //	if (discount == null)
        //	{
        //		return Content(HttpStatusCode.NotFound, "No matching item(s) found");
        //	}
        //	return Content(HttpStatusCode.Found, discount);
        //}

        //POST api/DiscountType
        [HttpPost]
        public IHttpActionResult InsertDiscountType(DiscountType discountType)
        {

            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.NotAcceptable, "Data is not Valid");
            }
            this._unitOfWork.DiscountTypes.Add(discountType);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.Created, "New DiscoutType created");
        }

        //PUT api/DiscountSchedule/4

        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateDiscountType(int id, DiscountType discount)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var discountTypeInDb = this._unitOfWork.DiscountTypes.Get(id);

            if (discountTypeInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{id}' not found");


            discountTypeInDb.DiscountTypeName = discount.DiscountTypeName;
            discountTypeInDb.DiscountTypeTax = discount.DiscountTypeTax;
            discountTypeInDb.DiscountTimeSpan = discount.DiscountTimeSpan;

            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, $" '{id}' Updated");
        }



        //DELETE api/DiscountSchedule/4
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteDiscountType(int id)
        {
            var discountTypeInDb = this._unitOfWork.DiscountTypes.Get(id);

            if (discountTypeInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{id}' not found");
            //throw new HttpResponseException(HttpStatusCode.NotFound);
            this._unitOfWork.DiscountTypes.Remove(discountTypeInDb);
            this._unitOfWork.Complete();

            return Content(HttpStatusCode.OK, $" '{id}' Deleted");
        }

    }
}
