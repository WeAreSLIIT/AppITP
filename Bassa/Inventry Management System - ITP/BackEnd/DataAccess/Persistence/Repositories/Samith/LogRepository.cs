using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class LogRepository : Repository<Log>, ILogRepository
    {
        public LogRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
        }
    }
}
