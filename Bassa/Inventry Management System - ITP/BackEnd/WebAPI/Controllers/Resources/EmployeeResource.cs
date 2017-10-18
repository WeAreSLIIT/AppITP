using System.Collections.Generic;

namespace WebAPI.Controllers.Resources
{
    public class EmployeeResource
    {
        public long EmployeeID { get; set; }

        public ICollection<InvoiceResource> IssuedInvoices { get; set; }

        public ICollection<InvoiceEmployeeDiscountResource> DiscountedInvoices { get; set; }
        public ICollection<InvoiceDealDiscountResource> InvoiceDealDiscount { get; set; }

        public EmployeeResource()
        {
            IssuedInvoices = new HashSet<InvoiceResource>();
            DiscountedInvoices = new HashSet<InvoiceEmployeeDiscountResource>();
            InvoiceDealDiscount = new HashSet<InvoiceDealDiscountResource>();
        }
    }
}