using Inventory_Management_System.Models;
using Inventory_Management_System.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Inventory_Management_System.Controllers
{
    public class ProductsController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public ProductsController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProduct()
        {
            return this._unitOfWork.Products.GetAll();
        }

        [HttpGet]
        public IHttpActionResult GetProduct(long Id)
        {
            Product product= this._unitOfWork.Products.Get(Id);
            if (product == null)
            {
                return Content(HttpStatusCode.NotFound, $"Product Id, named '{Id}' not found");
            }
            return Content(HttpStatusCode.OK, product);
        }

        [HttpGet]
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
        public IHttpActionResult GetProductByName(string Name)
        {
            Product product = this._unitOfWork.Products.GetName(Name);
            if (product == null)
            {
                return Content(HttpStatusCode.NotFound, $"Product Name = '{Name}' not found");
            }
            return Content(HttpStatusCode.OK, product);
        }

        [HttpPost]
        public IHttpActionResult InsertProduct(Product product)
        {
            if(!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, "Data is not Acceptable");
            }
            else if(this._unitOfWork.Products.GetId(product.ProductPublicId) != null)
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
        public IHttpActionResult InsertRack(Rack rack,String Id)
        {
            Product product = this._unitOfWork.Products.GetId(Id);
            if (product == null)
            {
                return Content(HttpStatusCode.NotFound, $"Product Id, named '{Id}' not found");
            }
            else if(product.RackId != null)
            {
                return Content(HttpStatusCode.BadRequest, $"Product Id, named '{Id}' Already have a Rack");
            }
            else
            {
                this._unitOfWork.Products.AddProductToRack(product,rack.RackId);
                this._unitOfWork.Complete();
                return Content(HttpStatusCode.OK, "Product is Added to the Rack");
            }
        }

        [HttpDelete]
        public IHttpActionResult RemoveProduct(string Id)
        {
            Product product = this._unitOfWork.Products.GetId(Id);
            if(product == null)
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
        public IHttpActionResult RemoveProductsInRack(String Id)
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
        public IHttpActionResult UpdateProduct(Product product)
        {
            if(this._unitOfWork.Products.GetId(product.ProductPublicId) == null)
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
        public IHttpActionResult UpdateProductInRack(Rack rack, String Id)
        {
            Product product = this._unitOfWork.Products.GetId(Id);
            if (product == null)
            {
                return Content(HttpStatusCode.NotFound, $"Product Id, named '{Id}' not found");
            }
            else
            {
                this._unitOfWork.Products.AddProductToRack(product, rack.RackId);
                this._unitOfWork.Complete();
                return Content(HttpStatusCode.OK, "Product is Updated");
            }
        }
    }
}
