using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory_Management_System.Models;
using Inventory_Management_System.IRepositories;
using System.Data.Entity;

namespace Inventory_Management_System.Persistence.Repositories
{
    public class ServiceSupplierRepository : Repository<ServiceSupplier>, IServiceSupplierRepository
    {
        public ServiceSupplierRepository(DbContext Context) : base(Context)
        {
        }
    }
}