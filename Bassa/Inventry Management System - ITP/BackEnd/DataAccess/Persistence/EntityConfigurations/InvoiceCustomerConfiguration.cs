using DataAccess.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Persistence.EntityConfigurations
{
    public class InvoiceCustomerConfiguration : EntityTypeConfiguration<InvoiceCustomer>
    {
        public InvoiceCustomerConfiguration()
        {
            //Primary Key
            HasKey(ic => ic.InvoiceID).ToTable("InvoiceCustomers");
            Property(ic => ic.InvoiceID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //Foreign Key to Priciple
            HasRequired(ic => ic.Invoice).WithOptional(i => i.InvoiceCustomer).WillCascadeOnDelete(true);
            HasRequired(ic => ic.PurchasedBy).WithMany(c => c.Invoices)
                    .HasForeignKey(ic => ic.CustomerID).WillCascadeOnDelete(true);
        }
    }
}
