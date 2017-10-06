using DataAccess.Core;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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

        [HttpGet]
        public async Task<IHttpActionResult> GetAllInvoices()
        {
            try
            {
                ICollection<InvoiceResource> InvoiceResources = new List<InvoiceResource>();

                InvoiceResources = await Task.Run(
                    () =>
                    {
                        ICollection<Invoice> Invoices = this._unitOfWork.Invoices.GetAllInvoicesWithAllData().ToList();

                        return this._invoiceControllerMethods.MapListInvoiceToListInvoiceResource(Invoices);
                    });

                if (InvoiceResources == null || InvoiceResources.Count == 0)
                    return Content(HttpStatusCode.NotFound, "No Invoices to send");

                return Content(HttpStatusCode.Found, InvoiceResources);
            }
            catch
            {
                return Content(HttpStatusCode.Conflict, "Something went wrong");
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetInvoiceByPublicID([FromUri]string Id)
        {
            try
            {
                InvoiceResource InvoiceResource = new InvoiceResource();

                InvoiceResource = await Task.Run(
                    ()=>
                    {
                        Invoice Invoice = this._unitOfWork.Invoices.GetInvoiceWithData(Id);

                        if (Invoice == null)
                            return null;

                        return this._invoiceControllerMethods.MapInvoiceToInvoiceResource(Invoice);
                    });

                if (InvoiceResource == null)
                    return Content(HttpStatusCode.NotFound, $"No Invoice found with ID of '{Id}'");

                return Content(HttpStatusCode.Found, InvoiceResource);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.Conflict, "Something went wrong " + ex);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddNewInvoice([FromBody]CreateInvoiceResource CreateInvoiceResource)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Invoice NewInvoice = await Task.Run(() => this._invoiceControllerMethods.MapCreateInvoiceResourceToInvoice(CreateInvoiceResource));

                    if (NewInvoice == null)
                        return Content(HttpStatusCode.NotAcceptable, "Invoice data not acceptable");

                    this._unitOfWork.Invoices.Add(NewInvoice);
                    this._unitOfWork.Complete();

                    return Content(HttpStatusCode.Created, "Invoice added");
                }
                else
                    return BadRequest();
            }
            catch
            {
                return Content(HttpStatusCode.Conflict, "Something went wrong");
            }
        }
    }
}
