using System.Collections.Generic;
using DataAccess.Core.Domain;
using DataAccess.Persistence;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace WebAPI.Controllers
{
    //[RoutePrefix("api/person")]
    public class PersonController : ApiController
    {
        private UnitOfWork _unitOfWork;

        public PersonController()
        {
            this._unitOfWork = new UnitOfWork();
        }

        [HttpGet]
        [Route("api/person")]
        public IHttpActionResult GetPersons()
        {
            ICollection<Person> Persons = new List<Person>();
            Persons = this._unitOfWork.Persons.GetAll().ToList();
            if (Persons == null || Persons.Count == 0)
                return Content(HttpStatusCode.NotFound, "No Persons found!");

            return Content(HttpStatusCode.OK, Persons);
        }



        [HttpGet]
        [Route("api/person/{Id}")]
        public IHttpActionResult GetPerson(int Id)
        {

            var person = this._unitOfWork.Persons.Get(Id);
            if (person == null)
            {
                return Content(HttpStatusCode.NotFound, "No Persons found");
            }
            return Content(HttpStatusCode.OK, person);
        }


        [HttpPost]
        [Route("api/person")]
        public IHttpActionResult InsertPerson(Person newPerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            this._unitOfWork.Persons.Add(newPerson);
            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, "New Person Added");
        }

        [HttpPut]
        [Route("api/person/{Id}")]
        public IHttpActionResult UpdatePerson(int Id, Person person)
        {
            var personInDb = this._unitOfWork.Persons.Get(Id);

            if (personInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{Id}' not found");

            personInDb.FirstName = person.FirstName;
            personInDb.LastName = person.LastName;
            personInDb.InitialName = person.InitialName;
            personInDb.Street = person.Street;
            personInDb.Town = person.Town;
            personInDb.City = person.City;
            personInDb.Province = person.Province;
            personInDb.NIC = person.NIC;
            personInDb.Email = person.Email;
            personInDb.Gender = person.Gender;


            this._unitOfWork.Complete();
            return Content(HttpStatusCode.OK, $" '{Id}' Updated");
        }


        [HttpDelete]
        [Route("api/person/{Id}")]
        public IHttpActionResult DeletePerson(int Id)
        {
            var PersonInDb = this._unitOfWork.Persons.Get(Id);
            if (PersonInDb == null)
                return Content(HttpStatusCode.NotFound, $" '{Id}' not found");
            this._unitOfWork.Persons.Remove(PersonInDb);
            this._unitOfWork.Complete();


            return Content(HttpStatusCode.OK, $" '{Id}' Deleted");
        }
    }
}