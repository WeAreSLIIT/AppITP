using System;
using System.Linq;
using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    public class CounterRepository : Repository<Counter>, ICounterRepository
    {
        private new InventryMangementSystemDbContext _context;

        public CounterRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
            this._context = Context;
        }

        public long? GetCounterCountInBranch(long BranchID)
        {
            if (this._context.Branches.SingleOrDefault(b => b.BranchID == BranchID) == null)
                return null;

            return (long)this._context.Counters.Where(c => c.BranchID == BranchID).Count();
        }

        public long? GetCounterID(long BranchID, long CounterNo)
        {
            Counter Counter = this._context.Counters.SingleOrDefault(c => c.BranchID == BranchID && c.BranchCounterNo == CounterNo);

            if (Counter == null)
                return null;

            return Counter.CounterID;
        }
    }
}
