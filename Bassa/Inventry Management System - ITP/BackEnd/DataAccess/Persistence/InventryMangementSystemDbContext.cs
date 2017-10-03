﻿using System.Data.Entity;
using DataAccess.Core.Domain;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Persistence
{
    public class InventryMangementSystemDbContext : DbContext
    {
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Counter> Counters { get; set; }

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
        public DbSet<InvoicePaymentMethod> InvoicePaymentMethods { get; set; }

        #endregion

        public InventryMangementSystemDbContext() : base("name=InventryMangementSystemDbContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Branches Table

            //Primary Key
            modelBuilder.Entity<Branch>().HasKey(b => b.BranchID).ToTable("Branches");
            //Other Attributes
            modelBuilder.Entity<Branch>().Property(b => b.Name).IsRequired();
            modelBuilder.Entity<Branch>().Property(b => b.Name).HasMaxLength(50);

            #endregion

            #region Counters Table

            //Primary Key
            modelBuilder.Entity<Counter>().HasKey(c => c.CounterID).ToTable("Counters");
            //Foreign Key
            modelBuilder.Entity<Counter>().HasRequired(c => c.Branch).WithMany(b => b.Counters)
                .HasForeignKey(c => c.BranchID).WillCascadeOnDelete(false);
            //Unique Keys
            modelBuilder.Entity<Counter>().Property(c => c.BranchID)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_BranchCounterID", 1) { IsUnique = true }));
            modelBuilder.Entity<Counter>().Property(c => c.BranchCounterNo)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_BranchCounterID", 2) { IsUnique = true }));
            //Ignore Attribute
            modelBuilder.Entity<Counter>().Ignore(c => c.Online);

            #endregion

            #region Invoices Table

            //Primary Key
            modelBuilder.Entity<Invoice>().HasKey(i => i.InvoiceID).ToTable("Invoices");
            //Unique key
            modelBuilder.Entity<Invoice>().Property(i => i.InvoicePublicID).IsRequired();
            modelBuilder.Entity<Invoice>().Property(i => i.InvoicePublicID).HasMaxLength(30);
            modelBuilder.Entity<Invoice>().Property(i => i.InvoicePublicID)
                    .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
            //Foreign Key
            modelBuilder.Entity<Invoice>().HasRequired(i => i.IssuedBy).WithMany(e => e.IssuedInvoices)
                .HasForeignKey(i => i.IssuedByID).WillCascadeOnDelete(false);
            modelBuilder.Entity<Invoice>().HasRequired(i => i.Counter).WithMany(ica => ica.Invoices)
                .HasForeignKey(i => i.CounterID).WillCascadeOnDelete(false);
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
            //Unique Key
            modelBuilder.Entity<PaymentMethod>().Property(pm => pm.PaymentMethodName).IsRequired();
            modelBuilder.Entity<PaymentMethod>().Property(pm => pm.PaymentMethodName).HasMaxLength(50);
            modelBuilder.Entity<PaymentMethod>().Property(pm => pm.PaymentMethodName)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
            //Other Columns
            modelBuilder.Entity<PaymentMethod>().Property(pm => pm.PaymentMethodNote).IsRequired();
            modelBuilder.Entity<PaymentMethod>().Property(pm => pm.PaymentMethodNote).HasMaxLength(200);

            #endregion

            #region InvoicePaymentMethods Table

            //Primary Key
            modelBuilder.Entity<InvoicePaymentMethod>().HasKey(ipm => new { ipm.InvoiceID, ipm.PaymentMethodID }).ToTable("InvoicePaymentMethods");
            //Foreign Key
            modelBuilder.Entity<InvoicePaymentMethod>().HasRequired(ipm => ipm.Invoice).WithMany(i => i.InvoicePaymentMethods)
                .HasForeignKey(ipm => ipm.InvoiceID).WillCascadeOnDelete(false);
            modelBuilder.Entity<InvoicePaymentMethod>().HasRequired(ipm => ipm.PaymentMethod).WithMany(pm => pm.InvoicePaymentMethods)
                .HasForeignKey(ipm => ipm.PaymentMethodID).WillCascadeOnDelete(false);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}