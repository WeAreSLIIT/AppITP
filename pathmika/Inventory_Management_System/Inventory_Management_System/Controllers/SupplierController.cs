using Inventory_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Inventory_Management_System.Persistence;
using Inventory_Management_System;

namespace Inventory_Management_System.Controllers
{
    public class SupplierController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public SupplierController()
        {
            this._unitOfWork = new UnitOfWork();

        }



        // GET api/Supplier
        [HttpGet]
        public IEnumerable<Supplier> GetSupplier()
        {
            return this._unitOfWork.Suppliers.GetAll();
        }
        // GET api/Supplier/1
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetSupplier(int id)
        {
            Supplier supplier = this._unitOfWork.Suppliers.Get(id);
            if (supplier == null)
            {
                return Content(HttpStatusCode.NotFound, $"No supplier in ID '{id}' is found");
            }
            return Content(HttpStatusCode.NotFound, supplier);
        }

        //POST api/Supplier/2
        [System.Web.Http.HttpPost]
        public  IHttpActionResult InsertSupplier(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, "Not valid"); 
            }
            this._unitOfWork.Suppliers.Add(supplier);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK,"Successfully Inserted");
        }

        //PUT api/Supplier/4
        public IHttpActionResult UpdateSupplier(int id, Supplier suppllier)
        {
            if (!ModelState.IsValid)
                return Content(HttpStatusCode.NotFound, "Not Valid");
            var supplierInDb = this._unitOfWork.Suppliers.Get(id);
               
            if (supplierInDb == null)
                return Content(HttpStatusCode.NotFound,"Not found");

            supplierInDb.FirstName = suppllier.FirstName;
            supplierInDb.LastName = suppllier.LastName;
            supplierInDb.AddedDate = suppllier.AddedDate;
            supplierInDb.companyName = suppllier.companyName;
            supplierInDb.companyAddress = suppllier.companyAddress;
            supplierInDb.companyPhone = supplierInDb.companyPhone;
            supplierInDb.email = supplierInDb.email;
            this._unitOfWork.Complete();

            return Content(HttpStatusCode.OK,"Successfully updated");
        }

        //DELETE api/Supplier/4
        [HttpDelete]
        public IHttpActionResult DeleteSupplier(int id)
        {
            Supplier supplierInDb = this._unitOfWork.Suppliers.Get(id);

            if (supplierInDb == null)
              return  Content(HttpStatusCode.NotFound, $"Supplier of ID '{id}' is not found");
            this._unitOfWork.Suppliers.Remove(supplierInDb);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, "Succesfully removed");
        }

        //public HttpResponseMessage Get(int id)
        //{
        //	var discount = _unitOfWork.DiscountSchedules.GetDiscountById(id);
        //	if (discount != null)
        //		return Request.CreateResponse(HttpStatusCode.OK, discount);
        //	return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No discount found for this id");
        //}

        //public bool Delete(int id)
        //{
        //	if (id > 0)
        //	{
        //		var discount = this._unitOfWork.DiscountSchedules.GetDiscountById(id);
        //		if (discount != null)
        //		{
        //			this._unitOfWork.DiscountSchedules.DeleteDiscount(discount);
        //			this._unitOfWork.Complete();

        //		}
        //	}

        //}
        //   [System.Web.Http.HttpPost]
        //   [ValidateAntiForgeryToken]
        //   //[ValidateInput(false)]
        //public actionresult edit([bind(include = "id,title,introtext,body,modified,author")] discountschedule post)
        //{

        //	discountschedule edit = this._unitofwork.discountschedules.getdiscountbyid(post);
        //	edit.title = post.title;
        //	edit.introtext = post.introtext;
        //	edit.body = post.body;
        //	edit.modified = datetime.now;

        //	this._unitofwork.complete();
    }
}
namespace MyInventoryManagementSystem.Controllers
{
    public class DiscountScheduleController : ApiController
    {
        


    }


}
