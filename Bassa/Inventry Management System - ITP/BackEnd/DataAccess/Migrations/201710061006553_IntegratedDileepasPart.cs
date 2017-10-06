namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntegratedDileepasPart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiscountSchedules",
                c => new
                    {
                        DiscountSheduleId = c.Long(nullable: false, identity: true),
                        DiscountTypeId = c.Long(nullable: false),
                        DiscountShedulePublicId = c.String(),
                        DiscountSheduleItemCode = c.String(),
                        OriginalPrice = c.Single(nullable: false),
                        PriceWithDiscount = c.Single(nullable: false),
                        DiscountSheduleFrom = c.Long(nullable: false),
                        DiscountSheduleTo = c.Long(nullable: false),
                        DiscountAmount = c.Single(nullable: false),
                        Method = c.Byte(nullable: false),
                        DiscountMethod = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.DiscountSheduleId)
                .ForeignKey("dbo.DiscountTypes", t => t.DiscountTypeId, cascadeDelete: true)
                .Index(t => t.DiscountTypeId);
            
            CreateTable(
                "dbo.DiscountTypes",
                c => new
                    {
                        DiscountTypeId = c.Long(nullable: false, identity: true),
                        DiscountTypePublicId = c.String(),
                        DiscountTypeName = c.String(nullable: false),
                        DiscountTimeSpan = c.Long(nullable: false),
                        DiscountTypeTax = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.DiscountTypeId);
            
            CreateTable(
                "dbo.GiftVoucherIssues",
                c => new
                    {
                        IssueGiftVoucherCode = c.Long(nullable: false, identity: true),
                        GiftVoucherTypeId = c.Long(nullable: false),
                        IssueGiftVoucherPublicCode = c.String(),
                        IssueGiftVoucherTypeId = c.String(),
                        IssueGiftVoucherAmount = c.Single(nullable: false),
                        IssueGiftVoucherTo = c.String(nullable: false),
                        IssueGiftVoucherEmail = c.String(nullable: false),
                        IssueGiftVoucherPhone = c.Int(nullable: false),
                        IssueGiftVoucherSKU = c.Long(nullable: false),
                        GiftVoucherStatus = c.Byte(nullable: false),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.IssueGiftVoucherCode)
                .ForeignKey("dbo.GiftVoucherTypes", t => t.GiftVoucherTypeId, cascadeDelete: true)
                .Index(t => t.GiftVoucherTypeId);
            
            CreateTable(
                "dbo.GiftVoucherTypes",
                c => new
                    {
                        GiftVoucherTypeId = c.Long(nullable: false, identity: true),
                        GiftVoucherTypePublicId = c.String(),
                        GiftVoucherTypeName = c.String(nullable: false),
                        GiftVoucherTypeAmount = c.Single(nullable: false),
                        GiftVoucherTypeDescription = c.String(nullable: false, maxLength: 255),
                        GiftVoucherTypeNoOfDays = c.Int(nullable: false),
                        GiftVoucherExpiration = c.Byte(nullable: false),
                        ExpireStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GiftVoucherTypeId);
            
            CreateTable(
                "dbo.PromotionSchedules",
                c => new
                    {
                        PromoSheduleId = c.Long(nullable: false, identity: true),
                        PromoTypeId = c.Long(nullable: false),
                        PromoShedulePublicId = c.String(),
                        PromoSheduleItemCode = c.String(nullable: false),
                        PromoSheduleName = c.String(nullable: false),
                        PromoSheduleType = c.String(nullable: false),
                        SpecialStock = c.String(),
                        PromoSheduleDescription = c.String(maxLength: 255),
                        PromoSheduleFrom = c.Long(nullable: false),
                        PromoSheduleTo = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.PromoSheduleId)
                .ForeignKey("dbo.PromotionTypes", t => t.PromoTypeId, cascadeDelete: true)
                .Index(t => t.PromoTypeId);
            
            CreateTable(
                "dbo.PromotionTypes",
                c => new
                    {
                        PromoTypeId = c.Long(nullable: false, identity: true),
                        PromoTypePublicId = c.String(),
                        PromoTypeName = c.String(nullable: false),
                        PromoTimeSpan = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.PromoTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PromotionSchedules", "PromoTypeId", "dbo.PromotionTypes");
            DropForeignKey("dbo.GiftVoucherIssues", "GiftVoucherTypeId", "dbo.GiftVoucherTypes");
            DropForeignKey("dbo.DiscountSchedules", "DiscountTypeId", "dbo.DiscountTypes");
            DropIndex("dbo.PromotionSchedules", new[] { "PromoTypeId" });
            DropIndex("dbo.GiftVoucherIssues", new[] { "GiftVoucherTypeId" });
            DropIndex("dbo.DiscountSchedules", new[] { "DiscountTypeId" });
            DropTable("dbo.PromotionTypes");
            DropTable("dbo.PromotionSchedules");
            DropTable("dbo.GiftVoucherTypes");
            DropTable("dbo.GiftVoucherIssues");
            DropTable("dbo.DiscountTypes");
            DropTable("dbo.DiscountSchedules");
        }
    }
}
