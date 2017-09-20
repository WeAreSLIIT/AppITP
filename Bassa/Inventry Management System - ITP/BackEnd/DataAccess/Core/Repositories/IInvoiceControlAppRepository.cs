using DataAccess.Core.Domain;

namespace DataAccess.Core.Repositories
{
    public interface IInvoiceControlAppRepository : IRepository<InvoiceControlApp>
    {
        bool ValidateUsername(string Username);
    }
}
