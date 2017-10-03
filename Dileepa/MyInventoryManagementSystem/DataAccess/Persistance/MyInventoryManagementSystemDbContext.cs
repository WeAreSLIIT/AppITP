using DataAccess.Core.Domain;

namespace DataAccess.Persistance
{
	using System;
	using System.Data.Entity;
	using System.Linq;

	public class MyInventoryManagementSystemDbContext : DbContext
	{
		public DbSet<DiscountType> DiscountTypes { get; set; }
		public DbSet<DiscountSchedule> DiscountShedules { get; set; }
		public DbSet<PromotionType> PromotionTypes { get; set; }
		public DbSet<PromotionSchedule> PromotionShedules { get; set; }
		public DbSet<GiftVoucherType> GiftVoucherTypes { get; set; }
		public DbSet<GiftVoucherIssue> GiftVoucherIssues { get; set; }

		// Your context has been configured to use a 'MyInventoryManagementSystemDbContext' connection string from your application's 
		// configuration file (App.config or Web.config). By default, this connection string targets the 
		// 'DataAccess.Persistance.MyInventoryManagementSystemDbContext' database on your LocalDb instance. 
		// 
		// If you wish to target a different database and/or database provider, modify the 'MyInventoryManagementSystemDbContext' 
		// connection string in the application configuration file.
		public MyInventoryManagementSystemDbContext()
			: base("name=MyInventoryManagementSystemDbContext")
		{
		}

		//protected override void OnModelCreating(DbModelBuilder modelBuilder)
		//{
		//	//primary key
		//	modelBuilder.Entity<DiscountSchedule>().HasKey(d => d.DiscountSheduleId).ToTable("DiscountShedules");
				
		//	base.OnModelCreating(modelBuilder);
		//}
		// Add a DbSet for each entity type that you want to include in your model. For more information 
		// on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

		// public virtual DbSet<MyEntity> MyEntities { get; set; }
	}

	//public class MyEntity
	//{
	//    public int Id { get; set; }
	//    public string Name { get; set; }
	//}
}