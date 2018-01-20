using System.Collections.Generic;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace WebAPI.Controllers
{
    //[RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        private UnitOfWork _unitOfWork;

        public EmployeeController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        [Route("api/employee")]
        public IHttpActionResult GetEmployees()
        {
            ICollection<Employee> Employees = new List<Employee>();
            Employees = this._unitOfWork.Employees.GetAll().ToList();
            if (Employees == null || Employees.Count == 0)
                return Content(HttpStatusCode.NotFound, "No Employees found!");

            return Content(HttpStatusCode.OK, Employees);
        }



        [HttpGet]
        [Route("api/employee/{Id}")]
        public IHttpActionResult GetEmployee(int Id)
        {

            var employee = this._unitOfWork.Employees.Get(Id);
            if (employee == null)
            {
                return Content(HttpStatusCode.NotFound, "No Employees found");
            }
            return Content(HttpStatusCode.OK, employee);
        }


        [HttpPost]
        [Route("api/employee")]
        public IHttpActionResult InsertEmployee(Employee newEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this._unitOfWork.Employees.Add(newEmployee);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, "New Employee Added");
        }

        [HttpPut]
        [Route("api/employee/{Id}")]
        public IHttpActionResult UpdateEmployee(int Id, Employee employee)
        {
            var employeeInDb = this._unitOfWork.Employees.Get(Id);

            if (employeeInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{Id}' not found");

            employeeInDb.EmployeeName = employee.EmployeeName;
            employeeInDb.JobTitle = employee.JobTitle;
            employeeInDb.Suspend = employee.Suspend;
            employeeInDb.FirstName = employee.FirstName;
            employeeInDb.LastName = employee.LastName;
            employeeInDb.InitialName = employee.InitialName;
            employeeInDb.Street = employee.Street;
            employeeInDb.Town = employee.Town;
            employeeInDb.City = employee.City;
            employeeInDb.Province = employee.Province;
            employeeInDb.NIC = employee.NIC;
            employeeInDb.Email = employee.Email;
            employeeInDb.Gender = employee.Gender;


            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, $" '{Id}' Updated");
        }


        [HttpDelete]
        [Route("api/employee/{Id}")]
        public IHttpActionResult DeleteEmployee(int Id)
        {
            var EmployeeInDb = this._unitOfWork.Employees.Get(Id);
            if (EmployeeInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{Id}' not found");
            this._unitOfWork.Employees.Remove(EmployeeInDb);
            this._unitOfWork.Complete();


            return Content(HttpStatusCode.OK, $" '{Id}' Deleted");
        }
    }
}