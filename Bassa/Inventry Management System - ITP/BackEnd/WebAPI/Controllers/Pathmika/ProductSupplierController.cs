using DataAccess.Core;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ProductSupplierController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public ProductSupplierController()
        {
            this._unitOfWork = new UnitOfWork();

        }



        // GET api/Supplier
        [HttpGet]
        public IEnumerable<ProductSupplier> GetProductSupplier()
        {
            return this._unitOfWork.ProductSuppliers.GetAll();
        }
        // GET api/Supplier/1
        [HttpGet]
        public IHttpActionResult GetProductSupplier(int id)
        {
            var prosupplier = this._unitOfWork.ProductSuppliers.Get(id);
            if (prosupplier == null)
            {
                return Content(HttpStatusCode.NotFound, "Error");
            }
            return Content(HttpStatusCode.NotFound, prosupplier);
        }

        //POST api/Supplier/2
        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertProductSupplier(ProductSupplier productsupplier)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, "Not valid");
            }
            this._unitOfWork.ProductSuppliers.Add(productsupplier);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, "sucessfully inserted");
        }

        //PUT api/Supplier/4
        [HttpPut]
        public IHttpActionResult UpdateProductSupplier(int id, ProductSupplier prosuppllier)
        {
            if (!ModelState.IsValid)
                return Content(HttpStatusCode.BadRequest, "Not valid");
            var prosupplierInDb = this._unitOfWork.ProductSuppliers.Get(id);

            if (prosupplierInDb == null)
                return Content(HttpStatusCode.NotFound, "Not found");


            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, "Updated sucessfully");
        }

        //DELETE api/Supplier/4
        [HttpDelete]
        public IHttpActionResult DeleteProductSupplier(int id)
        {
            var prosupplierInDb = this._unitOfWork.ProductSuppliers.Get(id);

            if (prosupplierInDb == null)
                return Content(HttpStatusCode.NotFound, "Not found");
            this._unitOfWork.ProductSuppliers.Remove(prosupplierInDb);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, "Removed Sucessfully");
        }
    }
}
