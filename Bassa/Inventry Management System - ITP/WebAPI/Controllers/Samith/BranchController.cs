using System.Collections.Generic;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace WebAPI.Controllers
{
    //[RoutePrefix("api/branch")]
    public class BranchController : ApiController
    {
        private UnitOfWork _unitOfWork;

        public BranchController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        [Route("api/branch")]
        public IHttpActionResult GetBranches()
        {
            ICollection<Branch> Branches = new List<Branch>();
            Branches = this._unitOfWork.Branches.GetAll().ToList();
            if (Branches == null || Branches.Count == 0)
                return Content(HttpStatusCode.NotFound, "No Branches found!");

            return Content(HttpStatusCode.OK, Branches);
        }



        [HttpGet]
        [Route("api/branch/{Id}")]
        public IHttpActionResult GetBranch(int Id)
        {

            var branch = this._unitOfWork.Branches.Get(Id);
            if (branch == null)
            {
                return Content(HttpStatusCode.NotFound, "No Branches found");
            }
            return Content(HttpStatusCode.OK, branch);
        }


        [HttpPost]
        [Route("api/branch")]
        public IHttpActionResult InsertBranch(Branch newBranch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this._unitOfWork.Branches.Add(newBranch);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, "New Branch Added");
        }

        [HttpPut]
        [Route("api/branch/{Id}")]
        public IHttpActionResult UpdateBranch(int Id, Branch branch)
        {
            var branchInDb = this._unitOfWork.Branches.Get(Id);

            if (branchInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{Id}' not found");

            branchInDb.Name = branch.Name;
            branchInDb.Location = branch.Location;
            branchInDb.BranchTitle = branch.BranchTitle;
            branchInDb.Longtitude = branch.Longtitude;
            branchInDb.Latitude = branch.Latitude;
            branchInDb.BranchLevel = branch.BranchLevel;
            branchInDb.Address = branch.Address;
            branchInDb.Email = branch.Email;


            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, $" '{Id}' Updated");
        }


        [HttpDelete]
        [Route("api/branch/{Id}")]
        public IHttpActionResult DeleteBranch(int Id)
        {
            var BranchInDb = this._unitOfWork.Branches.Get(Id);
            if (BranchInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{Id}' not found");
            this._unitOfWork.Branches.Remove(BranchInDb);
            this._unitOfWork.Complete();


            return Content(HttpStatusCode.OK, $" '{Id}' Deleted");
        }
    }
}