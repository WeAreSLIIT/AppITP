using Inventory_Mangement_System.IRepositories;
using Inventory_Mangement_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Inventory_Mangement_System.DataAccess;

namespace Inventory_Mangement_System.Repositories
{
    public class LoginRepository : Repository<Login>, ILoginRepository
    {

        public LoginRepository(InventoryManagementSystemDbContext Context) : base(Context)
        {
        }
    }
}