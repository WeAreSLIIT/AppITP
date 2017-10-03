using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Domain
{
    public class ReturnStock 
    {
        [Key]
        public long ReturnStockID { get; set; }
        public string ReturnStockCode { get; set; }
        //[ForeignKey("ReturnStockCode")]
        //public Stock Stock { get; set; }
        public string ReturnCause { get; set; }
        public int ReturnQty { get; set; }
        public string Replacement { get; set; }
        public string ReturnedToSupplier { get; set; }
    }
}
