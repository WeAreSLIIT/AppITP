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
    public class CategoryController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public CategoryController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Content(HttpStatusCode.OK,this._unitOfWork.Categories.GetAll());
        }

        [HttpPost]
        public IHttpActionResult InsertCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.NotAcceptable, "Data is not Valid");
            }
            else if (this._unitOfWork.Categories.GetName(category.CategoryName) != null)
            {
                return Content(HttpStatusCode.BadRequest, "Category is already Exist");
            }
            else
            {
                this._unitOfWork.Categories.Add(category);
                this._unitOfWork.Complete();
                return Content(HttpStatusCode.Created, "New Category is Added");
            }
        }

        [HttpDelete]
        public IHttpActionResult RemoveCategory(long Id)
        {
            Category category = this._unitOfWork.Categories.Get(Id);

            if (category == null)
            {
                return Content(HttpStatusCode.NotFound, $"Category named '{Id}' is not found");
            }
            else
            {
                this._unitOfWork.Categories.Remove(category);
                this._unitOfWork.Complete();

                return Content(HttpStatusCode.OK, $"Category named '{category.CategoryName}' is Sucessfully Deleted");
            }
        }
    }
}
