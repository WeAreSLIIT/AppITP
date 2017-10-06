using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Mangement_System.Models
{
    public class Customer
    {
        //[Key]
        public long CustomerID { set; get; }
        public string CustomerPublicID { get; set; }

        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Address { set; get; }
        public string Email { set; get; }
        public string City { set; get; }
        public long DOB { set; get; }
        public int Phone { set; get; }

        public string Password { set; get; }

        public long CurrentLoyaltyCardID { set; get; }

        
        public Credit Credits { get; set; }
        public ICollection<Preorder> Preorders { get; set; }
        public LoyaltyCard OwnedLoyaltyCard { get; set; }
        public Login CustomerLogin { get; set; }


        


    }
}