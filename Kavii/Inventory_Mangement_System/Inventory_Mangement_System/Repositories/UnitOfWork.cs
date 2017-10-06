using Inventory_Mangement_System.Controllers;
using Inventory_Mangement_System.DataAccess;
using Inventory_Mangement_System.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Mangement_System.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventoryManagementSystemDbContext _context;

        public ICustomerRepoistory Customers { get; private set; }
        public ICreditRepository Credits { get; private set; }
        public ILoyaltyCardRepository LoyaltyProgram { get; private set; }
        public ILoyaltyProgramRepository LoyaltyPrograms { get; private set; }
        public IPreorderRepository Preorders { get; private set; }
       // public ICreditCustomerRepository CreditCustomers { get; private set; }
       // public IPreorderCustomerRepository PreorderCustomers { get; private set; }
        public ILoginRepository Logins { get; private set; }
      //  public IPersonRepository Persons { get; private set; }

        public UnitOfWork()
        {
            this._context = new InventoryManagementSystemDbContext();

            Customers = new CustomerRepoistory(this._context);
            Credits = new CreditRepository(this._context);
            LoyaltyProgram = new LoyaltyCardRepository(this._context);
            LoyaltyPrograms = new LoyaltyProgramRepository(this._context);
            Preorders = new PreorderRepository(this._context);
           //CreditCustomers = new CreditCustomerRepository(this._context);
           // PreorderCustomers = new PreorderCustomerRepository(this._context);
            Logins = new LoginRepository(this._context);
        //    Persons = new PersonRepository(this._context);
        }

        public int Complete()
        {

            return this._context.SaveChanges();
        }

        public void Dispose() {

            this._context.Dispose();
        }


    }
}