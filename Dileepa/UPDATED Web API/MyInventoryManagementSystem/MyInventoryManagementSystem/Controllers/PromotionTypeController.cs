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
    public class PromotionTypeController : ApiController
    {
		private IUnitOfWork _unitOfWork;

		public PromotionTypeController()
		{
			this._unitOfWork = new UnitOfWork();

		}

		//// GET api/PromotionType
		//public IHttpActionResult GetPromotionSchedule()
		//{
		//	ICollection<PromotionSchedule> Promotions = new List<PromotionSchedule>();
		//	Promotions = this._unitOfWork.PromotionSchedules.GetAll().ToList();
		//	if (Promotions == null || Promotions.Count == 0)
		//		return Content(HttpStatusCode.NoContent, "No Promotion Method(s) to show");

		//	return Content(HttpStatusCode.Found, Promotions);
		//}
		//// GET api/PromotionSchedule/1
		//public IHttpActionResult GetPromotionSchedule(int id)
		//{
		//	var Promotions = this._unitOfWork.PromotionSchedules.Get(id);
		//	if (Promotions == null)
		//	{
		//		return Content(HttpStatusCode.NotFound, "No matching item(s) found");
		//	}
		//	return Content(HttpStatusCode.Found, Promotions);
		//}

		//POST api/PromotionSchedule/2
		[System.Web.Http.HttpPost]
		public IHttpActionResult InsertPromotionType(PromotionType promotion)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			this._unitOfWork.PromotionTypes.Add(promotion);
			this._unitOfWork.Complete();
			return Content(HttpStatusCode.Created, "New PromotionType created");
		}

		//PUT api/PromotionSchedule/4
		[System.Web.Http.HttpPut]
		public IHttpActionResult UpdatePromotionType(int id, PromotionType promotiontype)
		{
			if (!ModelState.IsValid)
				return BadRequest();
			var PromotionInDb = this._unitOfWork.PromotionTypes.Get(id);

			if (PromotionInDb == null)
				return Content(HttpStatusCode.NotFound, $" '{id}' not found");
			PromotionInDb.PromoTypeName = promotiontype.PromoTypeName;
			PromotionInDb.PromoTimeSpan = promotiontype.PromoTimeSpan;
	

			this._unitOfWork.Complete();
			return Content(HttpStatusCode.OK, $" '{id}' Updated");
		}



		//DELETE api/PromotionSchedule/4
		[System.Web.Http.HttpDelete]
		public IHttpActionResult DeletePromotionType(int id)
		{
			var promotionInDb = this._unitOfWork.DiscountTypes.Get(id);

			if (promotionInDb == null)
				return Content(HttpStatusCode.NotFound, $" '{id}' not found");
			//throw new HttpResponseException(HttpStatusCode.NotFound);
			this._unitOfWork.DiscountTypes.Remove(promotionInDb);
			this._unitOfWork.Complete();

			return Content(HttpStatusCode.OK, $" '{id}' Deleted");
		}
	}
}
    
