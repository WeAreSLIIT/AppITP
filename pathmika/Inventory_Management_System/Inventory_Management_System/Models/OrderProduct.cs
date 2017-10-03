using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models
{
    public class OrderProduct : Order
    {
    
        public long? ProductQty { set; get; }
        public string ProductType { set; get; }
    }
}