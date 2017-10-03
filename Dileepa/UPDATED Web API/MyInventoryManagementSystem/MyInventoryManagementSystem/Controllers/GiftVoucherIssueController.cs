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
    public class GiftVoucherIssueController : ApiController
    {
		private IUnitOfWork _unitOfWork;

		public GiftVoucherIssueController()
		{
			this._unitOfWork = new UnitOfWork();

		}

		// GET api/GiftVoucherIssue
		public IHttpActionResult GetIssuedVouchers()
		{
			ICollection<GiftVoucherIssue> GiftVoucherIssue = new List<GiftVoucherIssue>();
			GiftVoucherIssue = this._unitOfWork.GiftVoucherIssues.GetAll().ToList();
			if (GiftVoucherIssue == null || GiftVoucherIssue.Count == 0)
				return Content(HttpStatusCode.NotFound, "No Issued Gift Voucher(s) to show");

			return Content(HttpStatusCode.Found, GiftVoucherIssue);
		}
		// GET api/GiftVoucherIssue/1
		public IHttpActionResult GetIssuedGiftVoucher(int id)
		{
			var GiftVoucherIssue = this._unitOfWork.GiftVoucherIssues.Get(id);
			if (GiftVoucherIssue == null)
			{
				return Content(HttpStatusCode.NotFound, "No matching gift Voucher(s) found");
			}
			return Content(HttpStatusCode.Found, GiftVoucherIssue);
		}

		//POST api/GiftVoucherIssue/2
		[System.Web.Http.HttpPost]
		public IHttpActionResult IssueGiftVoucher(GiftVoucherIssue GiftVoucherIssue)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			this._unitOfWork.GiftVoucherIssues.Add(GiftVoucherIssue);
			this._unitOfWork.Complete();
			return Content(HttpStatusCode.Created, "New Gift voucher issue");
		}

		//PUT api/GiftVoucherIssue/4
		[System.Web.Http.HttpPut]
		public IHttpActionResult UpdateIssuedGiftVoucher(int id, GiftVoucherIssue GiftVoucherIssue)
		{
			if (!ModelState.IsValid)
				return BadRequest();
			var IssuedVoucerInDb = this._unitOfWork.GiftVoucherIssues.Get(id);

			if (IssuedVoucerInDb == null)
				return Content(HttpStatusCode.NotFound, $" '{id}' not found");



			this._unitOfWork.Complete();
			return Content(HttpStatusCode.OK, $" '{id}' Updated");
		}



		//DELETE api/GiftVoucherIssue/4
		[System.Web.Http.HttpDelete]
		public IHttpActionResult DeleteIssuedGiftVoucher(int id)
		{
			var GiftVoucherIssue = this._unitOfWork.GiftVoucherIssues.Get(id);

			if (GiftVoucherIssue == null)
				return Content(HttpStatusCode.NotFound, $" '{id}' not found");
			//throw new HttpResponseException(HttpStatusCode.NotFound);
			this._unitOfWork.GiftVoucherIssues.Remove(GiftVoucherIssue);
			this._unitOfWork.Complete();

			return Content(HttpStatusCode.OK, $" '{id}' Deleted");
		}
	}
}
