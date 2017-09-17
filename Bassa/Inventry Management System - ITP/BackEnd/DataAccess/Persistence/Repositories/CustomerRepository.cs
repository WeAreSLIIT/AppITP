using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
        }
    }
}
