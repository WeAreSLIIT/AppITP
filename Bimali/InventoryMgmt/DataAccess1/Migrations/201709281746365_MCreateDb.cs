namespace DataAccess1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MCreateDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        PublicItemCode = c.String(nullable: false, maxLength: 128),
                        ItemCode = c.Long(nullable: false),
                        ItemName = c.String(),
                        ItemCategory = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PublicItemCode);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        StockID = c.Long(nullable: false, identity: true),
                        PublicStockID = c.String(),
                        PublicItemCode = c.String(maxLength: 128),
                        ItemName = c.String(),
                        ItemCategory = c.String(),
                        PurchaseOrder = c.String(),
                        UoM = c.String(),
                        InitQty = c.Int(nullable: false),
                        PresentQty = c.Int(nullable: false),
                        WholeSaleValue = c.Single(nullable: false),
                        UnitPrice = c.Single(nullable: false),
                        GRNnum = c.String(),
                        StockStatus = c.Byte(nullable: false),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.StockID)
                .ForeignKey("dbo.Items", t => t.PublicItemCode)
                .Index(t => t.PublicItemCode);
            
            CreateTable(
                "dbo.Recounts",
                c => new
                    {
                        RecountStockId = c.Long(nullable: false, identity: true),
                        RecountStockCode = c.String(),
                        StockStatus = c.Byte(nullable: false),
                        ChangedQty = c.Int(nullable: false),
                        RecountStartDate = c.Long(nullable: false),
                        RecountEndDate = c.Long(nullable: false),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.RecountStockId);
            
            CreateTable(
                "dbo.ReturnStocks",
                c => new
                    {
                        ReturnStockID = c.Long(nullable: false, identity: true),
                        ReturnStockCode = c.String(),
                        ReturnCause = c.String(),
                        ReturnQty = c.Int(nullable: false),
                        Replacement = c.String(),
                        ReturnedToSupplier = c.String(),
                    })
                .PrimaryKey(t => t.ReturnStockID);
            
            CreateTable(
                "dbo.TransInStocks",
                c => new
                    {
                        TransInStockID = c.Long(nullable: false, identity: true),
                        TransInStockCode = c.String(),
                        FromBranchId = c.String(),
                        FromBranchLoc = c.String(),
                        RecievedQty = c.Int(nullable: false),
                        RecievedDate = c.Long(nullable: false),
                        PublicItemCode = c.String(maxLength: 128),
                        ItemName = c.String(),
                        ItemCategory = c.String(),
                        UoM = c.String(),
                        Qty = c.Int(nullable: false),
                        WholeSaleValue = c.Single(nullable: false),
                        UnitPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.TransInStockID)
                .ForeignKey("dbo.Items", t => t.PublicItemCode)
                .Index(t => t.PublicItemCode);
            
            CreateTable(
                "dbo.TransOuts",
                c => new
                    {
                        TransOutStockID = c.Long(nullable: false, identity: true),
                        TransOutStockCode = c.String(),
                        SentQty = c.Int(nullable: false),
                        SentDate = c.Long(nullable: false),
                        GatePass = c.String(),
                    })
                .PrimaryKey(t => t.TransOutStockID);
            
            CreateTable(
                "dbo.Wastages",
                c => new
                    {
                        WastageStockID = c.Long(nullable: false, identity: true),
                        WastageStockCode = c.String(),
                        WastageCause = c.String(),
                        WastageQty = c.Int(nullable: false),
                        WastageValue = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.WastageStockID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransInStocks", "PublicItemCode", "dbo.Items");
            DropForeignKey("dbo.Stocks", "PublicItemCode", "dbo.Items");
            DropIndex("dbo.TransInStocks", new[] { "PublicItemCode" });
            DropIndex("dbo.Stocks", new[] { "PublicItemCode" });
            DropTable("dbo.Wastages");
            DropTable("dbo.TransOuts");
            DropTable("dbo.TransInStocks");
            DropTable("dbo.ReturnStocks");
            DropTable("dbo.Recounts");
            DropTable("dbo.Stocks");
            DropTable("dbo.Items");
        }
    }
}
