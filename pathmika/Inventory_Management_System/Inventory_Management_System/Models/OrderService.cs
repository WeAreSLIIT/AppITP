using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models
{
    public class OrderService : Order
    {
   
        public string ServiceType { set; get; }
    }
}