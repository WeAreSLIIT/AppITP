namespace DataAccess.Core.Domain
{
    public class InvoiceDeal
    {
        public long InvoiceID { get; set; }
        public Invoice Invoice { get; set; }

        public long InvoiceDealDiscountID { get; set; }
        public InvoiceDealDiscount InvoiceDealDiscount { get; set; }
    }
}
