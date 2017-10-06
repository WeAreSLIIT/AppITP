using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Mangement_System.Models
{
    public class LoyaltyCard
    {
        //[Key, ForeignKey("OwnedBy")]
        public long LoyaltyCardID { get; set; } 
        public int LoyaltyPoints { set; get; }
        public string Type { set; get; }
        public int RedeemedPoints { set; get; }
        public double UnitCurrencyAmount { set; get; }
        public double Balance { set; get; }

        public long CurrentLoyatyprogramID { set; get; }

        public ICollection<Customer> OwnedCustomer{ get; set; }
        public LoyaltyProgram BelongsToLoyaltyProgram { get; set; }


    }
}