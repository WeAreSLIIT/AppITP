using System;
using DataAccess.Core.Repositories;

namespace DataAccess.Core
{
    public interface IUnitOfWork : IDisposable
    {
        #region CSB's

        ITableVersionRepository TableVersions { get; }
        IInvoiceCustomerRepository InvoiceCustomers { get; }
        IInvoiceDealDiscountRepository InvoiceDealDiscounts { get; }
        IInvoiceDealRepository InvoiceDeals { get; }
        IInvoiceEmployeeDiscountRepository InvoiceEmployeeDiscounts { get; }
        IInvoiceProductRepository InvoiceProducts { get; }
        IInvoiceRepository Invoices { get; }
        IInvoicePaymentMethodRepository InvoicePaymentMethods { get; }
        IPaymentMethodRepository PaymentMethods { get; }
        ICounterRepository Counters { get; }

        #endregion

        #region Samith's

        IBranchRepository Branches { get; }
        IEmployeeRepository Employees { get; }

        #endregion

        #region Harin's

        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        ISubCategoryRepository SubCategories { get; }
        ISectionRepository Sections { get; }
        IRackRepository Racks { get; }

        #endregion

        #region Kavi's

        ICustomerRepository Customers { get; }
        ILoyaltyCardRepository LoyaltyProgram { get; }
        ICreditRepository Credits { get; }
        ILoyaltyProgramRepository LoyaltyPrograms { get; }
        IPreorderRepository Preorders { get; }
        ILoginRepository Logins { get; }

        #endregion

        #region Dileepa's
        //CSB Temporary
        IDiscountRepository Discounts { get; }

        IDiscountScheduleRepository DiscountSchedules { get; }
        IDiscountTypeRepository DiscountTypes { get; }
        IGiftVoucherTypeRepository GiftVoucherTypes { get; }
        IGiftVoucherIssueRepository GiftVoucherIssues { get; }
        IPromotionTypeRepository PromotionTypes { get; }
        IPromotionScheduleRepository PromotionSchedules { get; }

        #endregion

        #region Pathmika's

        IOrderProductRepository OrderProducts { get; }
        IOrderRepository Orders { get; }
        IOrderServiceRepository OrderServices { get; }
        ISupplierRepository Suppliers { get; }
        IServiceSupplierRepository ServiceSuppliers { get; }
        IProductSupplierRepository ProductSuppliers { get; }
        ISupplierPaymentRepository SupplierPayments { get; }

        #endregion

        #region Yashika's

        IItemRepository Items { get; }
        IRecountRepository Recounts { get; }
        IReturnRepository ReturnStocks { get; }
        IStockRepository Stocks { get; }
        ITransInRepository TransInStocks { get; }
        ITransOutRepository TransOuts { get; }
        IWastageRepository Wastages { get; }

        #endregion


        int Complete();
    }
}
