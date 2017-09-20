using DataAccess.Core;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Controllers.Methods;
using WebAPI.Controllers.Resources;

namespace WebAPI.Controllers
{
    public class InvoicesController : ApiController
    {
        private IUnitOfWork _unitOfWork;
        private InvoiceControllerMethods _invoiceControllerMethods;

        public InvoicesController()
        {
            this._unitOfWork = new UnitOfWork();
            this._invoiceControllerMethods = new InvoiceControllerMethods(this._unitOfWork);
        }

        public IHttpActionResult Get()
        {
            IEnumerable<Invoice> Invoices = this._unitOfWork.Invoices.GetAll();

            if (Invoices != null)
                return Content(HttpStatusCode.NoContent, "No Invoices to show");

            //InvoiceResource InvoiceResource = this._invoiceControllerMethods.
            //IEnumerable<CreateInvoiceResource> InvoiceResources = AutoMapper.Mapper.Map<IEnumerable<Invoice>, IEnumerable<CreateInvoiceResource>>(Invoices);

            return Ok(Invoices);
        }

        public IHttpActionResult Get([FromUri]string Id)
        {
            Invoice Invoice = this._unitOfWork.Invoices.Get(Id);

            if (Invoice != null)
                return Content(HttpStatusCode.NotFound, $"No Invoice found with the ID of '{Id}'");

            //CreateInvoiceResource InvoiceResource = AutoMapper.Mapper.Map<Invoice, CreateInvoiceResource>(Invoice);

            return Content(HttpStatusCode.Found, Invoice);
        }

        public IHttpActionResult Post([FromBody]CreateInvoiceResource CreateInvoiceResource)
        {
            //Invoice NewInvoice = AutoMapper.Mapper.Map<CreateInvoiceResource, Invoice>(InvoiceResource);

            //Invoice NewInvoice = MappingsForInvoices(CreateInvoiceResource);

            return Ok();
        }

        public IHttpActionResult Put([FromUri]string Id, [FromBody]CreateInvoiceResource CreateInvoiceResource, [FromUri]string AuthenicationKey = "")
        {
            if (AuthenicationKey.Equals("Test"))
            {
                Invoice OldInvoice = this._unitOfWork.Invoices.Get(Id);

                if (OldInvoice != null)
                    return Content(HttpStatusCode.NotFound, $"No Invoice found with the ID of '{Id}'");

                Invoice Invoice = this._invoiceControllerMethods.MapCreateInvoiceResourceToInvoice(CreateInvoiceResource);
                List<InvoiceProduct> InvoiceProduct = 

                //Invoice UpdatedInvoice = AutoMapper.Mapper.Map<CreateInvoiceResource, Invoice>(InvoiceResource);

                return Ok();
            }
            else
                return Content(HttpStatusCode.NonAuthoritativeInformation, "No authentication to do this task.");


        }

    }
}
