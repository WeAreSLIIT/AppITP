using Inventory_Management_System.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.Persistence
{
    interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        ISubCategoryRepository SubCategories { get; }
        ISectionRepository Sections { get; }
        IRackRepository Racks { get; }

        int Complete();
    }
}
