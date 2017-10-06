namespace DataAccess.Core.Domain
{
    public class InvoicePaymentMethod
    {
        public long InvoiceID { get; set; }
        public Invoice Invoice { get; set; }

        public long PaymentMethodID { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public float Amount { get; set; }
    }
}
