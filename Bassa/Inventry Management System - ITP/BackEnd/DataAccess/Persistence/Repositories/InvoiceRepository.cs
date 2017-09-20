using System;
using System.Linq;
using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        private readonly new InventryMangementSystemDbContext _context;

        public InvoiceRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
            this._context = Context;
        }

        public Invoice Get(string PublicID)
        {
<<<<<<< HEAD
            return this._context.Invoices.SingleOrDefault(i => i.InvoicPublicID == PublicID);
=======
            return this._context.Invoices.SingleOrDefault(i => i.InvoicePublicID == PublicID);
>>>>>>> Bassa
        }

        public long? GetInvoiceID(string PublicID)
        {
<<<<<<< HEAD
            long temp = this._context.Invoices.Where(i => i.InvoicPublicID == PublicID).Select(i => i.InvoiceID).SingleOrDefault();
=======
            long temp = this._context.Invoices.Where(i => i.InvoicePublicID == PublicID).Select(i => i.InvoiceID).SingleOrDefault();
>>>>>>> Bassa

            return (temp != 0) ? temp : (long?)null;
        }

        public string GetPublicID(long InvoiceID)
        {
<<<<<<< HEAD
            return this._context.Invoices.Where(i => i.InvoiceID == InvoiceID).Select(i => i.InvoicPublicID).SingleOrDefault();
=======
            return this._context.Invoices.Where(i => i.InvoiceID == InvoiceID).Select(i => i.InvoicePublicID).SingleOrDefault();
>>>>>>> Bassa
        }
    }
}
