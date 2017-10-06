using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Core.Domain
{
    public class Stock
    {
        [Key]
        public long StockID { get; set; }
        public string PublicStockID { get; set; }
        public string PublicItemCode { get; set; }
        [ForeignKey("PublicItemCode")]
        public Item Item { get; set; }
        public string ItemName { get; set; }
        public string ItemCategory { get; set; }
        public string PurchaseOrder { get; set; }
        public string UoM { get; set; }
        public int InitQty { get; set; }
        public int PresentQty { get; set; }
        public float WholeSaleValue { get; set; }
        public float UnitPrice { get; set; }
        public string GRNnum { get; set; }
        public byte StockStatus { get; set; }


        public StockStatus Status
        {
            get { return (StockStatus)(this.StockStatus); }
            set { this.StockStatus = (byte)value; }
        }
    }
}
