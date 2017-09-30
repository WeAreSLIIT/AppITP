using DataAccess.Core;
using DataAccess.Core.IRepositories;
using DataAccess.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventoryMgmtDbContext _context;

        public IItemRepository Items { get; private set; }
        public IRecountRepository Recounts { get; private set; }
        public IReturnRepository ReturnStocks { get; private set; }
        public IStockRepository Stocks { get; private set; }
        public ITransInRepository TransInStocks { get; private set; }
        public ITransOutRepository TransOuts { get; private set; }
        public IWastageRepository Wastages { get; private set; }

        public UnitOfWork()
        {
            this._context = new InventoryMgmtDbContext();
            Items = new ItemRepository(this._context);
            Recounts = new RecountRepository(this._context);
            ReturnStocks = new ReturnRepository(this._context);
            Stocks = new StockRepository(this._context);
            TransInStocks = new TransInRepository(this._context);
            TransOuts = new TransOutRepository(this._context);
            Wastages = new WastageRepository(this._context);
        }

        public int Complete()
        {
            return this._context.SaveChanges();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }

        //public void SaveChanges()
        //{
        //    this._context.SaveChanges();
        //}
    }
}
