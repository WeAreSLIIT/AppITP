namespace DataAccess.Core.Domain
{
    public class Credit
    {
        public long CustomerID { get; set; }
        public double CreditLimit { set; get; }
        public double CreditAmount { set; get; }
        public long ExpireDate { set; get; }
        
        public Customer CreditCustomer { get; set; }
    }
}
