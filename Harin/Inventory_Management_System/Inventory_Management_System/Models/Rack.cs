using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models
{
    public class Rack
    {
        public long RackId { set; get; }
        public string RackName { set; get; }

        public long SectionId { set; get; }
        public Section Section { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}