using Inventory_Mangement_System.Models;
using Inventory_Mangement_System.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Inventory_Mangement_System.DataAccess;

namespace Inventory_Mangement_System.IRepositories
{
    public class PreorderRepository : Repository<Preorder>, IPreorderRepository
    {
        public PreorderRepository(InventoryManagementSystemDbContext Context) : base(Context)
        {
        }
    }
}