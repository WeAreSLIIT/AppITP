using Inventory_Management_System.Repository;

namespace Inventory_Management_System.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Inventory_Management_System_DbContext _context;

        public IProductRepository Products { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public ISubCategoryRepository SubCategories { get; private set; }
        public ISectionRepository Sections { get; private set; }
        public IRackRepository Racks { get; private set; }

        public UnitOfWork()
        {
            this._context = new Inventory_Management_System_DbContext();

            Products = new ProductRepository(this._context);
            Categories = new CategoryRepository(this._context);
            SubCategories = new SubCategoryRepository(this._context);
            Sections = new SectionRepository(this._context);
            Racks = new RackRepository(this._context);
        }

        public int Complete()
        {
            return this._context.SaveChanges();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}