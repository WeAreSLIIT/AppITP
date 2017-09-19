namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassesChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InvoiceProductInvoices", new[] { "InvoiceProduct_InvoiceID", "InvoiceProduct_ProductID" }, "dbo.InvoiceProduct");
            DropForeignKey("dbo.InvoiceProductInvoices", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.PaymentMethods", new[] { "InvoiceProduct_InvoiceID", "InvoiceProduct_ProductID" }, "dbo.InvoiceProduct");
            DropIndex("dbo.PaymentMethods", new[] { "InvoiceProduct_InvoiceID", "InvoiceProduct_ProductID" });
            DropIndex("dbo.InvoiceProductInvoices", new[] { "InvoiceProduct_InvoiceID", "InvoiceProduct_ProductID" });
            DropIndex("dbo.InvoiceProductInvoices", new[] { "Invoice_InvoiceID" });
            CreateIndex("dbo.InvoiceProduct", "InvoiceID");
            AddForeignKey("dbo.InvoiceProduct", "InvoiceID", "dbo.Invoices", "InvoiceID", cascadeDelete: true);
            DropColumn("dbo.PaymentMethods", "InvoiceProduct_InvoiceID");
            DropColumn("dbo.PaymentMethods", "InvoiceProduct_ProductID");
            DropTable("dbo.InvoiceProductInvoices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.InvoiceProductInvoices",
                c => new
                    {
                        InvoiceProduct_InvoiceID = c.Long(nullable: false),
                        InvoiceProduct_ProductID = c.Long(nullable: false),
                        Invoice_InvoiceID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.InvoiceProduct_InvoiceID, t.InvoiceProduct_ProductID, t.Invoice_InvoiceID });
            
            AddColumn("dbo.PaymentMethods", "InvoiceProduct_ProductID", c => c.Long());
            AddColumn("dbo.PaymentMethods", "InvoiceProduct_InvoiceID", c => c.Long());
            DropForeignKey("dbo.InvoiceProduct", "InvoiceID", "dbo.Invoices");
            DropIndex("dbo.InvoiceProduct", new[] { "InvoiceID" });
            CreateIndex("dbo.InvoiceProductInvoices", "Invoice_InvoiceID");
            CreateIndex("dbo.InvoiceProductInvoices", new[] { "InvoiceProduct_InvoiceID", "InvoiceProduct_ProductID" });
            CreateIndex("dbo.PaymentMethods", new[] { "InvoiceProduct_InvoiceID", "InvoiceProduct_ProductID" });
            AddForeignKey("dbo.PaymentMethods", new[] { "InvoiceProduct_InvoiceID", "InvoiceProduct_ProductID" }, "dbo.InvoiceProduct", new[] { "InvoiceID", "ProductID" });
            AddForeignKey("dbo.InvoiceProductInvoices", "Invoice_InvoiceID", "dbo.Invoices", "InvoiceID", cascadeDelete: true);
            AddForeignKey("dbo.InvoiceProductInvoices", new[] { "InvoiceProduct_InvoiceID", "InvoiceProduct_ProductID" }, "dbo.InvoiceProduct", new[] { "InvoiceID", "ProductID" }, cascadeDelete: true);
        }
    }
}
