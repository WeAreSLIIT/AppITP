using DataAccess.Core.Domain;

namespace DataAccess.Core.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer Get(string ID);
        void UpdatePassword(string CurrentPassword);
    }
}
