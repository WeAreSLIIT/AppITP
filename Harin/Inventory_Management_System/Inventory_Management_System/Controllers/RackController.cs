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
    public class RackController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public RackController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Content(HttpStatusCode.OK, this._unitOfWork.Racks.GetAll());
        }

        [HttpGet]
        public IHttpActionResult GetRack(long Id)
        {
            ICollection<Rack> rack = new List<Rack>();
            rack = this._unitOfWork.Racks.Search(x => x.SectionId == Id).ToList();

            if (rack == null || rack.Count == 0)
            {
                return Content(HttpStatusCode.NotFound, "No Racks");
            }

            return Content(HttpStatusCode.OK, rack);
        }

        [HttpPost]
        public IHttpActionResult InsertRack(Rack rack)
        {
            ICollection<Rack> racks = new List<Rack>();
            racks = this._unitOfWork.Racks
                .Search(x => x.RackName == rack.RackName && x.SectionId == rack.SectionId).ToList();

            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.NotAcceptable, "Data is not Valid");
            }
            else if (this._unitOfWork.Sections.Get(rack.SectionId) ==null)
            {
                return Content(HttpStatusCode.BadRequest, "Section is not Exist");
            }
            else if (racks.Count != 0)
            {
                return Content(HttpStatusCode.BadRequest, "Rack is already Exist");
            }
            else
            {
                this._unitOfWork.Racks.Add(rack);
                this._unitOfWork.Complete();
                return Content(HttpStatusCode.Created, "New Rack is Added");
            }
        }

        [HttpDelete]
        public IHttpActionResult RemoveRack(long Id)
        {
            Rack rack = this._unitOfWork.Racks.Get(Id);

            if (rack == null)
            {
                return Content(HttpStatusCode.NotFound, $"Rack named '{Id}' is not found");
            }
            else
            {
                this._unitOfWork.Racks.Remove(rack);
                this._unitOfWork.Complete();

                return Content(HttpStatusCode.OK, $"Rack named '{rack.RackName}' is Sucessfully Deleted");
            }
        }
    }
}
