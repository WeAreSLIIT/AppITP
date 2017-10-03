using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess.Core;
using DataAccess.Core.Domain;
using DataAccess.Persistance;

namespace MyInventoryManagementSystem.Controllers
{
    public class PromotionScheduleController : ApiController
    {
		private IUnitOfWork _unitOfWork;

		public PromotionScheduleController()
		{
			this._unitOfWork = new UnitOfWork();

		}

		// GET api/PromotionSchedule
		public IHttpActionResult GetPromotionSchedule()
		{
			ICollection<PromotionSchedule> Promotions = new List<PromotionSchedule>();
			Promotions = this._unitOfWork.PromotionSchedules.GetAll().ToList();
			if (Promotions == null || Promotions.Count == 0)
				return Content(HttpStatusCode.NotFound, "No Promotion Method(s) to show");

			return Content(HttpStatusCode.Found, Promotions);
		}
		// GET api/PromotionSchedule/1
		public IHttpActionResult GetPromotionSchedule(int id)
		{
			var Promotions = this._unitOfWork.PromotionSchedules.Get(id);
			if (Promotions == null)
			{
				return Content(HttpStatusCode.NotFound, "No matching item(s) found");
			}
			return Content(HttpStatusCode.Found, Promotions);
		}

		//POST api/PromotionSchedule/2
		[System.Web.Http.HttpPost]
		public IHttpActionResult InsertPromotionSchedule(PromotionSchedule promotion)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			this._unitOfWork.PromotionSchedules.Add(promotion);
			this._unitOfWork.Complete();
			return Content(HttpStatusCode.Created, "New PromotionSchedule created");
		}

		//PUT api/PromotionSchedule/4
		[System.Web.Http.HttpPut]
		public IHttpActionResult UpdatePromotionSchedule(int id, PromotionSchedule promotionSchedule)
		{
			if (!ModelState.IsValid)
				return BadRequest();
			var PromotionInDb = this._unitOfWork.PromotionSchedules.Get(id);

			if (PromotionInDb == null)
				return Content(HttpStatusCode.NotFound, $" '{id}' not found");

			PromotionInDb.PromoSheduleName = promotionSchedule.PromoSheduleName;
			PromotionInDb.PromoSheduleDescription = promotionSchedule.PromoSheduleDescription;
			PromotionInDb.PromoSheduleFrom = promotionSchedule.PromoSheduleFrom;
			PromotionInDb.PromoSheduleTo = promotionSchedule.PromoSheduleTo;
			PromotionInDb.PromoSheduleType = promotionSchedule.PromoSheduleType;
			PromotionInDb.SpecialStock = promotionSchedule.SpecialStock;

			this._unitOfWork.Complete();
			return Content(HttpStatusCode.OK, $" '{id}' Updated");
		}



		//DELETE api/PromotionSchedule/4
		[System.Web.Http.HttpDelete]
		public IHttpActionResult DeletePromotionScedule(int id)
		{
			var promotionInDb = this._unitOfWork.PromotionSchedules.Get(id);

			if (promotionInDb == null)
				return Content(HttpStatusCode.NotFound, $" '{id}' not found");
			//throw new HttpResponseException(HttpStatusCode.NotFound);
			this._unitOfWork.PromotionSchedules.Remove(promotionInDb);
			this._unitOfWork.Complete();

			return Content(HttpStatusCode.OK, $" '{id}' Deleted");
		}
	}
}
