using DataAccess.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Persistence.EntityConfigurations
{
    public class InvoiceConfiguration : EntityTypeConfiguration<Invoice>
    {
        public InvoiceConfiguration()
        {
            //Primary Key
            HasKey(i => i.InvoiceID).ToTable("Invoices");
            //Unique key
            Property(i => i.PublicID).IsRequired();
            Property(i => i.PublicID).HasMaxLength(20);
            Property(i => i.PublicID)
                    .HasColumnAnnotation("InvoicePublicID", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
            //Foreign Key
            HasRequired(i => i.IssuedBy).WithMany(e => e.IssuedInvoices)
                .HasForeignKey(i => i.IssuedByID).WillCascadeOnDelete(false);
            //Optional InvoiceCustomer attribute
            //HasOptional(op => op.InvoiceCustomer).WithOptionalPrincipal(p => p.Invoice);
        }
    }
}
