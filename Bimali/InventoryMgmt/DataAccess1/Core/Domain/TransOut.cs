using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Domain
{
    public class TransOut
    {
        [Key]
        public long TransOutStockID { get; set; }
        public string TransOutStockCode { get; set; }
        //[ForeignKey("TransOutStockCode")]
        //public Stock Stock { get; set; }
        public int SentQty { get; set; }
        public long SentDate { get; set; }
        public string GatePass { get; set; }
    }
}
