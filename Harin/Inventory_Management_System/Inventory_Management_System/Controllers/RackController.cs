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
        public IEnumerable<Rack> GetAll()
        {
            return this._unitOfWork.Racks.GetAll();
        }

        [HttpPost]
        public IHttpActionResult InsertRack(Rack rack)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.NotAcceptable, "Data is not Valid");
            }
            else if (this._unitOfWork.Racks.Get(rack.RackId) != null)
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
        public IHttpActionResult RemoveRack(Rack rack)
        {
            if (this._unitOfWork.Racks.Get(rack.RackId) == null)
            {
                return Content(HttpStatusCode.NotFound, $"Rack named '{rack.RackName}' is not found");
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
