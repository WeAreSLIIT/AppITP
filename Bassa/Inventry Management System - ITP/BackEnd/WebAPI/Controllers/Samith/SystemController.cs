using System.Collections.Generic;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace WebAPI.Controllers
{
    //[RoutePrefix("api/system")]
    public class SystemController : ApiController
    {
        private UnitOfWork _unitOfWork;

        public SystemController()
        {
            this._unitOfWork = new UnitOfWork();
        }


        [HttpGet]
        [Route("api/system")]
        public IHttpActionResult GetSystem()
        {
            int Id = 1;
            var systemDetails = this._unitOfWork.SystemDetails.Get(Id);
            if (systemDetails == null)
            {
                return Content(HttpStatusCode.NotFound, "No System Details found");
            }
            return Content(HttpStatusCode.OK, systemDetails);
        }


        [HttpPost]
        [Route("api/system")]
        public IHttpActionResult InsertSystem(SystemDetails newSystem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this._unitOfWork.SystemDetails.Add(newSystem);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, "New SystemDetails Added");
        }

        [HttpPut]
        [Route("api/system")]
        public IHttpActionResult UpdateSystem( SystemDetails systemDetails)
        {
            int Id = 1;
            var systemDetailsInDb = this._unitOfWork.SystemDetails.Get(Id);

            if (systemDetailsInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{Id}' not found");

            systemDetailsInDb.CompanyName = systemDetails.CompanyName;
            systemDetailsInDb.Logo = systemDetails.Logo;
            systemDetailsInDb.Description = systemDetails.Description;
            systemDetailsInDb.BranchID = systemDetails.BranchID;


            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, " System Updated");
        }

    }
}