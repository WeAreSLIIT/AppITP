using DataAccess.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Persistence.EntityConfigurations
{
    public class InvoiceDealDiscountConfiguration : EntityTypeConfiguration<InvoiceDealDiscount>
    {
        public InvoiceDealDiscountConfiguration()
        {
            //Primary Key
            HasKey(idd => idd.InvoiceDealDiscountID).ToTable("InvoiceDealDiscount");
            //Ignore Attribute
            Ignore(idd => idd.DiscountMethod);
            //Foreign Key
            HasRequired(idd => idd.GivenEmployee).WithMany(e => e.InvoiceDealDiscount)
                .HasForeignKey(idd => idd.GivenEmployeeID).WillCascadeOnDelete(true);
        }
    }
}
