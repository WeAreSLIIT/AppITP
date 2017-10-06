using Inventory_Mangement_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Inventory_Mangement_System.DataAccess;

namespace Inventory_Mangement_System.IRepositories
{
    public class CreditRepository : Repository<Credit>, ICreditRepository
    {
        private new InventoryManagementSystemDbContext _context;
        public CreditRepository(InventoryManagementSystemDbContext Context) : base(Context)
        {
            this._context = Context;
        }
        
    }
}