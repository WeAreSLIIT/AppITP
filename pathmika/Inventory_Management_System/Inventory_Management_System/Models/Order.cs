using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models
{
    public class Order
    {
        public long OrderID { set; get; }
        public string PublicOrderID { set; get; }
        public long OrderDate { set; get; }
        public string CompanyName { get; set; }



    }
}