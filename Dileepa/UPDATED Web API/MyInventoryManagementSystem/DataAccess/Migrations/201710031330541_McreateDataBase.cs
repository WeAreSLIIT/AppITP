namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class McreateDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiscountSchedules",
                c => new
                    {
                        DiscountSheduleId = c.Long(nullable: false, identity: true),
                        DiscountShedulePublicId = c.String(),
                        DiscountSheduleItemCode = c.String(),
                        OriginalPrice = c.Single(nullable: false),
                        PriceWithDiscount = c.Single(nullable: false),
                        DiscountSheduleFrom = c.Long(nullable: false),
                        DiscountSheduleTo = c.Long(nullable: false),
                        DiscountAmount = c.Single(nullable: false),
                        Method = c.Byte(nullable: false),
                        DiscountMethod = c.Byte(nullable: false),
                        DiscountType_DiscountTypeId = c.Long(),
                    })
                .PrimaryKey(t => t.DiscountSheduleId)
                .ForeignKey("dbo.DiscountTypes", t => t.DiscountType_DiscountTypeId)
                .Index(t => t.DiscountType_DiscountTypeId);
            
            CreateTable(
                "dbo.DiscountTypes",
                c => new
                    {
                        DiscountTypeId = c.Long(nullable: false, identity: true),
                        DiscountTypePublicId = c.String(),
                        DiscountTypeName = c.String(),
                        DiscountTimeSpan = c.Long(nullable: false),
                        DiscountTypeTax = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.DiscountTypeId);
            
            CreateTable(
                "dbo.GiftVoucherIssues",
                c => new
                    {
                        IssueGiftVoucherCode = c.Long(nullable: false, identity: true),
                        IssueGiftVoucherPublicCode = c.String(),
                        IssueGiftVoucherTypeId = c.String(),
                        IssueGiftVoucherAmount = c.Single(nullable: false),
                        IssueGiftVoucherTo = c.String(),
                        IssueGiftVoucherEmail = c.String(),
                        IssueGiftVoucherPhone = c.Int(nullable: false),
                        IssueGiftVoucherSKU = c.Long(nullable: false),
                        GiftVoucherStatus = c.Byte(nullable: false),
                        Status = c.Byte(nullable: false),
                        GiftVoucherType_GiftVoucherTypeId = c.Long(),
                    })
                .PrimaryKey(t => t.IssueGiftVoucherCode)
                .ForeignKey("dbo.GiftVoucherTypes", t => t.GiftVoucherType_GiftVoucherTypeId)
                .Index(t => t.GiftVoucherType_GiftVoucherTypeId);
            
            CreateTable(
                "dbo.GiftVoucherTypes",
                c => new
                    {
                        GiftVoucherTypeId = c.Long(nullable: false, identity: true),
                        GiftVoucherTypePublicId = c.String(),
                        GiftVoucherTypeName = c.String(),
                        GiftVoucherTypeAmount = c.Single(nullable: false),
                        GiftVoucherTypeDescription = c.String(maxLength: 255),
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
                        PromoShedulePublicId = c.String(),
                        PromoSheduleItemCode = c.String(),
                        PromoSheduleName = c.String(),
                        PromoSheduleType = c.String(),
                        SpecialStock = c.String(),
                        PromoSheduleDescription = c.String(maxLength: 255),
                        PromoSheduleFrom = c.Long(nullable: false),
                        PromoSheduleTo = c.Long(nullable: false),
                        PromotionType_PromoTypeId = c.Long(),
                    })
                .PrimaryKey(t => t.PromoSheduleId)
                .ForeignKey("dbo.PromotionTypes", t => t.PromotionType_PromoTypeId)
                .Index(t => t.PromotionType_PromoTypeId);
            
            CreateTable(
                "dbo.PromotionTypes",
                c => new
                    {
                        PromoTypeId = c.Long(nullable: false, identity: true),
                        PromoTypePublicId = c.String(),
                        PromoTypeName = c.String(),
                        PromoTimeSpan = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.PromoTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PromotionSchedules", "PromotionType_PromoTypeId", "dbo.PromotionTypes");
            DropForeignKey("dbo.GiftVoucherIssues", "GiftVoucherType_GiftVoucherTypeId", "dbo.GiftVoucherTypes");
            DropForeignKey("dbo.DiscountSchedules", "DiscountType_DiscountTypeId", "dbo.DiscountTypes");
            DropIndex("dbo.PromotionSchedules", new[] { "PromotionType_PromoTypeId" });
            DropIndex("dbo.GiftVoucherIssues", new[] { "GiftVoucherType_GiftVoucherTypeId" });
            DropIndex("dbo.DiscountSchedules", new[] { "DiscountType_DiscountTypeId" });
            DropTable("dbo.PromotionTypes");
            DropTable("dbo.PromotionSchedules");
            DropTable("dbo.GiftVoucherTypes");
            DropTable("dbo.GiftVoucherIssues");
            DropTable("dbo.DiscountTypes");
            DropTable("dbo.DiscountSchedules");
        }
    }
}
