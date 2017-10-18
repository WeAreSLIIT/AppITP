using System.Linq;
using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class TableVersionRepository : Repository<TableVersion>, ITableVersionRepository
    {
        private new InventryMangementSystemDbContext _context;

        public TableVersionRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
            this._context = Context;
        }

        public void DatabaseTableUpdated(DatabaseTable Table, long UpdatedTime)
        {
            try
            {
                TableVersion TableVersion = this._context.TableVersions.FirstOrDefault(tv => tv.Table == Table);
                TableVersion.Time = UpdatedTime;
                this._context.SaveChanges();
            }
            catch { }
        }
    }
}
