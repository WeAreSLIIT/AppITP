namespace WebAPI.Controllers.Resources
{
    public class InvoiceCustomerResource
    {
        public long InvoiceID { get; set; }
        public InvoiceResource Invoice { get; set; }

        public long CustomerID { get; set; }
        public CustomerResource PurchasedBy { get; set; }
    }
}