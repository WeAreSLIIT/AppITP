using Inventory_Mangement_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Mangement_System.IRepositories
{
    public interface ICustomerRepoistory : IRepository<Customer>
    {
        Customer Get(string ID);

        void UpdatePassword(string CurrentPassword);

       
        

    }
}
