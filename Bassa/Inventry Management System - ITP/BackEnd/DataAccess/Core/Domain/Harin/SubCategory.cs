using System.Collections.Generic;

namespace DataAccess.Core.Domain
{
    public class SubCategory
    {
        public long SubCategoryId { set; get; }
        public string SubCategoryName { set; get; }
        public string Description { set; get; }

        public long CategoryId { set; get; }
        public Category Category { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
