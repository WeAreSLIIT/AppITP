using System.Collections.Generic;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace WebAPI.Controllers
{
    //[RoutePrefix("api/privilege")]
    public class PrivilegeController : ApiController
    {
        private UnitOfWork _unitOfWork;

        public PrivilegeController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        [Route("api/privilege")]
        public IHttpActionResult GetPrivileges()
        {
            ICollection<Privilege> Privileges = new List<Privilege>();
            Privileges = this._unitOfWork.Privileges.GetAll().ToList();
            if (Privileges == null || Privileges.Count == 0)
                return Content(HttpStatusCode.NotFound, "No Privileges found!");

            return Content(HttpStatusCode.OK, Privileges);
        }



        [HttpGet]
        [Route("api/privilege/{Id}")]
        public IHttpActionResult GetPrivilege(int Id)
        {

            var privilege = this._unitOfWork.Privileges.Get(Id);
            if (privilege == null)
            {
                return Content(HttpStatusCode.NotFound, "No Privileges found");
            }
            return Content(HttpStatusCode.OK, privilege);
        }


        [HttpPost]
        [Route("api/privilege")]
        public IHttpActionResult InsertPrivilege(Privilege newPrivilege)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this._unitOfWork.Privileges.Add(newPrivilege);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, "New Privilege Added");
        }

        [HttpPut]
        [Route("api/privilege/{Id}")]
        public IHttpActionResult UpdatePrivilege(int Id, Privilege privilege)
        {
            var privilegeInDb = this._unitOfWork.Privileges.Get(Id);

            if (privilegeInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{Id}' not found");

            privilegeInDb.ModuleID = privilege.ModuleID;


            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, $" '{Id}' Updated");
        }


        [HttpDelete]
        [Route("api/privilege/{Id}")]
        public IHttpActionResult DeletePrivilege(int Id)
        {
            var PrivilegeInDb = this._unitOfWork.Privileges.Get(Id);
            if (PrivilegeInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{Id}' not found");
            this._unitOfWork.Privileges.Remove(PrivilegeInDb);
            this._unitOfWork.Complete();


            return Content(HttpStatusCode.OK, $" '{Id}' Deleted");
        }
    }
}