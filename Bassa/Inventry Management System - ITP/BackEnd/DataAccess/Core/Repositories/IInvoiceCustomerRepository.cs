using DataAccess.Core.Domain;

namespace DataAccess.Core.Repositories
{
    public interface IInvoiceCustomerRepository : IRepository<InvoiceCustomer>
    {
        InvoiceCustomer Get(long InvoiceID, long CustomerID);
        InvoiceCustomer Get(string PublicID, long CustomerID);
    }
}
