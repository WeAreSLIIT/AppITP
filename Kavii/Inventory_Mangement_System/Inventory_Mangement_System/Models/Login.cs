using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Mangement_System.Models
{
    public class Login
    {
     //   [Key, ForeignKey("Has")]
        public long CustomerID { get; set; } 
        public string SecurityQuestion { get; set; }
        public string Answer { get; set; }

        public Customer HasCustomer { get; set; } 
        

    }
}