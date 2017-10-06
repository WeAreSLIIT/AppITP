using DataAccess.Core;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ServiceSupplierController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public ServiceSupplierController()
        {
            this._unitOfWork = new UnitOfWork();

        }



        // GET api/Supplier
        public IEnumerable<ServiceSupplier> GetServiceSupplier()
        {
            return this._unitOfWork.ServiceSuppliers.GetAll();
        }
        // GET api/Supplier/1
        public IHttpActionResult GetSupplier(int id)
        {
            var servicesupplier = this._unitOfWork.ServiceSuppliers.Get(id);
            if (servicesupplier == null)
            {
                return Content(HttpStatusCode.NotFound, "Error");
            }
            return Content(HttpStatusCode.NotFound, servicesupplier);
        }

        //POST api/Supplier/2
        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertSupplier(ServiceSupplier servicesupplier)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, "Not valid");
            }
            this._unitOfWork.ServiceSuppliers.Add(servicesupplier);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, "Successfully Inserted");
        }

        //PUT api/Supplier/4
        [HttpPut]
        public IHttpActionResult UpdateServiceSupplier(int id, ServiceSupplier suppllier)
        {
            if (!ModelState.IsValid)
                return Content(HttpStatusCode.NotFound, "Not Valid");
            var servicesupplierInDb = this._unitOfWork.ServiceSuppliers.Get(id);

            if (servicesupplierInDb == null)
                return Content(HttpStatusCode.NotFound, "Not found");
            servicesupplierInDb.ServiceName = suppllier.ServiceName;
            servicesupplierInDb.ServiceRate = suppllier.ServiceRate;

            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, "Successfully updated");
        }

        //DELETE api/Supplier/4
        [HttpDelete]
        public IHttpActionResult DeleteServiceSupplier(int id)
        {
            var servicesupplierInDb = this._unitOfWork.ServiceSuppliers.Get(id);

            if (servicesupplierInDb == null)
                return Content(HttpStatusCode.NotFound, $"Supplier of ID '{id}' is not found");
            this._unitOfWork.ServiceSuppliers.Remove(servicesupplierInDb);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, "Succesfully removed");
        }
    }
}
