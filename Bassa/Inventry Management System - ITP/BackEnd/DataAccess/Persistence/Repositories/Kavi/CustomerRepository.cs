using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private new InventryMangementSystemDbContext _context;

        public CustomerRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
            this._context = Context;
        }

        public Customer Get(string ID)
        {
            return this._context.Customers.SingleOrDefault(ci => ci.CustomerPublicID == ID);
        }

        public void UpdatePassword(string CurrentPassword)
        {
            Customer password = _context.Customers.FirstOrDefault(pw => pw.Password == CurrentPassword);
            password.Password = CurrentPassword;

            _context.SaveChanges();
        }
    }
}
