using DataAccess.Core.Domain;
using DataAccess.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence.Repositories
{
    public class ReturnRepository : Repository<ReturnStock>, IReturnRepository
    {
        public ReturnRepository(InventoryMgmtDbContext context) : base(context)
        {
        }
    }
}
