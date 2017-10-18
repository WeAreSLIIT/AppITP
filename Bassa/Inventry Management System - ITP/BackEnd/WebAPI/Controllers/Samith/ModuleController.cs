using System.Collections.Generic;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace WebAPI.Controllers
{
    //[RoutePrefix("api/module")]
    public class ModuleController : ApiController
    {
        private UnitOfWork _unitOfWork;

        public ModuleController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        [Route("api/module")]
        public IHttpActionResult GetModules()
        {
            ICollection<Module> Modules = new List<Module>();
            Modules = this._unitOfWork.Modules.GetAll().ToList();
            if (Modules == null || Modules.Count == 0)
                return Content(HttpStatusCode.NotFound, "No Modules found!");

            return Content(HttpStatusCode.OK, Modules);
        }



        [HttpGet]
        [Route("api/module/{Id}")]
        public IHttpActionResult GetModule(int Id)
        {

            var module = this._unitOfWork.Modules.Get(Id);
            if (module == null)
            {
                return Content(HttpStatusCode.NotFound, "No Modules found");
            }
            return Content(HttpStatusCode.OK, module);
        }


        [HttpPost]
        [Route("api/module")]
        public IHttpActionResult InsertModule(Module newModule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this._unitOfWork.Modules.Add(newModule);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, "New Module Added");
        }

        [HttpPut]
        [Route("api/module/{Id}")]
        public IHttpActionResult UpdateModule(int Id, Module module)
        {
            var moduleInDb = this._unitOfWork.Modules.Get(Id);

            if (moduleInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{Id}' not found");

            moduleInDb.Name = module.Name;
            moduleInDb.Route = module.Route;
            moduleInDb.Description = module.Description;
            moduleInDb.Suspend = module.Suspend;
            moduleInDb.Active = module.Active;


            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, $" '{Id}' Updated");
        }


        [HttpDelete]
        [Route("api/module/{Id}")]
        public IHttpActionResult DeleteModule(int Id)
        {
            var ModuleInDb = this._unitOfWork.Modules.Get(Id);
            if (ModuleInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{Id}' not found");
            this._unitOfWork.Modules.Remove(ModuleInDb);
            this._unitOfWork.Complete();


            return Content(HttpStatusCode.OK, $" '{Id}' Deleted");
        }
    }
}