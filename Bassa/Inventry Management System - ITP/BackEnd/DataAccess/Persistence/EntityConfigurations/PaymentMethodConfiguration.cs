using DataAccess.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Persistence.EntityConfigurations
{
    public class PaymentMethodConfiguration : EntityTypeConfiguration<PaymentMethod>
    {
        public PaymentMethodConfiguration()
        {
            //Primary Key
            HasKey(pm => pm.PaymentMethodID).ToTable("PaymentMethods");
            //Other Attributes
            Property(pm => pm.PaymentMethodName).IsRequired();
            Property(pm => pm.PaymentMethodName).HasMaxLength(100);
        }
    }
}
