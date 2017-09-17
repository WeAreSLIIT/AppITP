using DataAccess.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Persistence.EntityConfigurations
{
    public class InvoiceDealConfiguration : EntityTypeConfiguration<InvoiceDeal>
    {
        public InvoiceDealConfiguration()
        {
            //Primary Key
            HasKey(id => id.InvoiceID).ToTable("InvoiceDeals");
            Property(id => id.InvoiceID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //Foreign Key
            HasRequired(id => id.Invoice).WithOptional(i => i.InvoiceDeal).WillCascadeOnDelete(false);
            HasRequired(id => id.InvoiceDealDiscount).WithMany(idd => idd.AffectedInvoices)
                .HasForeignKey(id => id.InvoiceDealDiscountID).WillCascadeOnDelete(false);
        }
    }
}
