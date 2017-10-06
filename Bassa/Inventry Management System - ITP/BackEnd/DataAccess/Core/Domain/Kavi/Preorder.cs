namespace DataAccess.Core.Domain
{
    public class Preorder
    {
        public long PreorderID { get; set; }
        public string PreorderPublicID { get; set; }
        public string Item { set; get; }
        public int Quantity { set; get; }
        public long PreorderDate { set; get; }

        public long CurrentCustomerID { get; set; }

        public Customer PreorderCustomer { get; set; }
    }
}
