using System.Collections.Generic;

namespace DataAccess.Core.Domain
{
    public class LoyaltyCard
    {
        public long LoyaltyCardID { get; set; }
        public int LoyaltyPoints { set; get; }
        public string Type { set; get; }
        public int RedeemedPoints { set; get; }
        public double UnitCurrencyAmount { set; get; }
        public double Balance { set; get; }

        public long CurrentLoyatyprogramID { set; get; }

        public ICollection<Customer> OwnedCustomer { get; set; }
        public LoyaltyProgram BelongsToLoyaltyProgram { get; set; }
    }
}
