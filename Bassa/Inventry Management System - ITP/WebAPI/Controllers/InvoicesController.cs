using DataAccess.Core;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
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

        public IHttpActionResult Get()
        {
            ICollection<Invoice> Invoices = this._unitOfWork.Invoices.GetAllInvoicesWithData().ToList();
            this._unitOfWork.Dispose();

            if (Invoices == null || Invoices.Count == 0)
                return Content(HttpStatusCode.NoContent, "No Invoices to show");

            

            return Ok(Invoices);
        }

        public IHttpActionResult Get([FromUri]string Id)
        {
            Invoice Invoice = this._unitOfWork.Invoices.GetInvoiceWithData(Id);

            if (Invoice != null)
                return Content(HttpStatusCode.NotFound, $"No Invoice found with ID of '{Id}'");

            return Content(HttpStatusCode.Found, Invoice);
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddNewInvoice([FromBody]CreateInvoiceResource CreateInvoiceResource)
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
    }
}
