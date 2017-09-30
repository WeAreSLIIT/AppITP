using DataAccess.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataAccess.Core.IRepositories;

namespace DataAccess.Persistence.Repositories
{
    class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(InventoryMgmtDbContext context) : base(context)
        {
        }
    }
}
