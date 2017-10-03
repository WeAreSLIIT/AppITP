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
<<<<<<< HEAD
        public IEnumerable<Category>GetAll()
        {
            return this._unitOfWork.Categories.GetAll();
=======
        public IHttpActionResult GetAll()
        {
            return Content(HttpStatusCode.Found,this._unitOfWork.Categories.GetAll());
>>>>>>> master
        }

        [HttpPost]
        public IHttpActionResult InsertCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.NotAcceptable, "Data is not Valid");
            }
<<<<<<< HEAD
            else if (this._unitOfWork.Categories.Get(category.CategoryId) != null)
=======
            else if (this._unitOfWork.Categories.GetName(category.CategoryName) != null)
>>>>>>> master
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
<<<<<<< HEAD
        public IHttpActionResult RemoveCategory(Category category)
        {
            if (this._unitOfWork.Categories.Get(category.CategoryId) == null)
            {
                return Content(HttpStatusCode.NotFound, $"Category named '{category.CategoryName}' is not found");
=======
        public IHttpActionResult RemoveCategory(long Id)
        {
            Category category = this._unitOfWork.Categories.Get(Id);

            if (category == null)
            {
                return Content(HttpStatusCode.NotFound, $"Category named '{Id}' is not found");
>>>>>>> master
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
