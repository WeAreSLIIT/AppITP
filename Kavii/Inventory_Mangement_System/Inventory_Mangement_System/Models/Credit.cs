using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Inventory_Mangement_System.Models
{
    public class Credit
    {
        //[Key,ForeignKey("CreditCustomer")]
        public long CustomerID { get; set; }
        public double CreditLimit { set; get; }
        public double CreditAmount { set; get; }
        public long ExpireDate { set; get; }

       
        public Customer CreditCustomer { get; set; }
    }
}