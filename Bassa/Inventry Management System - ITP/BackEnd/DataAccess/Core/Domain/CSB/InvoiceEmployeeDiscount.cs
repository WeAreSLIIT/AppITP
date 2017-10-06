namespace DataAccess.Core.Domain
{
    public class InvoiceEmployeeDiscount
    {
        public long InvoiceEmployeeDiscountID { get; set; }
        
        //Price = 0, percentage = 1
        public byte Method { get; set; }
        public DiscountMethod DiscountMethod
        {
            get { return (DiscountMethod)(this.Method); }
            set { this.Method = (byte)value; }
        }

        public float Amount { get; set; }
        public long InvoiceID { get; set; }

        public long PermittedEmployeeID { get; set; }
        public Employee PermittedEmployee { get; set; }

        public Invoice Invoice { get; set; }
    }
}
