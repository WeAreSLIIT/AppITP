using Inventory_Mangement_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Inventory_Mangement_System.Controllers;
using Inventory_Mangement_System.DataAccess;

namespace Inventory_Mangement_System.IRepositories
{
    public class CustomerRepoistory : Repository<Customer>, ICustomerRepoistory
    {
        private new InventoryManagementSystemDbContext  _context;

        public CustomerRepoistory(InventoryManagementSystemDbContext Context) : base(Context)
        {
            this._context = Context;
        }

        public Customer Get(string ID)
        {
            return this._context.Customers.SingleOrDefault(ci => ci.CustomerPublicID == ID);
        }

        public void UpdatePassword(string CurrentPassword) {
            Customer password = _context.Customers.FirstOrDefault(pw => pw.Password == CurrentPassword);
            password.Password = CurrentPassword;

            _context.SaveChanges();
            
        }
    }
}