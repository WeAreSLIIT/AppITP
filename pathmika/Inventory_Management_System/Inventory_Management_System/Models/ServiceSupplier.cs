using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models
{
    public class ServiceSupplier :Supplier
    {
        public string ServiceName { set; get; }
        public int ServiceRate { set; get; }
    }
}