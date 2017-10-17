using DataAccess.Core.Domain;

namespace DataAccess.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Get(string PublicID);

        Product GetId(string PublicID);
        Product GetName(string Name);
        long ConvertPublicId(string Id);
        string ConvertId(long Id);
        void UpdateProduct(Product product);
        void AddProductToRack(Product product, long Id);
        void RemoveProductFromRack(Product product);
        void UpdateProductInRack(Product product, long Id);
    }
}
