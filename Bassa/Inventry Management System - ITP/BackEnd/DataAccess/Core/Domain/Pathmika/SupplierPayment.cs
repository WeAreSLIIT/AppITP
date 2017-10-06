namespace DataAccess.Core.Domain
{
    public class SupplierPayment
    {
        public long SupplierPaymentID { set; get; }
        public string PaymentPublicID { set; get; }
        public double SupplierDeliverCost { set; get; }
        public long DueDate { set; get; }
        public long PayingDate { set; get; }
        public float subTotal { set; get; }
        public float TotalCost { set; get; }
    }
}
