using DataAccess.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.IRepositories
{
    public interface IStockRepository : IRepository<Stock>
    {
        //IList<Stock> GetAll(string ItemId);
    }
}
