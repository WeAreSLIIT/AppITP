using DataAccess.Core;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class DiscountScheduleController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public DiscountScheduleController()
        {
            this._unitOfWork = new UnitOfWork();

        }

        // GET api/DiscountSchedule
        [HttpGet]
        public IHttpActionResult GetDiscount()
        {
            ICollection<DiscountSchedule> Discounts = new List<DiscountSchedule>();
            Discounts = this._unitOfWork.DiscountSchedules.GetAll().ToList();
            if (Discounts == null || Discounts.Count == 0)
                return Content(HttpStatusCode.NotFound, "No Discount Method(s) to show");

            return Content(HttpStatusCode.Found, Discounts);
        }
        // GET api/DiscountSchedule/1
        [HttpGet]
        public IHttpActionResult GetDiscount(int id)
        {
            var Discount = this._unitOfWork.DiscountSchedules.Get(id);
            if (Discount == null)
            {
                return Content(HttpStatusCode.NotFound, "No matching item(s) found");
            }
            return Content(HttpStatusCode.Found, Discount);
        }

        //POST api/DiscountSchedule/2
        [HttpPost]
        public IHttpActionResult InsertDiscount(DiscountSchedule Discount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this._unitOfWork.DiscountSchedules.Add(Discount);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.Created, "New Discout created");
        }

        //PUT api/DiscountSchedule/4
        [HttpPut]
        public IHttpActionResult UpdateDiscount(int id, DiscountSchedule Discount)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var discountInDb = this._unitOfWork.DiscountSchedules.Get(id);

            if (discountInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{id}' not found");


            discountInDb.DiscountSheduleFrom = Discount.DiscountSheduleFrom;
            discountInDb.DiscountSheduleTo = Discount.DiscountSheduleTo;
            discountInDb.DiscountAmount = Discount.DiscountAmount;

            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, $" '{id}' Updated");
        }



        //DELETE api/DiscountSchedule/4
        [HttpDelete]
        public IHttpActionResult DeleteDiscount(int id)
        {
            var DiscountInDb = this._unitOfWork.DiscountSchedules.Get(id);

            if (DiscountInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{id}' not found");
            //throw new HttpResponseException(HttpStatusCode.NotFound);
            this._unitOfWork.DiscountSchedules.Remove(DiscountInDb);
            this._unitOfWork.Complete();

            return Content(HttpStatusCode.OK, $" '{id}' Deleted");
        }

        //public HttpResponseMessage Get(int id)
        //{
        //	var discount = _unitOfWork.DiscountSchedules.GetDiscountById(id);
        //	if (discount != null)
        //		return Request.CreateResponse(HttpStatusCode.OK, discount);
        //	return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No discount found for this id");
        //}

        //public bool Delete(int id)
        //{
        //	if (id > 0)
        //	{
        //		var discount = this._unitOfWork.DiscountSchedules.GetDiscountById(id);
        //		if (discount != null)
        //		{
        //			this._unitOfWork.DiscountSchedules.DeleteDiscount(discount);
        //			this._unitOfWork.Complete();

        //		}
        //	}

        //}
        //   [System.Web.Http.HttpPost]
        //   [ValidateAntiForgeryToken]
        //   //[ValidateInput(false)]
        //public actionresult edit([bind(include = "id,title,introtext,body,modified,author")] discountschedule post)
        //{

        //	discountschedule edit = this._unitofwork.discountschedules.getdiscountbyid(post);
        //	edit.title = post.title;
        //	edit.introtext = post.introtext;
        //	edit.body = post.body;
        //	edit.modified = datetime.now;

        //	this._unitofwork.complete();


    }
}
