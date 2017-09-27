using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models
{
    public class SubCategory : Category
    {
        public string Description { set; get; }

        public long MainCategoryId { set; get; }
        public Category Category { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}