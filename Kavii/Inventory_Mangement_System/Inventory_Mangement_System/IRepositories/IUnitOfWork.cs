using Inventory_Mangement_System.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Mangement_System.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepoistory Customers { get; }
        ILoyaltyCardRepository LoyaltyProgram { get; }
        ICreditRepository Credits { get; }
        ILoyaltyProgramRepository LoyaltyPrograms { get; }
        IPreorderRepository Preorders { get; }
        //ICreditCustomerRepository CreditCustomers { get; }
        //IPreorderCustomerRepository PreorderCustomers { get; }
        ILoginRepository Logins { get; }
        //IPersonRepository Persons { get; }






        int Complete();
    }
}