using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class InvoicePaymentMethodRepository : Repository<InvoicePaymentMethod>, IInvoicePaymentMethodRepository
    {
        private new InventryMangementSystemDbContext _context;

        public InvoicePaymentMethodRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
            this._context = Context;
        }

        public new InvoicePaymentMethod Get(long Id)
        {
            return null;
        }

        public InvoicePaymentMethod Get(long InvoiceID, long PaymentMethodID)
        {
            return this._context.InvoicePaymentMethods.Where(ipm => ipm.InvoiceID == InvoiceID && ipm.PaymentMethodID == PaymentMethodID).SingleOrDefault();
        }
    }
}
