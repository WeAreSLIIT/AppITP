using DataAccess.Core;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Net;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class LoginsController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public LoginsController()
        {
            this._unitOfWork = new UnitOfWork();

        }


        // GET api/customer/1
        [HttpGet]
        public IHttpActionResult GetLogin(int id)
        {
            var login = this._unitOfWork.Logins.Get(id);
            if (login == null)
            {
                return Content(HttpStatusCode.NotFound, "No matching results found");
            }
            return Content(HttpStatusCode.Found, login);

        }

        //POST api/login
        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertLogin(Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this._unitOfWork.Logins.Add(login);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.Created, "New Login Created");


        }
        // PUT api/login/4
        [HttpPut]
        public IHttpActionResult UpdateLoginr(int id, Login login)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var loginInDb = this._unitOfWork.Logins.Get(id);

            if (loginInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{id}' not found");
            loginInDb.HasCustomer = login.HasCustomer;
            loginInDb.SecurityQuestion = login.SecurityQuestion;
            loginInDb.Answer = login.Answer;



            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, $"'{id}' Updated");
        }

        //DELETE api/login/4
        [HttpDelete]
        public IHttpActionResult DeleteLogin(int id)
        {
            var loginInDb = this._unitOfWork.Logins.Get(id);

            if (loginInDb == null)
                return Content(HttpStatusCode.NotFound, $"'{id}' not found");
            this._unitOfWork.Logins.Remove(loginInDb);
            this._unitOfWork.Complete();

            return Content(HttpStatusCode.OK, $"'{id}' Deleted");
        }

    }
}
