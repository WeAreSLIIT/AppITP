using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models
{
    public class ProductSupplier : Supplier
    {
        public string Brand { set; get; }
        public string ProductID {set; get;}
}
}