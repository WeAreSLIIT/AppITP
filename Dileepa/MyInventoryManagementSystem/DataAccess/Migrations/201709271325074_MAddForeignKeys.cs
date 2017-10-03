namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MAddForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DiscountSchedules", "DiscountType_DiscountTypeId", "dbo.DiscountTypes");
            DropIndex("dbo.DiscountSchedules", new[] { "DiscountType_DiscountTypeId" });
            RenameColumn(table: "dbo.DiscountSchedules", name: "DiscountType_DiscountTypeId", newName: "DiscountTypeId");
            AddColumn("dbo.GiftVoucherIssues", "GiftVoucherTypeId", c => c.Long(nullable: false));
            AddColumn("dbo.PromotionSchedules", "PromoTypeId", c => c.Long(nullable: false));
            AlterColumn("dbo.DiscountSchedules", "DiscountTypeId", c => c.Long(nullable: false));
            CreateIndex("dbo.DiscountSchedules", "DiscountTypeId");
            CreateIndex("dbo.GiftVoucherIssues", "GiftVoucherTypeId");
            CreateIndex("dbo.PromotionSchedules", "PromoTypeId");
            AddForeignKey("dbo.GiftVoucherIssues", "GiftVoucherTypeId", "dbo.GiftVoucherTypes", "GiftVoucherTypeId", cascadeDelete: true);
            AddForeignKey("dbo.PromotionSchedules", "PromoTypeId", "dbo.PromotionTypes", "PromoTypeId", cascadeDelete: true);
            AddForeignKey("dbo.DiscountSchedules", "DiscountTypeId", "dbo.DiscountTypes", "DiscountTypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiscountSchedules", "DiscountTypeId", "dbo.DiscountTypes");
            DropForeignKey("dbo.PromotionSchedules", "PromoTypeId", "dbo.PromotionTypes");
            DropForeignKey("dbo.GiftVoucherIssues", "GiftVoucherTypeId", "dbo.GiftVoucherTypes");
            DropIndex("dbo.PromotionSchedules", new[] { "PromoTypeId" });
            DropIndex("dbo.GiftVoucherIssues", new[] { "GiftVoucherTypeId" });
            DropIndex("dbo.DiscountSchedules", new[] { "DiscountTypeId" });
            AlterColumn("dbo.DiscountSchedules", "DiscountTypeId", c => c.Long());
            DropColumn("dbo.PromotionSchedules", "PromoTypeId");
            DropColumn("dbo.GiftVoucherIssues", "GiftVoucherTypeId");
            RenameColumn(table: "dbo.DiscountSchedules", name: "DiscountTypeId", newName: "DiscountType_DiscountTypeId");
            CreateIndex("dbo.DiscountSchedules", "DiscountType_DiscountTypeId");
            AddForeignKey("dbo.DiscountSchedules", "DiscountType_DiscountTypeId", "dbo.DiscountTypes", "DiscountTypeId");
        }
    }
}
