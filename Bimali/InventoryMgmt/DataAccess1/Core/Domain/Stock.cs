using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public Status Status
        {
            get { return (Status)(this.StockStatus); }
            set { this.StockStatus = (byte)value; }
        }
    }

    public enum Status : byte
    {
        FreeAndAvailable = 0,
        Recount = 1,
        Empty = 2
    }
}
