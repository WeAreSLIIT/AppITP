using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Core.Domain
{
    public class TransInStock
    {
        [Key]
        public long TransInStockID { get; set; }
        public string TransInStockCode { get; set; }
        public string FromBranchId { get; set; }
        public string FromBranchLoc { get; set; }
        public int RecievedQty { get; set; }
        public long RecievedDate { get; set; }
        public string PublicItemCode { get; set; }
        [ForeignKey("PublicItemCode")]
        public Item Item { get; set; }
        public string ItemName { get; set; }
        public string ItemCategory { get; set; }
        public string UoM { get; set; }
        public int Qty { get; set; }
        public float WholeSaleValue { get; set; }
        public float UnitPrice { get; set; }
    }
}
