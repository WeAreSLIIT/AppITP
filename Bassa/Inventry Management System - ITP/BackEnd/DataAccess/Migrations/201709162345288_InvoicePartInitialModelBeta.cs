namespace DataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class InvoicePartInitialModelBeta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CustomerID);
            
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
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Long(nullable: false, identity: true),
                        PublicID = c.String(nullable: false, maxLength: 20,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "InvoicePublicID",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { IsUnique: True }")
                                },
                            }),
                        Time = c.Long(nullable: false),
                        FullPayment = c.Single(nullable: false),
                        Discount = c.Single(nullable: false),
                        Payed = c.Single(nullable: false),
                        Balance = c.Single(nullable: false),
                        EmployeeID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID)
                .Index(t => t.EmployeeID);
            
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
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        PaymentMethodID = c.Long(nullable: false, identity: true),
                        PaymentMethodName = c.String(nullable: false, maxLength: 100),
                        InvoiceProduct_InvoiceID = c.Long(),
                        InvoiceProduct_ProductID = c.Long(),
                    })
                .PrimaryKey(t => t.PaymentMethodID)
                .ForeignKey("dbo.InvoiceProduct", t => new { t.InvoiceProduct_InvoiceID, t.InvoiceProduct_ProductID })
                .Index(t => new { t.InvoiceProduct_InvoiceID, t.InvoiceProduct_ProductID });
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        DiscountID = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.DiscountID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Long(nullable: false, identity: true),
                        ProductName = c.String(),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.InvoiceProductInvoices",
                c => new
                    {
                        InvoiceProduct_InvoiceID = c.Long(nullable: false),
                        InvoiceProduct_ProductID = c.Long(nullable: false),
                        Invoice_InvoiceID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.InvoiceProduct_InvoiceID, t.InvoiceProduct_ProductID, t.Invoice_InvoiceID })
                .ForeignKey("dbo.InvoiceProduct", t => new { t.InvoiceProduct_InvoiceID, t.InvoiceProduct_ProductID }, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceID, cascadeDelete: true)
                .Index(t => new { t.InvoiceProduct_InvoiceID, t.InvoiceProduct_ProductID })
                .Index(t => t.Invoice_InvoiceID);
            
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
            DropForeignKey("dbo.InvoiceProduct", "ProductID", "dbo.Products");
            DropForeignKey("dbo.InvoiceCustomers", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.InvoiceCustomers", "InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.PaymentMethods", new[] { "InvoiceProduct_InvoiceID", "InvoiceProduct_ProductID" }, "dbo.InvoiceProduct");
            DropForeignKey("dbo.PaymentMethodInvoices", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.PaymentMethodInvoices", "PaymentMethod_PaymentMethodID", "dbo.PaymentMethods");
            DropForeignKey("dbo.InvoiceProductInvoices", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.InvoiceProductInvoices", new[] { "InvoiceProduct_InvoiceID", "InvoiceProduct_ProductID" }, "dbo.InvoiceProduct");
            DropForeignKey("dbo.InvoiceDeals", "InvoiceDealDiscountID", "dbo.InvoiceDealDiscount");
            DropForeignKey("dbo.InvoiceDealDiscount", "GivenEmployeeID", "dbo.Employees");
            DropForeignKey("dbo.InvoiceEmployeeDiscounts", "PermittedEmployeeID", "dbo.Employees");
            DropForeignKey("dbo.InvoiceEmployeeDiscounts", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.InvoiceDeals", "InvoiceID", "dbo.Invoices");
            DropIndex("dbo.PaymentMethodInvoices", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.PaymentMethodInvoices", new[] { "PaymentMethod_PaymentMethodID" });
            DropIndex("dbo.InvoiceProductInvoices", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.InvoiceProductInvoices", new[] { "InvoiceProduct_InvoiceID", "InvoiceProduct_ProductID" });
            DropIndex("dbo.PaymentMethods", new[] { "InvoiceProduct_InvoiceID", "InvoiceProduct_ProductID" });
            DropIndex("dbo.InvoiceProduct", new[] { "ProductID" });
            DropIndex("dbo.InvoiceEmployeeDiscounts", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.InvoiceEmployeeDiscounts", new[] { "PermittedEmployeeID" });
            DropIndex("dbo.InvoiceDealDiscount", new[] { "GivenEmployeeID" });
            DropIndex("dbo.InvoiceDeals", new[] { "InvoiceDealDiscountID" });
            DropIndex("dbo.InvoiceDeals", new[] { "InvoiceID" });
            DropIndex("dbo.Invoices", new[] { "EmployeeID" });
            DropIndex("dbo.InvoiceCustomers", new[] { "CustomerID" });
            DropIndex("dbo.InvoiceCustomers", new[] { "InvoiceID" });
            DropTable("dbo.PaymentMethodInvoices");
            DropTable("dbo.InvoiceProductInvoices");
            DropTable("dbo.Products");
            DropTable("dbo.Discounts");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.InvoiceProduct");
            DropTable("dbo.InvoiceEmployeeDiscounts");
            DropTable("dbo.Employees");
            DropTable("dbo.InvoiceDealDiscount");
            DropTable("dbo.InvoiceDeals");
            DropTable("dbo.Invoices",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "PublicID",
                        new Dictionary<string, object>
                        {
                            { "InvoicePublicID", "IndexAnnotation: { IsUnique: True }" },
                        }
                    },
                });
            DropTable("dbo.InvoiceCustomers");
            DropTable("dbo.Customers");
        }
    }
}
