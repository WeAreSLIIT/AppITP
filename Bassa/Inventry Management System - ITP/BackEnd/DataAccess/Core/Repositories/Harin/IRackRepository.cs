using DataAccess.Core.Domain;

namespace DataAccess.Core.Repositories
{
    public interface IRackRepository : IRepository<Rack>
    {
        Rack GetName(string Name);
    }
}
