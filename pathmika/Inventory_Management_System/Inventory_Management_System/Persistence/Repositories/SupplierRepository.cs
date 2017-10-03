using Inventory_Management_System.IRepositories;
using Inventory_Management_System.Models;


namespace Inventory_Management_System.Persistence.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(Inventory_Management_System_DbContext Context) : base(Context)
        {
        }
    }
}