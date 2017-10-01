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
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        public StockRepository(InventoryMgmtDbContext context) : base(context)
        {

            //public IList<Stock> GetAll(string ItemId)
            //{
            //    return Context.Set<Stock>().Take(ItemId).ToList();
            //}


        }

     
    }
}
