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
        public IHttpActionResult GetAll()
        {
            return Content(HttpStatusCode.Found, this._unitOfWork.SubCategories.GetAll());
        }

        [HttpGet]
        public IHttpActionResult GetSubCategory(long Id)
        {
            ICollection<SubCategory> subCategory = new List<SubCategory>();
            subCategory = this._unitOfWork.SubCategories.Search(x => x.CategoryId == Id).ToList();

            if (subCategory == null || subCategory.Count == 0)
            {
                return Content(HttpStatusCode.NotFound, "No SubCategories");
            }

            return Content(HttpStatusCode.Found,subCategory);
        }

        [HttpPost]
        public IHttpActionResult InsertSubCategory(SubCategory subCategory)
        {
            ICollection<SubCategory> subCategories = new List<SubCategory>();
            subCategories = this._unitOfWork.SubCategories
                .Search(x => x.SubCategoryName == subCategory.SubCategoryName && x.CategoryId == subCategory.CategoryId).ToList();

            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.NotAcceptable, "Data is not Valid");
            }
            else if (this._unitOfWork.Categories.Get(subCategory.CategoryId) == null)
            {
                return Content(HttpStatusCode.BadRequest, "Category is not Exist");
            }
            else if (subCategories.Count != 0)
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
        public IHttpActionResult RemoveSubCategory(long Id)
        {
            SubCategory subCategory = this._unitOfWork.SubCategories.Get(Id);

            if (subCategory == null)
            {
                return Content(HttpStatusCode.NotFound, $"SubCategory named '{Id}' is not found");
            }
            else
            {
                this._unitOfWork.SubCategories.Remove(subCategory);
                this._unitOfWork.Complete();

                return Content(HttpStatusCode.OK, $"SubCategory named '{subCategory.SubCategoryName}' is Sucessfully Deleted");
            }
        }
    }
}
