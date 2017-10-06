using DataAccess.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IItemRepository Item { get; }
        IRecountRepository Recount { get; }
        IReturnRepository Return { get; }
        IStockRepository Stock { get; }
        ITransInRepository TransInStock { get; }
        ITransOutRepository TransOut { get; }
        IWastageRepository Wastage { get; }

        int Complete();
    }
}
