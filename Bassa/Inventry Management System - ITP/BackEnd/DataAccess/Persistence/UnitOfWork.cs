using System;
using DataAccess.Core;
using DataAccess.Core.Repositories;
using DataAccess.Persistence.Repositories;

namespace DataAccess.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventryMangementSystemDbContext _context;

        #region CSB's
        
        public ICounterRepository Counters { get; private set; }
        public IInvoiceCustomerRepository InvoiceCustomers { get; private set; }
        public IInvoiceDealDiscountRepository InvoiceDealDiscounts { get; private set; }
        public IInvoiceDealRepository InvoiceDeals { get; private set; }
        public IInvoiceEmployeeDiscountRepository InvoiceEmployeeDiscounts { get; private set; }
        public IInvoiceProductRepository InvoiceProducts { get; private set; }
        public IInvoiceRepository Invoices { get; private set; }
        public IPaymentMethodRepository PaymentMethods { get; private set; }
        public IInvoicePaymentMethodRepository InvoicePaymentMethods { get; private set; }

        #endregion

        #region Samith's

        public IBranchRepository Branches { get; private set; }
        public IEmployeeRepository Employees { get; private set; }


        #endregion

        #region Dileepa's

        //CSB Temporary
        public IDiscountRepository Discounts { get; private set; }

        public IDiscountScheduleRepository DiscountSchedules { get; private set; }
        public IDiscountTypeRepository DiscountTypes { get; private set; }
        public IGiftVoucherTypeRepository GiftVoucherTypes { get; private set; }
        public IGiftVoucherIssueRepository GiftVoucherIssues { get; private set; }
        public IPromotionTypeRepository PromotionTypes { get; private set; }
        public IPromotionScheduleRepository PromotionSchedules { get; private set; }

        #endregion

        #region Harin's

        public IProductRepository Products { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public ISubCategoryRepository SubCategories { get; private set; }
        public ISectionRepository Sections { get; private set; }
        public IRackRepository Racks { get; private set; }

        #endregion

        #region Kavi's

        public ICustomerRepository Customers { get; private set; }
        public ICreditRepository Credits { get; private set; }
        public ILoyaltyCardRepository LoyaltyProgram { get; private set; }
        public ILoyaltyProgramRepository LoyaltyPrograms { get; private set; }
        public IPreorderRepository Preorders { get; private set; }
        public ILoginRepository Logins { get; private set; }

        #endregion

        #region Pathmika's

        public IOrderRepository Orders { get; private set; }
        public IOrderServiceRepository OrderServices { get; private set; }
        public IOrderProductRepository OrderProducts { get; private set; }
        public ISupplierRepository Suppliers { get; private set; }
        public IProductSupplierRepository ProductSuppliers { get; private set; }
        public IServiceSupplierRepository ServiceSuppliers { get; private set; }
        public ISupplierPaymentRepository SupplierPayments { get; private set; }

        #endregion

        #region Yashika's

        public IItemRepository Items { get; private set; }
        public IRecountRepository Recounts { get; private set; }
        public IReturnRepository ReturnStocks { get; private set; }
        public IStockRepository Stocks { get; private set; }
        public ITransInRepository TransInStocks { get; private set; }
        public ITransOutRepository TransOuts { get; private set; }
        public IWastageRepository Wastages { get; private set; }

        #endregion


        //public UnitOfWork(InventryMangementSystemDbContext Context)
        public UnitOfWork()
        {
            this._context = new InventryMangementSystemDbContext();

            Employees = new EmployeeRepository(this._context);
            Branches = new BranchRepository(this._context);

            //Deleepa
            DiscountSchedules = new DiscountScheduleRepository(this._context);
            DiscountTypes = new DiscountTypeRepository(this._context);
            GiftVoucherTypes = new GiftVoucherTypeRepository(this._context);
            GiftVoucherIssues = new GiftVoucherIssueRepository(this._context);
            PromotionTypes = new PromotionTypeRepository(this._context);
            PromotionSchedules = new PromotionScheduleRepository(this._context);

            //CSB Temporary
            Discounts = new DiscountRepository(this._context);

            //CSB
            Counters = new CounterRepository(this._context);
            InvoiceCustomers = new InvoiceCustomerRepository(this._context);
            InvoiceDealDiscounts = new InvoiceDealDiscountRepository(this._context);
            InvoiceDeals = new InvoiceDealRepository(this._context);
            InvoiceEmployeeDiscounts = new InvoiceEmployeeDiscountRepository(this._context);
            InvoiceProducts = new InvoiceProductRepository(this._context);
            Invoices = new InvoiceRepository(this._context);
            PaymentMethods = new PaymentMethodRepository(this._context);
            InvoicePaymentMethods = new InvoicePaymentMethodRepository(this._context);

            //Harin
            Products = new ProductRepository(this._context);
            Categories = new CategoryRepository(this._context);
            SubCategories = new SubCategoryRepository(this._context);
            Sections = new SectionRepository(this._context);
            Racks = new RackRepository(this._context);
            
            //Kavi
            Customers = new CustomerRepository(this._context);
            Credits = new CreditRepository(this._context);
            LoyaltyProgram = new LoyaltyCardRepository(this._context);
            LoyaltyPrograms = new LoyaltyProgramRepository(this._context);
            Preorders = new PreorderRepository(this._context);
            Logins = new LoginRepository(this._context);

            //Pathmika
            Orders = new OrderRepository(this._context);
            OrderServices = new OrderServiceRepository(this._context);
            OrderProducts = new OrderProductRepository(this._context);
            Suppliers = new SupplierRepository(this._context);
            ProductSuppliers = new ProductSupplierRepository(this._context);
            ServiceSuppliers = new ServiceSupplierRepository(this._context);
            SupplierPayments = new SupplierPaymentRepository(this._context);

            //Yashika
            Items = new ItemRepository(this._context);
            Recounts = new RecountRepository(this._context);
            ReturnStocks = new ReturnRepository(this._context);
            Stocks = new StockRepository(this._context);
            TransInStocks = new TransInRepository(this._context);
            TransOuts = new TransOutRepository(this._context);
            Wastages = new WastageRepository(this._context);
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
