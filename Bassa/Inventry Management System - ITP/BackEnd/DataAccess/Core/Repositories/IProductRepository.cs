using DataAccess.Core.Domain;
using System.Collections.Generic;

namespace DataAccess.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Get(string PublicID);
    }
}
