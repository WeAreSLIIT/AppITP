using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Controllers.Resources
{
    public class InvoiceProductResource
    {
        public long ProductID { get; set; }
        public float Quantity { get; set; }
    }
}