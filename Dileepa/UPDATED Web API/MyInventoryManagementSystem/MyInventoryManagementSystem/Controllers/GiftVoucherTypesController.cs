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
	public class GiftVoucherTypesController : ApiController
	{
		private IUnitOfWork _unitOfWork;

		public GiftVoucherTypesController()
		{
			this._unitOfWork = new UnitOfWork();

		}

		// GET api/GiftVoucherType
		public IHttpActionResult GetDiscount()
		{
			try
			{
				ICollection<GiftVoucherType> GiftVoucher = new List<GiftVoucherType>();
				GiftVoucher = this._unitOfWork.GiftVoucherTypes.GetAll().ToList();
				if (GiftVoucher == null || GiftVoucher.Count == 0)
					return Content(HttpStatusCode.NotFound, "No Gift Voucher Method(s) to show");

				return Content(HttpStatusCode.Found, GiftVoucher);
			}
			catch
			{
				return Conflict();
			}
			
		}
		// GET api/GiftVoucherType/1
		[System.Web.Http.HttpGet]
		public IHttpActionResult GetGiftVoucher(int Id)
		{
			var GiftVoucher = this._unitOfWork.GiftVoucherTypes.Get(Id);
			if (GiftVoucher == null)
			{
				return Content(HttpStatusCode.NotFound, "No matching item(s) found");
			}
			return Content(HttpStatusCode.Found, GiftVoucher);
		}

		//POST api/DiscountSchedule/2
		[System.Web.Http.HttpPost]
		public IHttpActionResult InsertGiftVoucher(GiftVoucherType giftVoucher)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			this._unitOfWork.GiftVoucherTypes.Add(giftVoucher);
			this._unitOfWork.Complete();
			return Content(HttpStatusCode.Created, "New Gift voucher created");
		}

		//PUT api/GiftVoucherType/4
		[System.Web.Http.HttpPut]
		public IHttpActionResult UpdateGiftVoucherType(int id, GiftVoucherType giftVoucher)
		{
			if (!ModelState.IsValid)
				return BadRequest();
			var VoucerTypeInDb = this._unitOfWork.GiftVoucherTypes.Get(id);

			if (VoucerTypeInDb == null)
				return Content(HttpStatusCode.NotFound, $" '{id}' not found");
			VoucerTypeInDb.GiftVoucherTypeName = giftVoucher.GiftVoucherTypeName;
			VoucerTypeInDb.GiftVoucherTypeAmount = giftVoucher.GiftVoucherTypeAmount;
			VoucerTypeInDb.GiftVoucherExpiration = giftVoucher.GiftVoucherExpiration;
			VoucerTypeInDb.GiftVoucherTypeDescription = giftVoucher.GiftVoucherTypeDescription;
			VoucerTypeInDb.GiftVoucherTypeNoOfDays = giftVoucher.GiftVoucherTypeNoOfDays;


			this._unitOfWork.Complete();
			return Content(HttpStatusCode.OK, $" '{id}' Updated");
		}



		//DELETE api/GiftVoucherType/4
		[System.Web.Http.HttpDelete]
		public IHttpActionResult DeleteGiftVoucher(int id)
		{
			var GiftVoucher = this._unitOfWork.DiscountTypes.Get(id);

			if (GiftVoucher == null)
				return Content(HttpStatusCode.NotFound, $" '{id}' not found");
			//throw new HttpResponseException(HttpStatusCode.NotFound);
			this._unitOfWork.DiscountTypes.Remove(GiftVoucher);
			this._unitOfWork.Complete();

			return Content(HttpStatusCode.OK, $" '{id}' Deleted");
		}
	}
}
