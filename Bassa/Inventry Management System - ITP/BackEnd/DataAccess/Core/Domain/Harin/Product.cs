using System.Collections.Generic;

namespace DataAccess.Core.Domain
{
    public class Product
    {
        public long ProductId { get; set; }
        public string ProductPublicId { get; set; }
        public string ProductName { get; set; }
        public string ProductBrand { set; get; }
        public string Barcode { set; get; }

        public ICollection<InvoiceProduct> InvoiceProducts { get; set; }

        public Product()
        {
            InvoiceProducts = new HashSet<InvoiceProduct>();
        }
        
        
        public double Cost { set; get; }
        public int? NotifyDay { set; get; }
        public double Price { set; get; }
        public ProductPriceType PriceType { set; get; }
        public int? NumberOfUnits { set; get; }
        public double? Unit { set; get; }

        public long? RackId { set; get; }
        public Rack Rack { set; get; }

        public long SubCategoryId { set; get; }
        public SubCategory SubCategory { set; get; }

    }
}
