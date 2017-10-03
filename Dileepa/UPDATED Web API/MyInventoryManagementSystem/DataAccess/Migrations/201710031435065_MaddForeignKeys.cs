namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaddForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DiscountSchedules", "DiscountType_DiscountTypeId", "dbo.DiscountTypes");
            DropForeignKey("dbo.GiftVoucherIssues", "GiftVoucherType_GiftVoucherTypeId", "dbo.GiftVoucherTypes");
            DropForeignKey("dbo.PromotionSchedules", "PromotionType_PromoTypeId", "dbo.PromotionTypes");
            DropIndex("dbo.DiscountSchedules", new[] { "DiscountType_DiscountTypeId" });
            DropIndex("dbo.GiftVoucherIssues", new[] { "GiftVoucherType_GiftVoucherTypeId" });
            DropIndex("dbo.PromotionSchedules", new[] { "PromotionType_PromoTypeId" });
            RenameColumn(table: "dbo.DiscountSchedules", name: "DiscountType_DiscountTypeId", newName: "DiscountTypeId");
            RenameColumn(table: "dbo.GiftVoucherIssues", name: "GiftVoucherType_GiftVoucherTypeId", newName: "GiftVoucherTypeId");
            RenameColumn(table: "dbo.PromotionSchedules", name: "PromotionType_PromoTypeId", newName: "PromoTypeId");
            AlterColumn("dbo.DiscountSchedules", "DiscountTypeId", c => c.Long(nullable: false));
            AlterColumn("dbo.GiftVoucherIssues", "GiftVoucherTypeId", c => c.Long(nullable: false));
            AlterColumn("dbo.PromotionSchedules", "PromoTypeId", c => c.Long(nullable: false));
            CreateIndex("dbo.DiscountSchedules", "DiscountTypeId");
            CreateIndex("dbo.GiftVoucherIssues", "GiftVoucherTypeId");
            CreateIndex("dbo.PromotionSchedules", "PromoTypeId");
            AddForeignKey("dbo.DiscountSchedules", "DiscountTypeId", "dbo.DiscountTypes", "DiscountTypeId", cascadeDelete: true);
            AddForeignKey("dbo.GiftVoucherIssues", "GiftVoucherTypeId", "dbo.GiftVoucherTypes", "GiftVoucherTypeId", cascadeDelete: true);
            AddForeignKey("dbo.PromotionSchedules", "PromoTypeId", "dbo.PromotionTypes", "PromoTypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PromotionSchedules", "PromoTypeId", "dbo.PromotionTypes");
            DropForeignKey("dbo.GiftVoucherIssues", "GiftVoucherTypeId", "dbo.GiftVoucherTypes");
            DropForeignKey("dbo.DiscountSchedules", "DiscountTypeId", "dbo.DiscountTypes");
            DropIndex("dbo.PromotionSchedules", new[] { "PromoTypeId" });
            DropIndex("dbo.GiftVoucherIssues", new[] { "GiftVoucherTypeId" });
            DropIndex("dbo.DiscountSchedules", new[] { "DiscountTypeId" });
            AlterColumn("dbo.PromotionSchedules", "PromoTypeId", c => c.Long());
            AlterColumn("dbo.GiftVoucherIssues", "GiftVoucherTypeId", c => c.Long());
            AlterColumn("dbo.DiscountSchedules", "DiscountTypeId", c => c.Long());
            RenameColumn(table: "dbo.PromotionSchedules", name: "PromoTypeId", newName: "PromotionType_PromoTypeId");
            RenameColumn(table: "dbo.GiftVoucherIssues", name: "GiftVoucherTypeId", newName: "GiftVoucherType_GiftVoucherTypeId");
            RenameColumn(table: "dbo.DiscountSchedules", name: "DiscountTypeId", newName: "DiscountType_DiscountTypeId");
            CreateIndex("dbo.PromotionSchedules", "PromotionType_PromoTypeId");
            CreateIndex("dbo.GiftVoucherIssues", "GiftVoucherType_GiftVoucherTypeId");
            CreateIndex("dbo.DiscountSchedules", "DiscountType_DiscountTypeId");
            AddForeignKey("dbo.PromotionSchedules", "PromotionType_PromoTypeId", "dbo.PromotionTypes", "PromoTypeId");
            AddForeignKey("dbo.GiftVoucherIssues", "GiftVoucherType_GiftVoucherTypeId", "dbo.GiftVoucherTypes", "GiftVoucherTypeId");
            AddForeignKey("dbo.DiscountSchedules", "DiscountType_DiscountTypeId", "dbo.DiscountTypes", "DiscountTypeId");
        }
    }
}
