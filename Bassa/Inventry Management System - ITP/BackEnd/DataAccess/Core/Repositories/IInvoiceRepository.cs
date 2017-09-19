using DataAccess.Core.Domain;

namespace DataAccess.Core.Repositories
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        string GetPublicID(long InvoiceID);
        long? GetInvoiceID(string PublicID);
        Invoice Get(string PublicID);
    }
}
