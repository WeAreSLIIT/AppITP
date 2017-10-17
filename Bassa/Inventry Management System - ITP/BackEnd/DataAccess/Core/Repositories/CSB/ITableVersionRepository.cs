using DataAccess.Core.Domain;

namespace DataAccess.Core.Repositories
{
    public interface ITableVersionRepository : IRepository<TableVersion>
    {
        void DatabaseTableUpdated(DatabaseTable Table, long UpdatedTime);
    }
}
