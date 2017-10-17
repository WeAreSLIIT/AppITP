using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class ServiceSupplierRepository : Repository<ServiceSupplier>, IServiceSupplierRepository
    {
        public ServiceSupplierRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
        }
    }
}
