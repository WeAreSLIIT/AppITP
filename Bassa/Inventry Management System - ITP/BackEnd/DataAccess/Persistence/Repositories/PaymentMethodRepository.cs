using System;
using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;
using System.Linq;

namespace DataAccess.Persistence.Repositories
{
    public class PaymentMethodRepository : Repository<PaymentMethod>, IPaymentMethodRepository
    {
        private new InventryMangementSystemDbContext _context;

        public PaymentMethodRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
            this._context = Context;
        }

        public PaymentMethod Get(string PaymentName)
        {
            return this._context.PaymentMethods.SingleOrDefault(pm => pm.PaymentMethodName.ToLower().Equals(PaymentName.ToLower()));
        }
    }
}
