namespace DataAccess.Core.Domain
{
    public class Order
    {
        public long OrderID { set; get; }
        public string PublicOrderID { set; get; }
        public long OrderDate { set; get; }
        public string CompanyName { get; set; }
    }
}
