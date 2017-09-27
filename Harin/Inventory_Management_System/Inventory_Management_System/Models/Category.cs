using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models
{
    public class Category
    {
        public long CategoryId { set; get; }
        public string CategoryName { set; get; }

        public ICollection<SubCategory> SubCategories { get; set; }
    }
}