namespace WebAPI.Controllers.Resources
{
    public class InvoiceDealDiscountResource
    {
        public long InvoiceDealDiscountID { get; set; }

        //Price = 0, percentage = 1
        public byte Method { get; set; }

        public float Amount { get; set; }
        public string Note { get; set; }

        public long GivenEmployeeID { get; set; }
    }
}