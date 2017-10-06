namespace DataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class IntegratedHarinKaviAndPathmika : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Credits",
                c => new
                    {
                        CustomerID = c.Long(nullable: false),
                        CreditLimit = c.Double(nullable: false),
                        CreditAmount = c.Double(nullable: false),
                        ExpireDate = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        CustomerID = c.Long(nullable: false),
                        SecurityQuestion = c.String(),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.LoyaltyCards",
                c => new
                    {
                        LoyaltyCardID = c.Long(nullable: false, identity: true),
                        LoyaltyPoints = c.Int(nullable: false),
                        Type = c.String(),
                        RedeemedPoints = c.Int(nullable: false),
                        UnitCurrencyAmount = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                        CurrentLoyatyprogramID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.LoyaltyCardID)
                .ForeignKey("dbo.LoyaltyPrograms", t => t.CurrentLoyatyprogramID, cascadeDelete: true)
                .Index(t => t.CurrentLoyatyprogramID);
            
            CreateTable(
                "dbo.LoyaltyPrograms",
                c => new
                    {
                        LoyaltyProgramID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        ProductInclusion = c.String(),
                        CreatedDate = c.Long(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.LoyaltyProgramID);
            
            CreateTable(
                "dbo.Preorders",
                c => new
                    {
                        PreorderID = c.Long(nullable: false, identity: true),
                        PreorderPublicID = c.String(),
                        Item = c.String(),
                        Quantity = c.Int(nullable: false),
                        PreorderDate = c.Long(nullable: false),
                        CurrentCustomerID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.PreorderID)
                .ForeignKey("dbo.Customers", t => t.CurrentCustomerID, cascadeDelete: true)
                .Index(t => t.CurrentCustomerID);
            
            CreateTable(
                "dbo.Racks",
                c => new
                    {
                        RackId = c.Long(nullable: false, identity: true),
                        RackName = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "RackName",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { IsUnique: True }")
                                },
                            }),
                        SectionId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.RackId)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .Index(t => t.SectionId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        SectionId = c.Long(nullable: false, identity: true),
                        SectionName = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SectionName",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { IsUnique: True }")
                                },
                            }),
                    })
                .PrimaryKey(t => t.SectionId);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        SubCategoryId = c.Long(nullable: false, identity: true),
                        SubCategoryName = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SubCategoryName",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { IsUnique: True }")
                                },
                            }),
                        Description = c.String(),
                        CategoryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.SubCategoryId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "CategoryName",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { IsUnique: True }")
                                },
                            }),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Long(nullable: false, identity: true),
                        PublicOrderID = c.String(),
                        OrderDate = c.Long(nullable: false),
                        CompanyName = c.String(),
                        ProductQty = c.Long(),
                        ProductType = c.String(),
                        ServiceType = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.Long(nullable: false, identity: true),
                        PublicSupplierID = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        tel = c.Int(nullable: false),
                        email = c.String(),
                        suppliedtype = c.String(),
                        companyName = c.String(),
                        companyAddress = c.String(),
                        companyPhone = c.Int(nullable: false),
                        AddedDate = c.Long(nullable: false),
                        Brand = c.String(),
                        ProductID = c.String(),
                        ServiceName = c.String(),
                        ServiceRate = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.SupplierID);
            
            CreateTable(
                "dbo.SupplierPayments",
                c => new
                    {
                        SupplierPaymentID = c.Long(nullable: false, identity: true),
                        PaymentPublicID = c.String(),
                        SupplierDeliverCost = c.Double(nullable: false),
                        DueDate = c.Long(nullable: false),
                        PayingDate = c.Long(nullable: false),
                        subTotal = c.Single(nullable: false),
                        TotalCost = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierPaymentID);
            
            AddColumn("dbo.Customers", "CustomerPublicID", c => c.String());
            AddColumn("dbo.Customers", "FirstName", c => c.String());
            AddColumn("dbo.Customers", "LastName", c => c.String());
            AddColumn("dbo.Customers", "Address", c => c.String());
            AddColumn("dbo.Customers", "Email", c => c.String());
            AddColumn("dbo.Customers", "City", c => c.String());
            AddColumn("dbo.Customers", "DOB", c => c.Long(nullable: false));
            AddColumn("dbo.Customers", "Phone", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Password", c => c.String());
            AddColumn("dbo.Customers", "CurrentLoyaltyCardID", c => c.Long(nullable: false));
            AddColumn("dbo.Products", "ProductBrand", c => c.String());
            AddColumn("dbo.Products", "Barcode", c => c.String());
            AddColumn("dbo.Products", "Cost", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "NotifyDay", c => c.Int());
            AddColumn("dbo.Products", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "PriceType", c => c.Byte(nullable: false));
            AddColumn("dbo.Products", "NumberOfUnits", c => c.Int());
            AddColumn("dbo.Products", "Unit", c => c.Double());
            AddColumn("dbo.Products", "RackId", c => c.Long());
            AddColumn("dbo.Products", "SubCategoryId", c => c.Long(nullable: false));
            AlterColumn("dbo.Products", "ProductPublicId", c => c.String(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ProductPublicId",
                        new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { IsUnique: True }")
                    },
                }));
            CreateIndex("dbo.Customers", "CurrentLoyaltyCardID");
            CreateIndex("dbo.Products", "RackId");
            CreateIndex("dbo.Products", "SubCategoryId");
            AddForeignKey("dbo.Customers", "CurrentLoyaltyCardID", "dbo.LoyaltyCards", "LoyaltyCardID", cascadeDelete: true);
            AddForeignKey("dbo.Products", "RackId", "dbo.Racks", "RackId", cascadeDelete: true);
            AddForeignKey("dbo.Products", "SubCategoryId", "dbo.SubCategories", "SubCategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "RackId", "dbo.Racks");
            DropForeignKey("dbo.Racks", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.Preorders", "CurrentCustomerID", "dbo.Customers");
            DropForeignKey("dbo.Customers", "CurrentLoyaltyCardID", "dbo.LoyaltyCards");
            DropForeignKey("dbo.LoyaltyCards", "CurrentLoyatyprogramID", "dbo.LoyaltyPrograms");
            DropForeignKey("dbo.Logins", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Credits", "CustomerID", "dbo.Customers");
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            DropIndex("dbo.Racks", new[] { "SectionId" });
            DropIndex("dbo.Products", new[] { "SubCategoryId" });
            DropIndex("dbo.Products", new[] { "RackId" });
            DropIndex("dbo.Preorders", new[] { "CurrentCustomerID" });
            DropIndex("dbo.LoyaltyCards", new[] { "CurrentLoyatyprogramID" });
            DropIndex("dbo.Logins", new[] { "CustomerID" });
            DropIndex("dbo.Credits", new[] { "CustomerID" });
            DropIndex("dbo.Customers", new[] { "CurrentLoyaltyCardID" });
            AlterColumn("dbo.Products", "ProductPublicId", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ProductPublicId",
                        new AnnotationValues(oldValue: "IndexAnnotation: { IsUnique: True }", newValue: null)
                    },
                }));
            DropColumn("dbo.Products", "SubCategoryId");
            DropColumn("dbo.Products", "RackId");
            DropColumn("dbo.Products", "Unit");
            DropColumn("dbo.Products", "NumberOfUnits");
            DropColumn("dbo.Products", "PriceType");
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Products", "NotifyDay");
            DropColumn("dbo.Products", "Cost");
            DropColumn("dbo.Products", "Barcode");
            DropColumn("dbo.Products", "ProductBrand");
            DropColumn("dbo.Customers", "CurrentLoyaltyCardID");
            DropColumn("dbo.Customers", "Password");
            DropColumn("dbo.Customers", "Phone");
            DropColumn("dbo.Customers", "DOB");
            DropColumn("dbo.Customers", "City");
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Customers", "Address");
            DropColumn("dbo.Customers", "LastName");
            DropColumn("dbo.Customers", "FirstName");
            DropColumn("dbo.Customers", "CustomerPublicID");
            DropTable("dbo.SupplierPayments");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Orders");
            DropTable("dbo.Categories",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CategoryName",
                        new Dictionary<string, object>
                        {
                            { "CategoryName", "IndexAnnotation: { IsUnique: True }" },
                        }
                    },
                });
            DropTable("dbo.SubCategories",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "SubCategoryName",
                        new Dictionary<string, object>
                        {
                            { "SubCategoryName", "IndexAnnotation: { IsUnique: True }" },
                        }
                    },
                });
            DropTable("dbo.Sections",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "SectionName",
                        new Dictionary<string, object>
                        {
                            { "SectionName", "IndexAnnotation: { IsUnique: True }" },
                        }
                    },
                });
            DropTable("dbo.Racks",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "RackName",
                        new Dictionary<string, object>
                        {
                            { "RackName", "IndexAnnotation: { IsUnique: True }" },
                        }
                    },
                });
            DropTable("dbo.Preorders");
            DropTable("dbo.LoyaltyPrograms");
            DropTable("dbo.LoyaltyCards");
            DropTable("dbo.Logins");
            DropTable("dbo.Credits");
        }
    }
}
