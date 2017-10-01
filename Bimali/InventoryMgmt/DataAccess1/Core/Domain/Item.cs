using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ICollection <Stock> Stocks { get; set; }

    }
}
