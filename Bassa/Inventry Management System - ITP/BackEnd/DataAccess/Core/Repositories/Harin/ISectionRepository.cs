using DataAccess.Core.Domain;

namespace DataAccess.Core.Repositories
{
    public interface ISectionRepository : IRepository<Section>
    {
        Section GetName(string Name);
    }
}
