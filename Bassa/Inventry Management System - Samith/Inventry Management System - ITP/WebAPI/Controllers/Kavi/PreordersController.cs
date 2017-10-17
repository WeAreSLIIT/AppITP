using DataAccess.Core;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class PreordersController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public PreordersController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        // Get api/preorder
        public IHttpActionResult GetPreorder()
        {
            ICollection<Preorder> preorder = new List<Preorder>();
            preorder = this._unitOfWork.Preorders.GetAll().ToList();

            if (preorder == null || preorder.Count == 0)
                return Content(HttpStatusCode.NotFound, "No Preorder(s) to show");

            return Content(HttpStatusCode.Found, preorder);
        }


        // GET api/preorder/1
        [HttpGet]
        public IHttpActionResult GetPreorder(int id)
        {
            var preorder = this._unitOfWork.Preorders.Get(id);
            if (preorder == null)
            {
                return Content(HttpStatusCode.NotFound, "No matching results found");
            }
            return Content(HttpStatusCode.Found, preorder);

        }

        //POST api/preorder
        [HttpPost]
        public IHttpActionResult InsertPreorder(Preorder preorder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this._unitOfWork.Preorders.Add(preorder);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.Created, "New Preorder Added");


        }
        // PUT api/preorder/4



        //DELETE api/customer/4
        [HttpDelete]
        public IHttpActionResult DeletePreorder(int id)
        {
            var preorderInDb = this._unitOfWork.Preorders.Get(id);

            if (preorderInDb == null)
                return Content(HttpStatusCode.NotFound, $"'{id}' not found");
            this._unitOfWork.Preorders.Remove(preorderInDb);
            this._unitOfWork.Complete();

            return Content(HttpStatusCode.OK, $"'{id}' Deleted");
        }


    }
}
