using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory_Mangement_System.Models
{
    public class LoyaltyProgram
    {
        //[Key]
        public long LoyaltyProgramID { get; set; }
        public string Name { set; get; }
        public string ProductInclusion { set; get; }
        public long CreatedDate { set; get; }
       // public double UnitCurrencyAmount{ set; get; }
        public string Description { set; get; }

        public ICollection<LoyaltyCard> OffersLoyaltyCard { get; set; }
}
}