namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reinitialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.BranchID);
            
            CreateTable(
                "dbo.Counters",
                c => new
                    {
                        CounterID = c.Long(nullable: false, identity: true),
                        BranchCounterNo = c.Long(nullable: false),
                        BranchID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.CounterID)
                .ForeignKey("dbo.Branches", t => t.BranchID)
                .Index(t => new { t.BranchID, t.CounterID }, unique: true, name: "IX_BranchCounterID");
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Long(nullable: false, identity: true),
                        InvoicePublicID = c.String(nullable: false, maxLength: 50),
                        Time = c.Long(nullable: false),
                        FullPayment = c.Single(nullable: false),
                        Discount = c.Single(nullable: false),
                        Payed = c.Single(nullable: false),
                        Balance = c.Single(nullable: false),
                        IssuedByID = c.Long(nullable: false),
                        CounterID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceID)
                .ForeignKey("dbo.Counters", t => t.CounterID)
                .ForeignKey("dbo.Employees", t => t.IssuedByID)
                .Index(t => t.InvoicePublicID, unique: true)
                .Index(t => t.IssuedByID)
                .Index(t => t.CounterID);
            
            CreateTable(
                "dbo.InvoiceCustomers",
                c => new
                    {
                        InvoiceID = c.Long(nullable: false),
                        CustomerID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceID)
                .ForeignKey("dbo.Invoices", t => t.InvoiceID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .Index(t => t.InvoiceID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.InvoiceDeals",
                c => new
                    {
                        InvoiceID = c.Long(nullable: false),
                        InvoiceDealDiscountID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceID)
                .ForeignKey("dbo.Invoices", t => t.InvoiceID)
                .ForeignKey("dbo.InvoiceDealDiscount", t => t.InvoiceDealDiscountID)
                .Index(t => t.InvoiceID)
                .Index(t => t.InvoiceDealDiscountID);
            
            CreateTable(
                "dbo.InvoiceDealDiscount",
                c => new
                    {
                        InvoiceDealDiscountID = c.Long(nullable: false, identity: true),
                        Method = c.Byte(nullable: false),
                        Amount = c.Single(nullable: false),
                        Note = c.String(),
                        GivenEmployeeID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceDealDiscountID)
                .ForeignKey("dbo.Employees", t => t.GivenEmployeeID, cascadeDelete: true)
                .Index(t => t.GivenEmployeeID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Long(nullable: false, identity: true),
                        EmployeeName = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.InvoiceEmployeeDiscounts",
                c => new
                    {
                        InvoiceID = c.Long(nullable: false, identity: true),
                        InvoiceEmployeeDiscountID = c.Long(nullable: false),
                        Method = c.Byte(nullable: false),
                        Amount = c.Single(nullable: false),
                        PermittedEmployeeID = c.Long(nullable: false),
                        Invoice_InvoiceID = c.Long(),
                    })
                .PrimaryKey(t => t.InvoiceID)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceID)
                .ForeignKey("dbo.Employees", t => t.PermittedEmployeeID)
                .Index(t => t.PermittedEmployeeID)
                .Index(t => t.Invoice_InvoiceID);
            
            CreateTable(
                "dbo.InvoiceProduct",
                c => new
                    {
                        InvoiceID = c.Long(nullable: false),
                        ProductID = c.Long(nullable: false),
                        Quantity = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.InvoiceID, t.ProductID })
                .ForeignKey("dbo.Invoices", t => t.InvoiceID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.InvoiceID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Long(nullable: false, identity: true),
                        ProductPublicID = c.String(),
                        ProductName = c.String(),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        PaymentMethodID = c.Long(nullable: false, identity: true),
                        PaymentMethodName = c.String(nullable: false, maxLength: 50),
                        PaymentMethodNote = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.PaymentMethodID)
                .Index(t => t.PaymentMethodName, unique: true);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        DiscountID = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.DiscountID);
            
            CreateTable(
                "dbo.PaymentMethodInvoices",
                c => new
                    {
                        PaymentMethod_PaymentMethodID = c.Long(nullable: false),
                        Invoice_InvoiceID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.PaymentMethod_PaymentMethodID, t.Invoice_InvoiceID })
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethod_PaymentMethodID, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceID, cascadeDelete: true)
                .Index(t => t.PaymentMethod_PaymentMethodID)
                .Index(t => t.Invoice_InvoiceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaymentMethodInvoices", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.PaymentMethodInvoices", "PaymentMethod_PaymentMethodID", "dbo.PaymentMethods");
            DropForeignKey("dbo.Invoices", "IssuedByID", "dbo.Employees");
            DropForeignKey("dbo.InvoiceProduct", "ProductId", "dbo.Products");
            DropForeignKey("dbo.InvoiceProduct", "InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.InvoiceDeals", "InvoiceDealDiscountID", "dbo.InvoiceDealDiscount");
            DropForeignKey("dbo.InvoiceDealDiscount", "GivenEmployeeID", "dbo.Employees");
            DropForeignKey("dbo.InvoiceEmployeeDiscounts", "PermittedEmployeeID", "dbo.Employees");
            DropForeignKey("dbo.InvoiceEmployeeDiscounts", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.InvoiceDeals", "InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.InvoiceCustomers", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.InvoiceCustomers", "InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "CounterID", "dbo.Counters");
            DropForeignKey("dbo.Counters", "BranchID", "dbo.Branches");
            DropIndex("dbo.PaymentMethodInvoices", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.PaymentMethodInvoices", new[] { "PaymentMethod_PaymentMethodID" });
            DropIndex("dbo.PaymentMethods", new[] { "PaymentMethodName" });
            DropIndex("dbo.InvoiceProduct", new[] { "ProductId" });
            DropIndex("dbo.InvoiceProduct", new[] { "InvoiceID" });
            DropIndex("dbo.InvoiceEmployeeDiscounts", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.InvoiceEmployeeDiscounts", new[] { "PermittedEmployeeID" });
            DropIndex("dbo.InvoiceDealDiscount", new[] { "GivenEmployeeID" });
            DropIndex("dbo.InvoiceDeals", new[] { "InvoiceDealDiscountID" });
            DropIndex("dbo.InvoiceDeals", new[] { "InvoiceID" });
            DropIndex("dbo.InvoiceCustomers", new[] { "CustomerID" });
            DropIndex("dbo.InvoiceCustomers", new[] { "InvoiceID" });
            DropIndex("dbo.Invoices", new[] { "CounterID" });
            DropIndex("dbo.Invoices", new[] { "IssuedByID" });
            DropIndex("dbo.Invoices", new[] { "InvoicePublicID" });
            DropIndex("dbo.Counters", "IX_BranchCounterID");
            DropTable("dbo.PaymentMethodInvoices");
            DropTable("dbo.Discounts");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.Products");
            DropTable("dbo.InvoiceProduct");
            DropTable("dbo.InvoiceEmployeeDiscounts");
            DropTable("dbo.Employees");
            DropTable("dbo.InvoiceDealDiscount");
            DropTable("dbo.InvoiceDeals");
            DropTable("dbo.Customers");
            DropTable("dbo.InvoiceCustomers");
            DropTable("dbo.Invoices");
            DropTable("dbo.Counters");
            DropTable("dbo.Branches");
        }
    }
}
