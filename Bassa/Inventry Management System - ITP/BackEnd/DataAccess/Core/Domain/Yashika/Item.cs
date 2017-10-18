using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Core.Domain
{
    public class Item
    {
        public long ItemCode { get; set; }
        [Key]
        public string PublicItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemCategory { get; set; }
        public string Description { get; set; }
        public ICollection<Stock> Stocks { get; set; }
    }
}
