using System.Collections.Generic;

namespace DataAccess.Core.Domain
{
    public class LoyaltyProgram
    {
        public long LoyaltyProgramID { get; set; }
        public string Name { set; get; }
        public string ProductInclusion { set; get; }
        public long CreatedDate { set; get; }
        public string Description { set; get; }

        public ICollection<LoyaltyCard> OffersLoyaltyCard { get; set; }
    }
}
