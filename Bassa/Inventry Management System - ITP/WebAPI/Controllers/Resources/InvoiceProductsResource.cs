namespace WebAPI.Controllers.Resources
{
    public class InvoiceProductsResource
    {
        public long InvoiceID { get; set; }
        public long ProductID { get; set; }
        public float Quantity { get; set; }
    }
}