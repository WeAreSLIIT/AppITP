using Inventory_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
<<<<<<< HEAD
=======
        Category GetName(string Name);
>>>>>>> master
    }
}
