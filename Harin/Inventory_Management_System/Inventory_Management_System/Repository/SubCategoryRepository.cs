using Inventory_Management_System.Models;
using Inventory_Management_System.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Repository
{
    public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
    {
        private new Inventory_Management_System_DbContext _context;

        public SubCategoryRepository(Inventory_Management_System_DbContext Context) : base(Context)
        {
            this._context = Context;
        }

        public SubCategory GetName(string Name)
        {
            return this._context.SubCategories.SingleOrDefault(pn => pn.SubCategoryName == Name);
        }
    }
}