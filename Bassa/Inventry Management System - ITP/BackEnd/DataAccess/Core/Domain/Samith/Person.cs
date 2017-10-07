using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Core.Domain
{
    public class Person
    {   
        [Key]
        public long PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string InitialName { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string NIC { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }

        public ICollection<Person> Persons { get; set; }

        public Person()
        {
            Persons = new HashSet<Person>();
        }
    }
}
