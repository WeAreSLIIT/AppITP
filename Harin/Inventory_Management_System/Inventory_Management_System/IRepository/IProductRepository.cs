using Inventory_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetId(String Id);
        Product GetName(String Name);
        long ConvertPublicId(String Id);
        String ConvertId(long Id);
        void UpdateProduct(Product product);
        void AddProductToRack(Product product, long Id);
        void RemoveProductFromRack(Product product);
        void UpdateProductInRack(Product product, long Id);
    }
}
