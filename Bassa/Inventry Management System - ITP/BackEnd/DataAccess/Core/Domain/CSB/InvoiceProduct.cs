namespace DataAccess.Core.Domain
{
    public class InvoiceProduct
    {
        public long InvoiceID { get; set; }
        public Invoice Invoice { get; set; }

        public long ProductID { get; set; }
        public Product Product { get; set; }

        public float Quantity { get; set; }
    }
}
