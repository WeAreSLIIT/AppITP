using System.Collections.Generic;

namespace DataAccess.Core.Domain
{
    public class Customer
    {
        public long CustomerID { get; set; }
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
        public LoyaltyCard OwnedLoyaltyCard { get; set; }
        public Login CustomerLogin { get; set; }


        public ICollection<Preorder> Preorders { get; set; }
        //By CSB
        public ICollection<InvoiceCustomer> Invoices { get; set; }

        public Customer()
        {
            Invoices = new HashSet<InvoiceCustomer>();
            Preorders = new HashSet<Preorder>();
        }
    }
}
