using System.ComponentModel.DataAnnotations;

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
