using System.Collections.Generic;

namespace DataAccess.Core.Domain
{
    public class Employee
    {
        public long EmployeeID { get; set; }

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
