using Inventory_Management_System.Models;
using Inventory_Management_System.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(Inventory_Management_System_DbContext Context) : base(Context)
        {
        }
    }
}