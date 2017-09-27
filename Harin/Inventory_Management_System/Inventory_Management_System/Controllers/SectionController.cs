using Inventory_Management_System.Models;
using Inventory_Management_System.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Inventory_Management_System.Controllers
{
    public class SectionController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public SectionController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        public IEnumerable<Section> GetAll()
        {
            return this._unitOfWork.Sections.GetAll();
        }

        [HttpPost]
        public IHttpActionResult InsertSection(Section section)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.NotAcceptable, "Data is not Valid");
            }
            else if (this._unitOfWork.Sections.Get(section.SectionId) != null)
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
        public IHttpActionResult RemoveSection(Section section)
        {
            if (this._unitOfWork.Sections.Get(section.SectionId) == null)
            {
                return Content(HttpStatusCode.NotFound, $"Section named '{section.SectionName}' is not found");
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
