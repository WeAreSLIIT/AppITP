using DataAccess.Core;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System;
using System.Net;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public ProductController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllProducts()
        {
            return Content(HttpStatusCode.OK, this._unitOfWork.Products.GetAll());
        }

        [HttpGet]
        [Route("~/{Id:int}/GetProduct")]
        public IHttpActionResult GetProduct(long Id)
        {
            Product product = this._unitOfWork.Products.Get(Id);
            if (product == null)
            {
                return Content(HttpStatusCode.NotFound, $"Product Id, named '{Id}' not found");
            }
            return Content(HttpStatusCode.OK, product);
        }

        [HttpGet]
        [Route("~/{Id:alpha}/GetProductById")]
        public IHttpActionResult GetProductById(string Id)
        {
            Product product = this._unitOfWork.Products.GetId(Id);
            if (product == null)
            {
                return Content(HttpStatusCode.NotFound, $"Product Id, named '{Id}' not found");
            }
            return Content(HttpStatusCode.OK, product);
        }

        [HttpGet]
        [Route("~/{Id:alpha}/GetProductByName")]
        public IHttpActionResult GetProductByName(string Id)
        {
            Product product = this._unitOfWork.Products.GetName(Id);
            if (product == null)
            {
                return Content(HttpStatusCode.NotFound, $"Product Name = '{Id}' not found");
            }
            return Content(HttpStatusCode.OK, product);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult InsertProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, "Data is not Acceptable");
            }
            else if (this._unitOfWork.Products.GetId(product.ProductPublicId) != null)
            {
                return Content(HttpStatusCode.BadRequest, "Product is already Exist");
            }
            else
            {
                this._unitOfWork.Products.Add(product);
                this._unitOfWork.Complete();
                return Content(HttpStatusCode.Created, "New Product is Added");
            }
        }

        [HttpPost]
        [Route("~/{Id:alpha}/InsertRack")]
        public IHttpActionResult InsertRack(Rack rack, String Id)
        {
            Product product = this._unitOfWork.Products.GetId(Id);
            if (product == null)
            {
                return Content(HttpStatusCode.NotFound, $"Product Id, named '{Id}' not found");
            }
            else if (this._unitOfWork.Racks.Get(rack.RackId) == null)
            {
                return Content(HttpStatusCode.BadRequest, $"Rack name = '{rack.RackName}' is not Exist");
            }
            else if (product.RackId != null)
            {
                return Content(HttpStatusCode.BadRequest, $"Product Id, named '{Id}' Already have a Rack");
            }
            else
            {
                this._unitOfWork.Products.AddProductToRack(product, rack.RackId);
                this._unitOfWork.Complete();
                return Content(HttpStatusCode.OK, "Product is Added to the Rack");
            }
        }

        [HttpDelete]
        [Route("~/{Id:alpha}/RemoveProduct")]
        public IHttpActionResult RemoveProduct(string Id)
        {
            Product product = this._unitOfWork.Products.GetId(Id);
            if (product == null)
            {
                return Content(HttpStatusCode.NotFound, $"Product Id, named '{Id}' not found");
            }
            else
            {
                this._unitOfWork.Products.Remove(product);
                this._unitOfWork.Complete();

                return Content(HttpStatusCode.OK, $"Product Id, named '{Id}' is Deleted");
            }
        }

        [HttpDelete]
        [Route("~/{Id:alpha}/RemoveProductInRack")]
        public IHttpActionResult RemoveProductInRack(string Id)
        {
            Product product = this._unitOfWork.Products.GetId(Id);
            if (product == null)
            {
                return Content(HttpStatusCode.NotFound, $"Product Id, named '{Id}' not found");
            }
            else if (product.RackId == null)
            {
                return Content(HttpStatusCode.BadRequest, $"Product Id, named '{Id}' does not have a Rack");
            }
            else
            {
                this._unitOfWork.Products.RemoveProductFromRack(product);
                this._unitOfWork.Complete();
                return Content(HttpStatusCode.Created, "Product is Removed from the Rack");
            }
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult UpdateProduct(Product product)
        {
            if (this._unitOfWork.Products.GetId(product.ProductPublicId) == null)
            {
                return Content(HttpStatusCode.NotFound, $"Product Id, named '{product.ProductPublicId}' not found");
            }
            else if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, "Data is not Acceptable");
            }
            else
            {
                this._unitOfWork.Products.UpdateProduct(product);
                this._unitOfWork.Complete();
                return Content(HttpStatusCode.OK, "Product is Updated");
            }
        }

        [HttpPut]
        [Route("~/{Id:alpha}")]
        public IHttpActionResult UpdateProductInRack(Rack rack, String Id)
        {
            Product product = this._unitOfWork.Products.GetId(Id);
            if (product == null)
            {
                return Content(HttpStatusCode.NotFound, $"Product Id, named '{Id}' not found");
            }
            else if (product.RackId == null)
            {
                return Content(HttpStatusCode.BadRequest, $"Product Id, named '{Id}' does not have a Rack");
            }
            else if (this._unitOfWork.Racks.Get(rack.RackId) == null)
            {
                return Content(HttpStatusCode.BadRequest, $"Rack name = '{rack.RackName}' is not Exist");
            }
            else
            {
                this._unitOfWork.Products.UpdateProductInRack(product, rack.RackId);
                this._unitOfWork.Complete();
                return Content(HttpStatusCode.OK, "Product is Updated");
            }
        }
    }
}
