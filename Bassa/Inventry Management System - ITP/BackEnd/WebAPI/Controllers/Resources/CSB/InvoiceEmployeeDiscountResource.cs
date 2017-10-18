namespace WebAPI.Controllers.Resources
{
    public class InvoiceEmployeeDiscountResource
    {
        public long InvoiceEmployeeDiscountID { get; set; }

        //Price = 0, percentage = 1
        public byte Method { get; set; }
        public DiscountMethodResource DiscountMethod
        {
            get { return (DiscountMethodResource)(this.Method); }
            set { this.Method = (byte)value; }
        }

        public float Amount { get; set; }
        public long InvoiceID { get; set; }

        public long PermittedEmployeeID { get; set; }
        public EmployeeResource PermittedEmployee { get; set; }

        public InvoiceResource Invoice { get; set; }
    }
}