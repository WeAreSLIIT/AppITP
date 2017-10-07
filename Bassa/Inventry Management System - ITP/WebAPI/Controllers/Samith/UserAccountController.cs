using System.Collections.Generic;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace WebAPI.Controllers
{
    //[RoutePrefix("api/userAccount")]
    public class UserAccountController : ApiController
    {
        private UnitOfWork _unitOfWork;

        public UserAccountController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        [Route("api/userAccount")]
        public IHttpActionResult GetUserAccounts()
        {
            ICollection<UserAccount> UserAccounts = new List<UserAccount>();
            UserAccounts = this._unitOfWork.UserAccounts.GetAll().ToList();
            if (UserAccounts == null || UserAccounts.Count == 0)
                return Content(HttpStatusCode.NotFound, "No UserAccounts found!");

            return Content(HttpStatusCode.OK, UserAccounts);
        }



        [HttpGet]
        [Route("api/userAccount/{Id}")]
        public IHttpActionResult GetUserAccount(int Id)
        {

            var userAccount = this._unitOfWork.UserAccounts.Get(Id);
            if (userAccount == null)
            {
                return Content(HttpStatusCode.NotFound, "No UserAccounts found");
            }
            return Content(HttpStatusCode.OK, userAccount);
        }


        [HttpPost]
        [Route("api/userAccount")]
        public IHttpActionResult InsertUserAccount(UserAccount newUserAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this._unitOfWork.UserAccounts.Add(newUserAccount);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, "New UserAccount Added");
        }

        [HttpPut]
        [Route("api/userAccount/{Id}")]
        public IHttpActionResult UpdateUserAccount(int Id, UserAccount userAccount)
        {
            var userAccountInDb = this._unitOfWork.UserAccounts.Get(Id);

            if (userAccountInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{Id}' not found");

            userAccountInDb.Username = userAccount.Username;
            userAccountInDb.Password = userAccount.Password;
            userAccountInDb.EmployeeID = userAccount.EmployeeID;
            userAccountInDb.UserRoleID = userAccount.UserRoleID;

            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, $" '{Id}' Updated");
        }


        [HttpDelete]
        [Route("api/userAccount/{Id}")]
        public IHttpActionResult DeleteUserAccount(int Id)
        {
            var UserAccountInDb = this._unitOfWork.UserAccounts.Get(Id);
            if (UserAccountInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{Id}' not found");
            this._unitOfWork.UserAccounts.Remove(UserAccountInDb);
            this._unitOfWork.Complete();


            return Content(HttpStatusCode.OK, $" '{Id}' Deleted");
        }
    }
}