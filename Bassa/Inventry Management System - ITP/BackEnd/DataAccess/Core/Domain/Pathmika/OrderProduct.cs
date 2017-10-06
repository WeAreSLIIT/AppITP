namespace DataAccess.Core.Domain
{
    public class OrderProduct : Order
    {
        public long? ProductQty { set; get; }
        public string ProductType { set; get; }
    }
}
