using DataAccess.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Persistence.EntityConfigurations
{
    public class InvoiceProductConfiguration : EntityTypeConfiguration<InvoiceProduct>
    {
        public InvoiceProductConfiguration()
        {
            //Primary Key
            HasKey(ip => new { ip.InvoiceID, ip.ProductID }).ToTable("InvoiceProduct");
        }
    }
}
