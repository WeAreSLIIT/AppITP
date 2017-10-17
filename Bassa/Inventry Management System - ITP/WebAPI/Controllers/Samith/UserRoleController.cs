using System.Collections.Generic;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace WebAPI.Controllers
{
    //[RoutePrefix("api/userRoles")]
    public class UserRoleController : ApiController
    {
        private UnitOfWork _unitOfWork;

        public UserRoleController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        [Route("api/userRoles")]
        public IHttpActionResult GetUserRoles()
        {
            ICollection<UserRole> UserRoles = new List<UserRole>();
            UserRoles = this._unitOfWork.UserRoles.GetAll().ToList();
            if (UserRoles == null || UserRoles.Count == 0)
                return Content(HttpStatusCode.NotFound, "No UserRoles found!");

            return Content(HttpStatusCode.OK, UserRoles);
        }



        [HttpGet]
        [Route("api/userRoles/{Id}")]
        public IHttpActionResult GetUserRole(int Id)
        {

            var userRoles = this._unitOfWork.UserRoles.Get(Id);
            if (userRoles == null)
            {
                return Content(HttpStatusCode.NotFound, "No UserRoles found");
            }
            return Content(HttpStatusCode.OK, userRoles);
        }


        [HttpPost]
        [Route("api/userRoles")]
        public IHttpActionResult InsertUserRole(UserRole newUserRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this._unitOfWork.UserRoles.Add(newUserRole);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, "New UserRole Added");
        }

        [HttpPut]
        [Route("api/userRoles/{Id}")]
        public IHttpActionResult UpdateUserRole(int Id, UserRole userRoles)
        {
            var userRolesInDb = this._unitOfWork.UserRoles.Get(Id);

            if (userRolesInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{Id}' not found");

            userRolesInDb.Name = userRoles.Name;
            userRolesInDb.AuthorizationLevel = userRoles.AuthorizationLevel;
            userRolesInDb.Description = userRoles.Description;
            userRolesInDb.Suspend = userRoles.Suspend;


            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, $" '{Id}' Updated");
        }


        [HttpDelete]
        [Route("api/userRoles/{Id}")]
        public IHttpActionResult DeleteUserRole(int Id)
        {
            var UserRoleInDb = this._unitOfWork.UserRoles.Get(Id);
            if (UserRoleInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{Id}' not found");
            this._unitOfWork.UserRoles.Remove(UserRoleInDb);
            this._unitOfWork.Complete();


            return Content(HttpStatusCode.OK, $" '{Id}' Deleted");
        }
    }
}