using DataAccess.Core;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System;
using System.Net;
using System.Web.Http;
using WebAPI.Controllers.Methods;
using WebAPI.Controllers.Resources;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class CountersController : ApiController
    {
        private IUnitOfWork _unitOfWork;
        private const string AppAuthID = "csbwpfapp";

        public CountersController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        public IHttpActionResult GetAllCounters()
        {
            try
            {
                return Content(HttpStatusCode.OK, this._unitOfWork.Counters.GetAll());
            }
            catch
            {
                return Conflict();
            }
        }

        [HttpGet]
        public IHttpActionResult GetSpecificCounter([FromUri]int Id)
        {
            try
            {
                Counter Counter = this._unitOfWork.Counters.Get(Id);

                if (Counter == null)
                    return NotFound();

                return Content(HttpStatusCode.Found, Counter);
            }
            catch
            {
                return Conflict();
            }
        }

        [HttpGet]
        [Route("api/counters/{CounterNo}/branch/{BranchID}")]
        public IHttpActionResult CheckCouterIsAvailable([FromUri]long CounterNo, [FromUri]long BranchID, [FromUri]string App = "")
        {
            try
            {
                if (!String.IsNullOrEmpty(App.Trim()) && (App.Trim().ToLower()).Equals(AppAuthID))
                {
                    bool? IsOnline = BackgroundProcess.CheckCounterIsOnline(BranchID, CounterNo);

                    if (IsOnline == null)
                        return Content(HttpStatusCode.NotFound, "Invalid Counter request");
                    else if (IsOnline == true)
                        return Content(HttpStatusCode.Unauthorized, "Counter is already online");

                    return Content(HttpStatusCode.OK, "Counter is offline");
                }
                else
                    return BadRequest();
            }
            catch
            {
                return Conflict();
            }
        }

        [HttpPut]
        [Route("api/counters")]
        public IHttpActionResult SetCouterIsOnline([FromBody]CounterResource CounterResource, [FromUri]string App = "")
        {
            try
            {
                if (!String.IsNullOrEmpty(App.Trim()) && (App.Trim().ToLower()).Equals(AppAuthID))
                {
                    if (CounterResource == null)
                        return BadRequest();

                    long CounterNo = CounterResource.CouterNo;
                    long BranchID = CounterResource.BranchID;

                    bool SettingCounterOnline = BackgroundProcess.SetCounterOnline(BranchID, CounterNo);

                    if (SettingCounterOnline)
                    {
                        ServerOnlineResource ServerOnlineResource = new ServerOnlineResource()
                        {
                            ServerUp = true,
                            Time = TimeConverterMethods.GetCurrentTimeInLong()
                        };

                        return Content(HttpStatusCode.OK, ServerOnlineResource);
                    }

                    return NotFound();
                }
                else
                    return BadRequest();
            }
            catch
            {
                return Conflict();
            }
        }

        [HttpPost]
        [Route("api/counters/{BranchID}")]
        public IHttpActionResult AddNewCounter([FromUri]long BranchID)
        {
            try
            {
                if (BranchID > 0)
                {
                    long? CurrentCounterCount = this._unitOfWork.Counters.GetCounterCountInBranch(BranchID);

                    if (CurrentCounterCount == null)
                        return BadRequest();

                    long NextCounterID = (long)CurrentCounterCount + 1;

                    Counter NewCounter = new Counter()
                    {
                        BranchID = BranchID,
                        BranchCounterNo = (long)CurrentCounterCount
                    };

                    this._unitOfWork.Counters.Add(NewCounter);
                    this._unitOfWork.Complete();

                    BackgroundProcess.RefreshCounterOnlineStatus();
                    return Content(HttpStatusCode.Created, "Counter added to the branch");
                }
                else
                    return BadRequest();
            }
            catch
            {
                return Conflict();
            }
        }
    }
}
