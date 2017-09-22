using System.Data.Entity;
using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class CounterRepository : Repository<Counter>, ICounterRepository
    {
        public CounterRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
        }
    }
}
