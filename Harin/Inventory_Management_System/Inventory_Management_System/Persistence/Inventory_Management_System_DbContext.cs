namespace Inventory_Management_System.Persistence
{
    using Inventory_Management_System.Models;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Linq;

    public class Inventory_Management_System_DbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Rack> Racks { get; set; }

        public Inventory_Management_System_DbContext()
            : base("name=Inventory_Management_System_DbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Category Table

            modelBuilder.Entity<Category>().HasKey(i => i.CategoryId).ToTable("Categories");

            #endregion

            #region SubCategory Table

            modelBuilder.Entity<SubCategory>().HasKey(i => i.CategoryId).ToTable("SubCategories");

            modelBuilder.Entity<SubCategory>().Property(i => i.Description).IsOptional();

            modelBuilder.Entity<SubCategory>().HasRequired(i => i.Category).WithMany(e => e.SubCategories)
                .HasForeignKey(i => i.MainCategoryId).WillCascadeOnDelete(true);

            #endregion

            #region Section Table

            modelBuilder.Entity<Section>().HasKey(i => i.SectionId).ToTable("Sections");

            #endregion

            #region Rack Table

            modelBuilder.Entity<Rack>().HasKey(i => i.RackId).ToTable("Racks");

            modelBuilder.Entity<Rack>().HasRequired(i => i.Section).WithMany(e => e.Racks)
                .HasForeignKey(i => i.SectionId).WillCascadeOnDelete(true);

            #endregion

            #region Product Table

            modelBuilder.Entity<Product>().HasKey(i => i.ProductId).ToTable("Products");

            modelBuilder.Entity<Product>().Property(i => i.ProductPublicId).IsRequired();
            modelBuilder.Entity<Product>().Property(i => i.ProductPublicId)
                    .HasColumnAnnotation("ProductPublicId", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));

            modelBuilder.Entity<Product>().Property(i => i.NotifyDay).IsOptional();
            modelBuilder.Entity<Product>().Property(i => i.NumberOfUnits).IsOptional();
            modelBuilder.Entity<Product>().Property(i => i.Unit).IsOptional();
            modelBuilder.Entity<Product>().Property(i => i.RackId).IsOptional();

            modelBuilder.Entity<Product>().HasOptional(i => i.Rack).WithMany(e => e.Products)
                .HasForeignKey(i => i.RackId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Product>().HasRequired(i => i.SubCategory).WithMany(e => e.Products)
                .HasForeignKey(i => i.SubCategoryId).WillCascadeOnDelete(false);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}