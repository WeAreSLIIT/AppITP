using DataAccess.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence
{
    public class InventoryMgmtDbContext : DbContext
    {
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Recount> Recounts { get; set; }
        public DbSet<ReturnStock> ReturnStocks { get; set; }
        public DbSet<TransInStock> TransInStocks { get; set; }
        public DbSet<TransOut> TransOuts { get; set; }
        public DbSet<Wastage> Wastages { get; set; }

        public InventoryMgmtDbContext()  : base ("name=InventoryMgmtDbContext") { }
    }
}
