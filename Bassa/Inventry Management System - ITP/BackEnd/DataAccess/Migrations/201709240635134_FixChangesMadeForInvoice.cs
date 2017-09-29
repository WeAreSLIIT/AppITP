namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixChangesMadeForInvoice : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Invoices", new[] { "InvoicePublicID" });
            AddColumn("dbo.Counters", "Disabled", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Invoices", "InvoicePublicID", c => c.String(nullable: false, maxLength: 30));
            CreateIndex("dbo.Invoices", "InvoicePublicID", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Invoices", new[] { "InvoicePublicID" });
            AlterColumn("dbo.Invoices", "InvoicePublicID", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Counters", "Disabled");
            CreateIndex("dbo.Invoices", "InvoicePublicID", unique: true);
        }
    }
}
