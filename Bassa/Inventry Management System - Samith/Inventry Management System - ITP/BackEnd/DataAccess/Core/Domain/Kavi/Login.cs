namespace DataAccess.Core.Domain
{
    public class Login
    {
        public long CustomerID { get; set; }
        public string SecurityQuestion { get; set; }
        public string Answer { get; set; }

        public Customer HasCustomer { get; set; }
    }
}
