using System.Linq;
using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;

namespace DataAccess.Persistence.Repositories
{
    //class BranchRepository : Repository<Branch>, IBranchRepository
    //{
    //    private new InventryMangementSystemDbContext _context;

    //    public BranchRepository(InventryMangementSystemDbContext Context) : base(Context)
    //    {
    //        this._context = Context;
    //    }
    //}

    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        public BranchRepository(InventryMangementSystemDbContext Context) : base(Context)
        {
        }
    }
}
