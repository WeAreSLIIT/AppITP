using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Domain
{
    public class Recount
    {
        [Key]
        public long RecountStockId { get; set; }
        public string RecountStockCode { get; set; }
        //[ForeignKey("RecountStockCode")]
        //public Stock Stock { get; set; }
        public byte StockStatus { get; set; }
        public int ChangedQty { get; set; }
        public long RecountStartDate { get; set; }
        public long RecountEndDate { get; set; }

        public StockStatus Status
        {
            get { return (StockStatus)(this.StockStatus); }
            set { this.StockStatus = 1; }
        }
    }
}
