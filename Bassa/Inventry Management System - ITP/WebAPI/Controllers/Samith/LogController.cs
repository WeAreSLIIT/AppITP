using System.Collections.Generic;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace WebAPI.Controllers
{
    //[RoutePrefix("api/log")]
    public class LogController : ApiController
    {
        private UnitOfWork _unitOfWork;

        public LogController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        [Route("api/log")]
        public IHttpActionResult GetLogs()
        {
            ICollection<Log> Logs = new List<Log>();
            Logs = this._unitOfWork.Logs.GetAll().ToList();
            if (Logs == null || Logs.Count == 0)
                return Content(HttpStatusCode.NotFound, "No Logs found!");

            return Content(HttpStatusCode.OK, Logs);
        }



        [HttpGet]
        [Route("api/log/{Id}")]
        public IHttpActionResult GetLog(int Id)
        {

            var log = this._unitOfWork.Logs.Get(Id);
            if (log == null)
            {
                return Content(HttpStatusCode.NotFound, "No Logs found");
            }
            return Content(HttpStatusCode.OK, log);
        }


        [HttpPost]
        [Route("api/log")]
        public IHttpActionResult InsertLog(Log newLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this._unitOfWork.Logs.Add(newLog);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, "New Log Added");
        }

        [HttpPut]
        [Route("api/log/{Id}")]
        public IHttpActionResult UpdateLog(int Id, Log log)
        {
            var logInDb = this._unitOfWork.Logs.Get(Id);

            if (logInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{Id}' not found");

            logInDb.Activity = log.Activity;


            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, $" '{Id}' Updated");
        }


        [HttpDelete]
        [Route("api/log/{Id}")]
        public IHttpActionResult DeleteLog(int Id)
        {
            var LogInDb = this._unitOfWork.Logs.Get(Id);
            if (LogInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{Id}' not found");
            this._unitOfWork.Logs.Remove(LogInDb);
            this._unitOfWork.Complete();


            return Content(HttpStatusCode.OK, $" '{Id}' Deleted");
        }
    }
}