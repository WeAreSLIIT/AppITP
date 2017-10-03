using Inventory_Management_System.Models;
using Inventory_Management_System.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Repository
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        private new Inventory_Management_System_DbContext _context;

        public SectionRepository(Inventory_Management_System_DbContext Context) : base(Context)
        {
            this._context = Context;
        }

        public Section GetName(string Name)
        {
            return this._context.Sections.SingleOrDefault(pn => pn.SectionName == Name);
        }
    }
}