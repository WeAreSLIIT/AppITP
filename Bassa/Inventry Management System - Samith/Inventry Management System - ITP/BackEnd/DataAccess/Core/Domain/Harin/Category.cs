using System.Collections.Generic;

namespace DataAccess.Core.Domain
{
    public class Category
    {
        public long CategoryId { set; get; }
        public string CategoryName { set; get; }

        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
