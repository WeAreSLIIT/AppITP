using System.ComponentModel.DataAnnotations;

namespace DataAccess.Core.Domain
{
    public class Wastage
    {
        [Key]
        public long WastageStockID { get; set; }
        public string WastageStockCode { get; set; }
        //[ForeignKey("WastageStockCode")]
        //public Stock Stock { get; set; }
        public string WastageCause { get; set; }
        public int WastageQty { get; set; }
        public float WastageValue { get; set; }
    }
}
