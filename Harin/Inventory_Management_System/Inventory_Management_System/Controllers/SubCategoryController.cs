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
<<<<<<< HEAD
        public IEnumerable<SubCategory> GetAll()
        {
            return this._unitOfWork.SubCategories.GetAll();
=======
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
>>>>>>> master
        }

        [HttpPost]
        public IHttpActionResult InsertSubCategory(SubCategory subCategory)
        {
<<<<<<< HEAD
=======
            ICollection<SubCategory> subCategories = new List<SubCategory>();
            subCategories = this._unitOfWork.SubCategories
                .Search(x => x.SubCategoryName == subCategory.SubCategoryName && x.CategoryId == subCategory.CategoryId).ToList();

>>>>>>> master
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.NotAcceptable, "Data is not Valid");
            }
<<<<<<< HEAD
            else if (this._unitOfWork.SubCategories.Get(subCategory.CategoryId) != null)
=======
            else if (this._unitOfWork.Categories.Get(subCategory.CategoryId) == null)
            {
                return Content(HttpStatusCode.BadRequest, "Category is not Exist");
            }
            else if (subCategories.Count != 0)
>>>>>>> master
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
<<<<<<< HEAD
        public IHttpActionResult RemoveSubCategory(SubCategory subCategory)
        {
            if (this._unitOfWork.SubCategories.Get(subCategory.CategoryId) == null)
            {
                return Content(HttpStatusCode.NotFound, $"SubCategory named '{subCategory.CategoryName}' is not found");
=======
        public IHttpActionResult RemoveSubCategory(long Id)
        {
            SubCategory subCategory = this._unitOfWork.SubCategories.Get(Id);

            if (subCategory == null)
            {
                return Content(HttpStatusCode.NotFound, $"SubCategory named '{Id}' is not found");
>>>>>>> master
            }
            else
            {
                this._unitOfWork.SubCategories.Remove(subCategory);
                this._unitOfWork.Complete();

<<<<<<< HEAD
                return Content(HttpStatusCode.OK, $"SubCategory named '{subCategory.CategoryName}' is Sucessfully Deleted");
=======
                return Content(HttpStatusCode.OK, $"SubCategory named '{subCategory.SubCategoryName}' is Sucessfully Deleted");
>>>>>>> master
            }
        }
    }
}
