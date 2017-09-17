using DataAccess.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Persistence.EntityConfigurations
{
    public class InvoiceEmployeeDiscountConfiguration : EntityTypeConfiguration<InvoiceEmployeeDiscount>
    {
        public InvoiceEmployeeDiscountConfiguration()
        {
            //Primary Key
            HasKey(ied => ied.InvoiceID).ToTable("InvoiceEmployeeDiscounts");
            //Ignore Attribute
            Ignore(ied => ied.DiscountMethod);
            //Foreign Keys
            HasRequired(ied => ied.PermittedEmployee).WithMany(e => e.DiscountedInvoices)
                .HasForeignKey(ied => ied.PermittedEmployeeID).WillCascadeOnDelete(false);
        }
    }
}
