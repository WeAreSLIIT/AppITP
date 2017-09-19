using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;
using System;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class InvoiceCustomerRepository : Repository<InvoiceCustomer>, IInvoiceCustomerRepository
    {
        protected readonly new InventryMangementSystemDbContext _context;

        public InvoiceCustomerRepository(InventryMangementSystemDbContext Context):base(Context)
        {
            this._context = Context;
        }

        /// <summary>
        /// This Method is deprecated in InvoiceCustomerRepository
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>This will return a Not Implemented Exception</returns>
        public new InvoiceCustomer Get(long ID)
        {
            throw new NotImplementedException();
        }

        public InvoiceCustomer Get(long InvoiceID, long CustomerID)
        {
            return this._context.InvoiceCustomer.SingleOrDefault(ic => ic.InvoiceID == InvoiceID && ic.CustomerID == CustomerID);
        }

        public InvoiceCustomer Get(string PublicID, long CustomerID)
        {
            return this._context.InvoiceCustomer.SingleOrDefault(ic => ic.Invoice.PublicID == PublicID && ic.CustomerID == CustomerID);
        }
    }
}
