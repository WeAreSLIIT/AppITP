using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory_Mangement_System.Models
{
    public class Preorder
    {
        //[Key]
        public long PreorderID { get; set; }
        public string PreorderPublicID { get; set; }
        public string Item { set; get; }
        public int Quantity { set; get; }
        public long PreorderDate { set; get; }

        public long CurrentCustomerID { get; set; }

        public Customer PreorderCustomer { get; set; }
       


    }
}