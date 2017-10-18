using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Net;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class TransOutController : ApiController
    {
        private UnitOfWork _unitOfWork;
        public TransOutController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        [HttpPost]
        public IHttpActionResult InsertTransOut(TransOut TransOut)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this._unitOfWork.TransOuts.Add(TransOut);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.Created, "Details entered successfully");
        }

        [HttpDelete]
        public IHttpActionResult DeleteTransOut(int PublicId)
        {
            var TransOutInDb = this._unitOfWork.TransOuts.Get(PublicId);

            if (TransOutInDb == null)
                return Content(HttpStatusCode.NotFound, " '{PublicId}' not found");
            //throw new HttpResponseException(HttpStatusCode.NotFound);
            this._unitOfWork.TransOuts.Remove(TransOutInDb);
            this._unitOfWork.Complete();

            return Content(HttpStatusCode.OK, " '{PublicId}' Deleted");
        }
    }
}
