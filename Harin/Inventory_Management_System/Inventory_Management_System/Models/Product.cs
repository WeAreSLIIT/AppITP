using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Models
{
    public class Product
    {

        public long ProductId { set; get; }
        public string ProductPublicId { set; get; }
        public string Barcode { set; get; }
        public string ProductName { set; get; }
        public string ProductBrand { set; get; }
        public double Cost { set; get; }
        public int? NotifyDay { set; get; }
        public double Price { set; get; }
        public PriceType PriceType { set; get; }
        public int? NumberOfUnits { set; get; }
        public double? Unit { set; get; }

        public long? RackId { set; get; }
        public Rack Rack { set; get; }

        public long SubCategoryId { set; get; }
        public SubCategory SubCategory { set; get; }

    }
}