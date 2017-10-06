using DataAccess.Core;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Net;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class SectionController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public SectionController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Content(HttpStatusCode.OK, this._unitOfWork.Sections.GetAll());
        }

        [HttpPost]
        public IHttpActionResult InsertSection(Section section)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.NotAcceptable, "Data is not Valid");
            }
            else if (this._unitOfWork.Sections.GetName(section.SectionName) != null)
            {
                return Content(HttpStatusCode.BadRequest, "Section is already Exist");
            }
            else
            {
                this._unitOfWork.Sections.Add(section);
                this._unitOfWork.Complete();
                return Content(HttpStatusCode.Created, "New Section is Added");
            }
        }

        [HttpDelete]
        public IHttpActionResult RemoveSection(long Id)
        {
            Section section = this._unitOfWork.Sections.Get(Id);

            if (section == null)
            {
                return Content(HttpStatusCode.NotFound, $"Section named '{Id}' is not found");
            }
            else
            {
                this._unitOfWork.Sections.Remove(section);
                this._unitOfWork.Complete();

                return Content(HttpStatusCode.OK, $"Section named '{section.SectionName}' is Sucessfully Deleted");
            }
        }
    }
}
