using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using DataAccess.Core.Domain;
using DataAccess.Persistance;

namespace MyInventoryManagementSystem.Controllers
{
    public class TestsController : ApiController
    {

	    public IHttpActionResult Get()
	    {
		    try
		    {
			    ICollection<GiftVoucherType> GiftVoucher = new List<GiftVoucherType>();
			    GiftVoucher = new UnitOfWork().GiftVoucherTypes.GetAll().ToList();

			    if (GiftVoucher == null || GiftVoucher.Count == 0)
				    return Content(HttpStatusCode.NotFound, "No Voucher Type(s) Found ");

			    return Content(HttpStatusCode.Found, GiftVoucher);
		    }
		    catch
		    {
			    return Conflict();
		    }
	    }
    }
}
