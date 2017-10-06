namespace DataAccess.Core.Domain
{
    public class InvoiceCustomer
    {
        public long InvoiceID { get; set; }
        public Invoice Invoice { get; set; }

        public long CustomerID { get; set; }
        public Customer PurchasedBy { get; set; }
    }
}
