using System.Linq;
using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    class InvoiceControlAppRepository : Repository<InvoiceControlApp>, IInvoiceControlAppRepository
    {
        private new InventryMangementSystemDbContext _context;

        public InvoiceControlAppRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
            this._context = Context;
        }

        public bool ValidateUsername(string Username)
        {
            string Validate = this._context.InvoiceControlApps.Where(ica => ica.Username == Username).Select(ica => ica.Username).SingleOrDefault();

            return !(Validate == null || Validate.Equals(""));
        }
    }
}
