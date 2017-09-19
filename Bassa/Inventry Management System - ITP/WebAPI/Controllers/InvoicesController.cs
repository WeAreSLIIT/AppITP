using DataAccess.Core;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Controllers.Resources;

namespace WebAPI.Controllers
{
    public class InvoicesController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public InvoicesController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        public IHttpActionResult Get()
        {
            IEnumerable<Invoice> Invoices = this._unitOfWork.Invoices.GetAll();

            if (Invoices != null)
                return Content(HttpStatusCode.NoContent, "No Invoices at the moment");


            IEnumerable<InvoiceResource> InvoiceResources = AutoMapper.Mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceResource>>(Invoices);
            return Ok(InvoiceResources);
        }

        public IHttpActionResult Post([FromBody]InvoiceResource InvoiceResource)
        {
            //var temp = AutoMapper.Mapper.Map<InvoiceResource, Invoice>(InvoiceResource);

            return Ok(InvoiceResource);
        }
    }
}
