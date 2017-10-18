using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Core.Domain
{
    public class Employee : Person
    {   
        [Key]
        public long EmployeeID { get; set; }
        //public string EmployeeName { get; set; }
        public string JobTitle { get; set; }
        public bool Suspend { get; set; }

        public ICollection<Invoice> IssuedInvoices { get; set; }

        public ICollection<InvoiceEmployeeDiscount> DiscountedInvoices { get; set; }
        public ICollection<InvoiceDealDiscount> InvoiceDealDiscount { get; set; }

        public Employee()
        {
            IssuedInvoices = new HashSet<Invoice>();
            DiscountedInvoices = new HashSet<InvoiceEmployeeDiscount>();
            InvoiceDealDiscount = new HashSet<InvoiceDealDiscount>();
        }
    }
}
