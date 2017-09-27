namespace Inventory_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "NotifyDay", c => c.Int());
            AlterColumn("dbo.Products", "NumberOfUnits", c => c.Int());
            AlterColumn("dbo.Products", "Unit", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Unit", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "NumberOfUnits", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "NotifyDay", c => c.Int(nullable: false));
        }
    }
}
