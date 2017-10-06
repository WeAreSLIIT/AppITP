using DataAccess.Core.Domain;

namespace DataAccess.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetName(string Name);
    }
}
