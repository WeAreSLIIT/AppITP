using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

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
            this._context.InvoicePaymentMethod
        }
    }
}
