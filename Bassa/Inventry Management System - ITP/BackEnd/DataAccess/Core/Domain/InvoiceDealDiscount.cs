using System.Collections.Generic;

namespace DataAccess.Core.Domain
{
    public class InvoiceDealDiscount
    {
        public long InvoiceDealDiscountID { get; set; }

        //Price = 0, Percentage = 1
        public byte Method { get; set; }
        public DiscountMethod DiscountMethod
        {
            get { return (DiscountMethod)(this.Method); }
            set { this.Method = (byte)value; }
        }

        public float Amount { get; set; }
        public string Note { get; set; }

        public long GivenEmployeeID { get; set; }
        public Employee GivenEmployee { get; set; }

        public ICollection<InvoiceDeal> AffectedInvoices { get; set; }

        public InvoiceDealDiscount()
        {
            AffectedInvoices = new HashSet<InvoiceDeal>();
        }
    }
}
