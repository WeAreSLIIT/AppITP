namespace Inventory_Mangement_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IMS : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Credits",
                c => new
                    {
                        CustomerID = c.Long(nullable: false),
                        CreditLimit = c.Double(nullable: false),
                        CreditAmount = c.Double(nullable: false),
                        ExpireDate = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Long(nullable: false, identity: true),
                        CustomerPublicID = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        City = c.String(),
                        DOB = c.Long(nullable: false),
                        Phone = c.Int(nullable: false),
                        Password = c.String(),
                        CurrentLoyaltyCardID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.LoyaltyCards", t => t.CurrentLoyaltyCardID, cascadeDelete: true)
                .Index(t => t.CurrentLoyaltyCardID);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        CustomerID = c.Long(nullable: false),
                        SecurityQuestion = c.String(),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.LoyaltyCards",
                c => new
                    {
                        LoyaltyCardID = c.Long(nullable: false, identity: true),
                        LoyaltyPoints = c.Int(nullable: false),
                        Type = c.String(),
                        RedeemedPoints = c.Int(nullable: false),
                        UnitCurrencyAmount = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                        CurrentLoyatyprogramID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.LoyaltyCardID)
                .ForeignKey("dbo.LoyaltyPrograms", t => t.CurrentLoyatyprogramID, cascadeDelete: true)
                .Index(t => t.CurrentLoyatyprogramID);
            
            CreateTable(
                "dbo.LoyaltyPrograms",
                c => new
                    {
                        LoyaltyProgramID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        ProductInclusion = c.String(),
                        CreatedDate = c.Long(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.LoyaltyProgramID);
            
            CreateTable(
                "dbo.Preorders",
                c => new
                    {
                        PreorderID = c.Long(nullable: false, identity: true),
                        PreorderPublicID = c.String(),
                        Item = c.String(),
                        Quantity = c.Int(nullable: false),
                        PreorderDate = c.Long(nullable: false),
                        CurrentCustomerID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.PreorderID)
                .ForeignKey("dbo.Customers", t => t.CurrentCustomerID, cascadeDelete: true)
                .Index(t => t.CurrentCustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Preorders", "CurrentCustomerID", "dbo.Customers");
            DropForeignKey("dbo.Customers", "CurrentLoyaltyCardID", "dbo.LoyaltyCards");
            DropForeignKey("dbo.LoyaltyCards", "CurrentLoyatyprogramID", "dbo.LoyaltyPrograms");
            DropForeignKey("dbo.Logins", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Credits", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Preorders", new[] { "CurrentCustomerID" });
            DropIndex("dbo.LoyaltyCards", new[] { "CurrentLoyatyprogramID" });
            DropIndex("dbo.Logins", new[] { "CustomerID" });
            DropIndex("dbo.Customers", new[] { "CurrentLoyaltyCardID" });
            DropIndex("dbo.Credits", new[] { "CustomerID" });
            DropTable("dbo.Preorders");
            DropTable("dbo.LoyaltyPrograms");
            DropTable("dbo.LoyaltyCards");
            DropTable("dbo.Logins");
            DropTable("dbo.Customers");
            DropTable("dbo.Credits");
        }
    }
}
