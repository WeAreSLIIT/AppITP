using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Net;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class RecountController : ApiController
    {
        private UnitOfWork _unitOfWork;

        public RecountController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        [HttpPut]
        public IHttpActionResult UpdateStatus(int Id, Recount RecountStock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var RecountStockInDb = this._unitOfWork.Recounts.Get(Id);

            if (RecountStockInDb == null)
                return Content(HttpStatusCode.NotFound, " '{Id}' not found");

            RecountStockInDb.Status = RecountStock.Status;

            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, " '{Id}' Updated");

        }
    }
}
