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
        public IEnumerable<Category>GetAll()
        {
            return this._unitOfWork.Categories.GetAll();
        }

        [HttpPost]
        public IHttpActionResult InsertCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.NotAcceptable, "Data is not Valid");
            }
            else if (this._unitOfWork.Categories.Get(category.CategoryId) != null)
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
        public IHttpActionResult RemoveCategory(Category category)
        {
            if (this._unitOfWork.Categories.Get(category.CategoryId) == null)
            {
                return Content(HttpStatusCode.NotFound, $"Category named '{category.CategoryName}' is not found");
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
