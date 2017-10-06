using DataAccess.Core.Domain;
using DataAccess.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence.Repositories
{
    class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(InventryMangementSystemDbContext context) : base(context)
        {
        }
    }
}
