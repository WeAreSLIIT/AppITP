using Inventory_Management_System.Models;
using Inventory_Management_System.IRepositories;

namespace Inventory_Management_System.Persistence.Repositories
{
    public class SupplierPaymentRepository : Repository<SupplierPayment>,ISupplierPaymentRepository
    {
        public SupplierPaymentRepository(Inventory_Management_System_DbContext Context) : base(Context)
        {
        }
    }
}