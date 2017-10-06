using DataAccess.Core.Domain;

namespace DataAccess.Core.Repositories
{
    public interface ISubCategoryRepository : IRepository<SubCategory>
    {
        SubCategory GetName(string Name);
    }
}
