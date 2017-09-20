using System.Data.Entity;
using DataAccess.Core.Domain;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Persistence.EntityConfigurations;

namespace DataAccess.Persistence
{
    public class InventryMangementSystemDbContext : DbContext
    {
        public DbSet<InvoiceControlApp> InvoiceControlApps { get; set; }

        public DbSet<Customer> Courses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Product> Products { get; set; }

        #region DbSets of Invoice Related Tables

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceCustomer> InvoiceCustomer { get; set; }
        public DbSet<InvoiceEmployeeDiscount> InvoiceDiscounts { get; set; }
        public DbSet<InvoiceProduct> InvoiceProducts { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        #endregion

        public InventryMangementSystemDbContext() : base("name=InventryMangementSystemDbContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region InvoiceControlApps Table

            //Primary Key
            modelBuilder.Entity<InvoiceControlApp>().HasKey(ica => ica.ID).ToTable("InvoiceControlApps");
            //Other Attributes
            modelBuilder.Entity<InvoiceControlApp>().Property(ica => ica.Username).IsRequired();
            modelBuilder.Entity<InvoiceControlApp>().Property(ica => ica.Username).HasMaxLength(20);
            modelBuilder.Entity<InvoiceControlApp>().Property(ica => ica.Username)
                    .HasColumnAnnotation("InvoiceControlAppUsername", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));

            #endregion

            #region Invoices Table

            //Primary Key
            modelBuilder.Entity<Invoice>().HasKey(i => i.InvoiceID).ToTable("Invoices");
            //Unique key
<<<<<<< HEAD
            modelBuilder.Entity<Invoice>().Property(i => i.InvoicPublicID).IsRequired();
            modelBuilder.Entity<Invoice>().Property(i => i.InvoicPublicID).HasMaxLength(20);
            modelBuilder.Entity<Invoice>().Property(i => i.InvoicPublicID)
=======
            modelBuilder.Entity<Invoice>().Property(i => i.InvoicePublicID).IsRequired();
            modelBuilder.Entity<Invoice>().Property(i => i.InvoicePublicID).HasMaxLength(20);
            modelBuilder.Entity<Invoice>().Property(i => i.InvoicePublicID)
>>>>>>> Bassa
                    .HasColumnAnnotation("InvoicePublicID", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
            //Foreign Key
            modelBuilder.Entity<Invoice>().HasRequired(i => i.IssuedBy).WithMany(e => e.IssuedInvoices)
                .HasForeignKey(i => i.IssuedByID).WillCascadeOnDelete(false);
            modelBuilder.Entity<Invoice>().HasRequired(i => i.InvoiceControlApp).WithMany(ica => ica.Invoices)
                .HasForeignKey(i => i.InvoiceControlAppID).WillCascadeOnDelete(false);
            //Optional InvoiceCustomer attribute
            //HasOptional(op => op.InvoiceCustomer).WithOptionalPrincipal(p => p.Invoice);

            #endregion

            #region InvoiceCustomers Table

            //Primary Key
            modelBuilder.Entity<InvoiceCustomer>().HasKey(ic => ic.InvoiceID).ToTable("InvoiceCustomers");
            modelBuilder.Entity<InvoiceCustomer>().Property(ic => ic.InvoiceID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //Foreign Key to Priciple
            modelBuilder.Entity<InvoiceCustomer>().HasRequired(ic => ic.Invoice).WithOptional(i => i.InvoiceCustomer).WillCascadeOnDelete(true);
            modelBuilder.Entity<InvoiceCustomer>().HasRequired(ic => ic.PurchasedBy).WithMany(c => c.Invoices)
                    .HasForeignKey(ic => ic.CustomerID).WillCascadeOnDelete(false);

            #endregion

            #region InvoiceDeals Table

            //Primary Key
            modelBuilder.Entity<InvoiceDeal>().HasKey(id => id.InvoiceID).ToTable("InvoiceDeals");
            modelBuilder.Entity<InvoiceDeal>().Property(id => id.InvoiceID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //Foreign Key
            modelBuilder.Entity<InvoiceDeal>().HasRequired(id => id.Invoice).WithOptional(i => i.InvoiceDeal).WillCascadeOnDelete(false);
            modelBuilder.Entity<InvoiceDeal>().HasRequired(id => id.InvoiceDealDiscount).WithMany(idd => idd.AffectedInvoices)
                .HasForeignKey(id => id.InvoiceDealDiscountID).WillCascadeOnDelete(false);

            #endregion

            #region InvoiceDealDiscounts Table

            //Primary Key
            modelBuilder.Entity<InvoiceDealDiscount>().HasKey(idd => idd.InvoiceDealDiscountID).ToTable("InvoiceDealDiscount");
            //Ignore Attribute
            modelBuilder.Entity<InvoiceDealDiscount>().Ignore(idd => idd.DiscountMethod);
            //Foreign Key
            modelBuilder.Entity<InvoiceDealDiscount>().HasRequired(idd => idd.GivenEmployee).WithMany(e => e.InvoiceDealDiscount)
                .HasForeignKey(idd => idd.GivenEmployeeID).WillCascadeOnDelete(true);

            #endregion

            #region InvoiceEmployeeDiscounts Table

            //Primary Key
            modelBuilder.Entity<InvoiceEmployeeDiscount>().HasKey(ied => ied.InvoiceID).ToTable("InvoiceEmployeeDiscounts");
            //Ignore Attribute
            modelBuilder.Entity<InvoiceEmployeeDiscount>().Ignore(ied => ied.DiscountMethod);
            //Foreign Keys
            modelBuilder.Entity<InvoiceEmployeeDiscount>().HasRequired(ied => ied.PermittedEmployee).WithMany(e => e.DiscountedInvoices)
                .HasForeignKey(ied => ied.PermittedEmployeeID).WillCascadeOnDelete(false);

            #endregion

            #region InvoiceProducts Table

            //Primary Key
            modelBuilder.Entity<InvoiceProduct>().HasKey(ip => new { ip.InvoiceID, ip.ProductID }).ToTable("InvoiceProduct");
            //Foreign Key
            modelBuilder.Entity<InvoiceProduct>().HasRequired(ip => ip.Product).WithMany(p => p.InvoiceProducts)
                .HasForeignKey(ip => ip.ProductID).WillCascadeOnDelete(false);
            modelBuilder.Entity<InvoiceProduct>().HasRequired(ip => ip.Invoice).WithMany(i => i.InvoiceProducts)
                .HasForeignKey(ip => ip.InvoiceID).WillCascadeOnDelete(false);

            #endregion

            #region PaymentMethods Table

            //Primary Key
            modelBuilder.Entity<PaymentMethod>().HasKey(pm => pm.PaymentMethodID).ToTable("PaymentMethods");
            //Other Attributes
            modelBuilder.Entity<PaymentMethod>().Property(pm => pm.PaymentMethodName).IsRequired();
            modelBuilder.Entity<PaymentMethod>().Property(pm => pm.PaymentMethodName).HasMaxLength(100);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
