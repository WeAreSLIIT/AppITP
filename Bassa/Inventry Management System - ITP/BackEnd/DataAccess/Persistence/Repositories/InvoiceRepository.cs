using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;
using System.Data.Entity;

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
            return this._context.Invoices.SingleOrDefault(i => i.InvoicePublicID.ToLower().Equals(PublicID.ToLower()));
        }

        public long? GetInvoiceID(string PublicID)
        {
            long temp = this._context.Invoices.Where(i => i.InvoicePublicID == PublicID).Select(i => i.InvoiceID).SingleOrDefault();

            return (temp != 0) ? temp : (long?)null;
        }

        public long GetAllInvoicesCount()
        {
            return this._context.Invoices.Select(i => i.InvoiceID).Count();
        }

        public string GetPublicID(long InvoiceID)
        {
            return this._context.Invoices.Where(i => i.InvoiceID == InvoiceID).Select(i => i.InvoicePublicID).SingleOrDefault();
        }

        public Invoice GetInvoiceWithAllData(long InvoiceID)
        {
            return this._context.Invoices
                .Include(i => i.Counter)
                .Include(i => i.InvoiceCustomer)
                .Include(i => i.InvoiceDeal)
                .Include(i => i.InvoicePaymentMethods)
                .Include(i => i.InvoicePaymentMethods.Select(pm => pm.PaymentMethod))
                .Include(i => i.IssuedBy)
                .Include(i => i.InvoiceProducts)
                .Include(i => i.InvoiceProducts.Select(ip => ip.Product))
                .Where(i => i.InvoiceID == InvoiceID).SingleOrDefault();
        }

        public Invoice GetInvoiceWithAllData(string PublicID)
        {
            return this._context.Invoices
                .Include(i => i.Counter)
                .Include(i => i.InvoiceCustomer)
                .Include(i => i.InvoiceDeal)
                .Include(i => i.InvoicePaymentMethods)
                .Include(i => i.InvoicePaymentMethods.Select(pm => pm.PaymentMethod))
                .Include(i => i.IssuedBy)
                .Include(i => i.InvoiceProducts)
                .Include(i => i.InvoiceProducts.Select(ip => ip.Product))
                .Where(i => i.InvoicePublicID.ToLower().Equals(PublicID.ToLower())).SingleOrDefault();
        }

        public ICollection<Invoice> GetAllInvoicesWithAllData()
        {
            return this._context.Invoices
                .Include(i => i.Counter)
                .Include(i => i.InvoiceCustomer)
                .Include(i => i.InvoiceDeal)
                .Include(i => i.InvoicePaymentMethods)
                .Include(i => i.InvoicePaymentMethods.Select(pm => pm.PaymentMethod))
                .Include(i => i.IssuedBy)
                .Include(i => i.InvoiceProducts)
                .Include(i => i.InvoiceProducts.Select(ip => ip.Product))
                .ToList();
        }

        public Invoice GetInvoiceWithData(long InvoiceID)
        {
            return this._context.Invoices
                .Include(i => i.Counter)
                .Include(i => i.InvoiceCustomer)
                .Include(i => i.InvoiceDeal)
                .Include(i => i.InvoicePaymentMethods)
                .Include(i => i.InvoicePaymentMethods.Select(pm => pm.PaymentMethod))
                .Include(i => i.InvoiceProducts)
                .Include(i => i.InvoiceProducts.Select(ip => ip.Product))
                .Where(i => i.InvoiceID == InvoiceID).SingleOrDefault();
        }

        public Invoice GetInvoiceWithData(string PublicID)
        {
            return this._context.Invoices
                .Include(i => i.Counter)
                .Include(i => i.InvoiceCustomer)
                .Include(i => i.InvoiceDeal)
                .Include(i => i.InvoicePaymentMethods)
                .Include(i => i.InvoicePaymentMethods.Select(pm => pm.PaymentMethod))
                .Include(i => i.InvoiceProducts)
                .Include(i => i.InvoiceProducts.Select(ip => ip.Product))
                .Where(i => i.InvoicePublicID == PublicID).SingleOrDefault();
        }

        public ICollection<Invoice> GetAllInvoicesWithData()
        {
            return this._context.Invoices
                .Include(i => i.Counter)
                .Include(i => i.InvoiceCustomer)
                .Include(i => i.InvoiceDeal)
                .Include(i => i.InvoicePaymentMethods)
                .Include(i => i.InvoicePaymentMethods.Select(pm => pm.PaymentMethod))
                .Include(i => i.InvoiceProducts)
                .Include(i => i.InvoiceProducts.Select(ip => ip.Product))
                .ToList();
        }
    }
}