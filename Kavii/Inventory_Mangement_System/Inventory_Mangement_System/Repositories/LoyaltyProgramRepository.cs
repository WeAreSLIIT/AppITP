using Inventory_Mangement_System.DataAccess;
using Inventory_Mangement_System.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Inventory_Mangement_System.IRepositories
{
    public class LoyaltyProgramRepository : Repository<LoyaltyProgram>, ILoyaltyProgramRepository
    {
        public LoyaltyProgramRepository(InventoryManagementSystemDbContext Context) : base(Context)
        {
        }
    }
}