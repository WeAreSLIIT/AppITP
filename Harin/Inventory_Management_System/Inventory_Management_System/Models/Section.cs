using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models
{
    public class Section
    {
        public long SectionId { set; get; }
        public string SectionName { set; get; }

        public ICollection<Rack> Racks { get; set; }
    }
}