using Inventory_Management_System.Models;
using Inventory_Management_System.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private new Inventory_Management_System_DbContext _context;

        public ProductRepository(Inventory_Management_System_DbContext Context) : base(Context)
        {
            this._context = Context;
        }
        public Product GetId(string Id)
        {
            return this._context.Products.SingleOrDefault(pi => pi.ProductPublicId == Id);
        }
        public Product GetName(string Name)
        {
            return this._context.Products.SingleOrDefault(pn => pn.ProductName == Name);
        }

        public long ConvertPublicId(String Id)
        {
            return _context.Products.Where(pi => pi.ProductPublicId == Id).Select(p => p.ProductId).SingleOrDefault();
        }

        public String ConvertId(long Id)
        {
            return _context.Products.Where(pi => pi.ProductId == Id).Select(p => p.ProductPublicId).SingleOrDefault();
        }

        public void UpdateProduct(Product product)
        {
            Product ProductUpdate = _context.Products.FirstOrDefault(p => p.ProductPublicId == product.ProductPublicId);
            ProductUpdate.ProductName = product.ProductName;
            ProductUpdate.ProductBrand = product.ProductBrand;
            ProductUpdate.Cost = product.Cost;
            ProductUpdate.NotifyDay = product.NotifyDay;
            ProductUpdate.Price = product.Price;
            ProductUpdate.PriceType = product.PriceType;
            ProductUpdate.SubCategoryId = product.SubCategoryId;

            if (product.PriceType == PriceType.PackPrice)
            {
                ProductUpdate.NumberOfUnits = product.NumberOfUnits;
                ProductUpdate.Unit = null;
            }
            else if(product.PriceType == PriceType.UnitPrice)
            {
                ProductUpdate.NumberOfUnits = null;
                ProductUpdate.Unit = product.Unit;
            }
            else
            {
                ProductUpdate.NumberOfUnits = null;
                ProductUpdate.Unit = null;
            }
            
            _context.SaveChanges();
        }

        public void AddProductToRack(Product product,long Id)
        {
            Product ProductInRack = _context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            ProductInRack.RackId = Id;

            _context.SaveChanges();
        }

        public void RemoveProductFromRack(Product product)
        {
            Product ProductInRack = _context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            ProductInRack.RackId = null;

            _context.SaveChanges();
        }

        public void UpdateProductInRack(Product product, long Id)
        {
            Product ProductInRack = _context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            ProductInRack.RackId = Id;
            
            _context.SaveChanges();
        }
    }
}