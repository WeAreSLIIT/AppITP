using DataAccess.Core;
using DataAccess.Core.Domain;
using System.Collections.Generic;
using WebAPI.Controllers.Resources;

namespace WebAPI.Controllers.Methods
{
    public class ProductForInvoiceControllerMethods
    {
        private IUnitOfWork _unitOfWork;

        public ProductForInvoiceControllerMethods(IUnitOfWork UnitOfWork)
        {
            this._unitOfWork = UnitOfWork;
        }

        public ICollection<ProductForInvoiceResource> ListProductsToProductForInvoiceResources(ICollection<Product> Products)
        {
            if (Products == null || Products.Count == 0)
                return null;

            ICollection<ProductForInvoiceResource> ProductForInvoiceResources = new List<ProductForInvoiceResource>();

            foreach (Product Product in Products)
            {
                ProductForInvoiceResources.Add(new ProductForInvoiceResource()
                {
                    ID = Product.ProductPublicId,
                    Name = Product.ProductBrand + " " + Product.ProductName,
                    Bracode = Product.Barcode,
                    Price = (float)Product.Price,
                    Type = (byte)Product.PriceType
                });
            }

            return ProductForInvoiceResources;
        }
    }
}