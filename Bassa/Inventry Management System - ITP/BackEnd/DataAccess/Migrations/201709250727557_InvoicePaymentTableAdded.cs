namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoicePaymentTableAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PaymentMethodInvoices", "PaymentMethod_PaymentMethodID", "dbo.PaymentMethods");
            DropForeignKey("dbo.PaymentMethodInvoices", "Invoice_InvoiceID", "dbo.Invoices");
            DropIndex("dbo.PaymentMethodInvoices", new[] { "PaymentMethod_PaymentMethodID" });
            DropIndex("dbo.PaymentMethodInvoices", new[] { "Invoice_InvoiceID" });
            CreateTable(
                "dbo.InvoicePaymentMethods",
                c => new
                    {
                        InvoiceID = c.Long(nullable: false),
                        PaymentMethodID = c.Long(nullable: false),
                        Amount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.InvoiceID, t.PaymentMethodID })
                .ForeignKey("dbo.Invoices", t => t.InvoiceID)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodID)
                .Index(t => t.InvoiceID)
                .Index(t => t.PaymentMethodID);
            
            DropTable("dbo.PaymentMethodInvoices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PaymentMethodInvoices",
                c => new
                    {
                        PaymentMethod_PaymentMethodID = c.Long(nullable: false),
                        Invoice_InvoiceID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.PaymentMethod_PaymentMethodID, t.Invoice_InvoiceID });
            
            DropForeignKey("dbo.InvoicePaymentMethods", "PaymentMethodID", "dbo.PaymentMethods");
            DropForeignKey("dbo.InvoicePaymentMethods", "InvoiceID", "dbo.Invoices");
            DropIndex("dbo.InvoicePaymentMethods", new[] { "PaymentMethodID" });
            DropIndex("dbo.InvoicePaymentMethods", new[] { "InvoiceID" });
            DropTable("dbo.InvoicePaymentMethods");
            CreateIndex("dbo.PaymentMethodInvoices", "Invoice_InvoiceID");
            CreateIndex("dbo.PaymentMethodInvoices", "PaymentMethod_PaymentMethodID");
            AddForeignKey("dbo.PaymentMethodInvoices", "Invoice_InvoiceID", "dbo.Invoices", "InvoiceID", cascadeDelete: true);
            AddForeignKey("dbo.PaymentMethodInvoices", "PaymentMethod_PaymentMethodID", "dbo.PaymentMethods", "PaymentMethodID", cascadeDelete: true);
        }
    }
}
