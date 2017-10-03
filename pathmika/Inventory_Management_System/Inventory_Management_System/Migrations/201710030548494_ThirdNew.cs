namespace Inventory_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdNew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SupplierPayments",
                c => new
                    {
                        SupplierPaymentID = c.Long(nullable: false, identity: true),
                        PaymentPublicID = c.String(),
                        SupplierDeliverCost = c.Double(nullable: false),
                        DueDate = c.Long(nullable: false),
                        PayingDate = c.Long(nullable: false),
                        subTotal = c.Single(nullable: false),
                        TotalCost = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierPaymentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SupplierPayments");
        }
    }
}
