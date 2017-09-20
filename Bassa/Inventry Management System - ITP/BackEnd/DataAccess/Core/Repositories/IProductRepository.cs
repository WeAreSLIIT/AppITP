using DataAccess.Core.Domain;

namespace DataAccess.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Get(string PublicID);
    }
}
