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
    public class SubCategoryController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public SubCategoryController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        public IEnumerable<SubCategory> GetAll()
        {
            return this._unitOfWork.SubCategories.GetAll();
        }

        [HttpPost]
        public IHttpActionResult InsertSubCategory(SubCategory subCategory)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.NotAcceptable, "Data is not Valid");
            }
            else if (this._unitOfWork.SubCategories.Get(subCategory.CategoryId) != null)
            {
                return Content(HttpStatusCode.BadRequest, "SubCategory is already Exist");
            }
            else
            {
                this._unitOfWork.SubCategories.Add(subCategory);
                this._unitOfWork.Complete();
                return Content(HttpStatusCode.Created, "New SubCategory is Added");
            }
        }

        [HttpDelete]
        public IHttpActionResult RemoveSubCategory(SubCategory subCategory)
        {
            if (this._unitOfWork.SubCategories.Get(subCategory.CategoryId) == null)
            {
                return Content(HttpStatusCode.NotFound, $"SubCategory named '{subCategory.CategoryName}' is not found");
            }
            else
            {
                this._unitOfWork.SubCategories.Remove(subCategory);
                this._unitOfWork.Complete();

                return Content(HttpStatusCode.OK, $"SubCategory named '{subCategory.CategoryName}' is Sucessfully Deleted");
            }
        }
    }
}
