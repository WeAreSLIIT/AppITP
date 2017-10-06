using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Configuration;
using Inventory_Mangement_System.Models;

namespace Inventory_Mangement_System.DataAccess
{
    public class InventoryManagementSystemDbContext :DbContext
    {
        //public DbSet<Person> Persons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LoyaltyCard> LoyaltyCards { get; set; }
        public DbSet<LoyaltyProgram> LoyaltyPrograms { get; set; }
        public DbSet<Preorder> Preorders { get; set; }
        public DbSet<Credit> Credits { get; set; }

        public InventoryManagementSystemDbContext():base("name=InventoryManagementSystemDbContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            

            #region Customer Table

            modelBuilder.Entity<Customer>().HasKey(i =>i.CustomerID).ToTable("Customers");

            modelBuilder.Entity<Customer>().HasRequired(i => i.CustomerLogin).WithRequiredPrincipal(s => s.HasCustomer);

            modelBuilder.Entity<Customer>().HasRequired(i => i.Credits).WithRequiredPrincipal(s => s.CreditCustomer);

            modelBuilder.Entity<Customer>().Property(i => i.CurrentLoyaltyCardID).IsOptional();
            
            modelBuilder.Entity<Customer>().HasRequired<LoyaltyCard>(i => i.OwnedLoyaltyCard).WithMany(e=>e.OwnedCustomer).HasForeignKey<long>(s => s.CurrentLoyaltyCardID);



            #endregion

            #region Login Table

            modelBuilder.Entity<Login>().HasKey(i => i.CustomerID).ToTable("Logins");

            #endregion

            #region Credit Table

            modelBuilder.Entity<Credit>().HasKey(i => i.CustomerID).ToTable("Credits");
            
            #endregion

            #region Loyalty Card Table

            modelBuilder.Entity<LoyaltyCard>().HasKey(i => i.LoyaltyCardID).ToTable("LoyaltyCards");
            modelBuilder.Entity<LoyaltyCard>().HasRequired<LoyaltyProgram>(i => i.BelongsToLoyaltyProgram).WithMany(e => e.OffersLoyaltyCard).HasForeignKey<long>(s => s.CurrentLoyatyprogramID).WillCascadeOnDelete(true);
            

            #endregion

            #region Loyalty Program Table

            modelBuilder.Entity<LoyaltyProgram>().HasKey(i => i.LoyaltyProgramID).ToTable("LoyaltyPrograms");

            

            #endregion

            #region  Preorder Table

            modelBuilder.Entity<Preorder>().HasKey(i => i.PreorderID).ToTable("Preorders");
          
            modelBuilder.Entity<Preorder>().HasRequired<Customer>(i=> i.PreorderCustomer).WithMany(e => e.Preorders).HasForeignKey<long>(s => s.CurrentCustomerID).WillCascadeOnDelete(true);



            #endregion



            base.OnModelCreating(modelBuilder);
        }
    }
}