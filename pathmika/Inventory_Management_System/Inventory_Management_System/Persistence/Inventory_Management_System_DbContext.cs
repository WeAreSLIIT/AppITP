namespace Inventory_Management_System.Persistence
{
    using Inventory_Management_System.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Inventory_Management_System_DbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderService> OrderServices { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProductSupplier> ProductSuppliers { get; set; }
        public DbSet<ServiceSupplier> ServiceSuppliers { get; set; }
        public DbSet<SupplierPayment> SupplierPayments { get; set; }

        // Your context has been configured to use a 'Inventory_Management_System_DbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Inventory_Management_System.Persistence.Inventory_Management_System_DbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Inventory_Management_System_DbContext' 
        // connection string in the application configuration file.
        public Inventory_Management_System_DbContext()
            : base("name=Inventory_Management_System_DbContext")
        {
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //    base.OnModelCreating(modelBuilder);
        //}
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}