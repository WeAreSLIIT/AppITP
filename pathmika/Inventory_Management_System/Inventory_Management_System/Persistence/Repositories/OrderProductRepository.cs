using Inventory_Management_System.IRepositories;
using Inventory_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_System.Persistence.Repositories
{
    public class OrderProductRepository : Repository<OrderProduct>,IOrderProductRepository
    {
        public OrderProductRepository(Inventory_Management_System_DbContext Context) : base(Context)
        {
        }
    }
}