namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MchangeRequiredAttr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DiscountTypes", "DiscountTypeName", c => c.String(nullable: false));
            AlterColumn("dbo.GiftVoucherIssues", "IssueGiftVoucherTo", c => c.String(nullable: false));
            AlterColumn("dbo.GiftVoucherIssues", "IssueGiftVoucherEmail", c => c.String(nullable: false));
            AlterColumn("dbo.GiftVoucherTypes", "GiftVoucherTypeName", c => c.String(nullable: false));
            AlterColumn("dbo.GiftVoucherTypes", "GiftVoucherTypeDescription", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.PromotionSchedules", "PromoSheduleItemCode", c => c.String(nullable: false));
            AlterColumn("dbo.PromotionSchedules", "PromoSheduleName", c => c.String(nullable: false));
            AlterColumn("dbo.PromotionSchedules", "PromoSheduleType", c => c.String(nullable: false));
            AlterColumn("dbo.PromotionTypes", "PromoTypeName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PromotionTypes", "PromoTypeName", c => c.String());
            AlterColumn("dbo.PromotionSchedules", "PromoSheduleType", c => c.String());
            AlterColumn("dbo.PromotionSchedules", "PromoSheduleName", c => c.String());
            AlterColumn("dbo.PromotionSchedules", "PromoSheduleItemCode", c => c.String());
            AlterColumn("dbo.GiftVoucherTypes", "GiftVoucherTypeDescription", c => c.String(maxLength: 255));
            AlterColumn("dbo.GiftVoucherTypes", "GiftVoucherTypeName", c => c.String());
            AlterColumn("dbo.GiftVoucherIssues", "IssueGiftVoucherEmail", c => c.String());
            AlterColumn("dbo.GiftVoucherIssues", "IssueGiftVoucherTo", c => c.String());
            AlterColumn("dbo.DiscountTypes", "DiscountTypeName", c => c.String());
        }
    }
}
