using Inventory_Management_System.Models;
using Inventory_Management_System.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Repository
{
    public class RackRepository : Repository<Rack>, IRackRepository
    {
<<<<<<< HEAD
        public RackRepository(Inventory_Management_System_DbContext Context) : base(Context)
        {
=======
        private new Inventory_Management_System_DbContext _context;

        public RackRepository(Inventory_Management_System_DbContext Context) : base(Context)
        {
            this._context = Context;
        }

        public Rack GetName(string Name)
        {
            return this._context.Racks.SingleOrDefault(pn => pn.RackName == Name);
>>>>>>> master
        }
    }
}