using DataAccess.Core.Domain;
using System.Collections.Generic;

namespace DataAccess.Core.Repositories
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        Invoice GetInvoiceWithData(long InvoiceID);
        Invoice GetInvoiceWithData(string InvoiceID);
        ICollection<Invoice> GetAllInvoicesWithData();
        string GetPublicID(long InvoiceID);
        long? GetInvoiceID(string PublicID);
        long GetAllInvoicesCount();
        Invoice Get(string PublicID);
    }
}
