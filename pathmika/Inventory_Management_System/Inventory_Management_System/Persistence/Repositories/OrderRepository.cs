using Inventory_Management_System.IRepositories;
using Inventory_Management_System.Models;



namespace Inventory_Management_System.Persistence.Repositories
{
    public class OrderRepository : Repository<Order>,IOrderRepository
    {
        public OrderRepository(Inventory_Management_System_DbContext Context) : base(Context)
        {

        }
    }
}