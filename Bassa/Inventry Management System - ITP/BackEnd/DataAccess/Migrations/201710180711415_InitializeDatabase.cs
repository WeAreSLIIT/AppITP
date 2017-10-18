namespace DataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDatabase : DbMigration
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
                        BranchTitle = c.String(),
                        Longtitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        BranchLevel = c.Int(nullable: false),
                        Address = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.BranchID);
            
            CreateTable(
                "dbo.Counters",
                c => new
                    {
                        CounterID = c.Long(nullable: false, identity: true),
                        BranchCounterNo = c.Long(nullable: false),
                        BranchID = c.Long(nullable: false),
                        Disabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CounterID)
                .ForeignKey("dbo.Branches", t => t.BranchID)
                .Index(t => new { t.BranchID, t.BranchCounterNo }, unique: true, name: "IX_BranchCounterID");
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Long(nullable: false, identity: true),
                        InvoicePublicID = c.String(nullable: false, maxLength: 30),
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
                .ForeignKey("dbo.People", t => t.IssuedByID)
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
                        CustomerPublicID = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        City = c.String(),
                        DOB = c.Long(nullable: false),
                        Phone = c.Int(nullable: false),
                        Password = c.String(),
                        CurrentLoyaltyCardID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.LoyaltyCards", t => t.CurrentLoyaltyCardID, cascadeDelete: true)
                .Index(t => t.CurrentLoyaltyCardID);
            
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
                .ForeignKey("dbo.People", t => t.GivenEmployeeID, cascadeDelete: true)
                .Index(t => t.GivenEmployeeID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        InitialName = c.String(),
                        Street = c.String(),
                        Town = c.String(),
                        City = c.String(),
                        Province = c.String(),
                        NIC = c.String(),
                        Email = c.String(),
                        Gender = c.Byte(nullable: false),
                        EmployeeID = c.Long(),
                        JobTitle = c.String(),
                        Suspend = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PersonID);
            
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
                .ForeignKey("dbo.People", t => t.PermittedEmployeeID)
                .Index(t => t.PermittedEmployeeID)
                .Index(t => t.Invoice_InvoiceID);
            
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
                        ProductId = c.Long(nullable: false, identity: true),
                        ProductPublicId = c.String(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ProductPublicId",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { IsUnique: True }")
                                },
                            }),
                        ProductName = c.String(),
                        ProductBrand = c.String(),
                        Barcode = c.String(),
                        Cost = c.Double(nullable: false),
                        NotifyDay = c.Int(),
                        Price = c.Double(nullable: false),
                        PriceType = c.Byte(nullable: false),
                        NumberOfUnits = c.Int(),
                        Unit = c.Double(),
                        RackId = c.Long(),
                        SubCategoryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Racks", t => t.RackId)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryId)
                .Index(t => t.RackId)
                .Index(t => t.SubCategoryId);
            
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
                "dbo.Discounts",
                c => new
                    {
                        DiscountID = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.DiscountID);
            
            CreateTable(
                "dbo.DiscountSchedules",
                c => new
                    {
                        DiscountSheduleId = c.Long(nullable: false, identity: true),
                        DiscountTypeId = c.Long(nullable: false),
                        DiscountShedulePublicId = c.String(),
                        DiscountSheduleItemCode = c.String(),
                        OriginalPrice = c.Single(nullable: false),
                        PriceWithDiscount = c.Single(nullable: false),
                        DiscountSheduleFrom = c.Long(nullable: false),
                        DiscountSheduleTo = c.Long(nullable: false),
                        DiscountAmount = c.Single(nullable: false),
                        Method = c.Byte(nullable: false),
                        DiscountMethod = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.DiscountSheduleId)
                .ForeignKey("dbo.DiscountTypes", t => t.DiscountTypeId, cascadeDelete: true)
                .Index(t => t.DiscountTypeId);
            
            CreateTable(
                "dbo.DiscountTypes",
                c => new
                    {
                        DiscountTypeId = c.Long(nullable: false, identity: true),
                        DiscountTypePublicId = c.String(),
                        DiscountTypeName = c.String(nullable: false),
                        DiscountTimeSpan = c.Long(nullable: false),
                        DiscountTypeTax = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.DiscountTypeId);
            
            CreateTable(
                "dbo.GiftVoucherIssues",
                c => new
                    {
                        IssueGiftVoucherCode = c.Long(nullable: false, identity: true),
                        GiftVoucherTypeId = c.Long(nullable: false),
                        IssueGiftVoucherPublicCode = c.String(),
                        IssueGiftVoucherTypeId = c.String(),
                        IssueGiftVoucherAmount = c.Single(nullable: false),
                        IssueGiftVoucherTo = c.String(nullable: false),
                        IssueGiftVoucherEmail = c.String(nullable: false),
                        IssueGiftVoucherPhone = c.Int(nullable: false),
                        IssueGiftVoucherSKU = c.Long(nullable: false),
                        GiftVoucherStatus = c.Byte(nullable: false),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.IssueGiftVoucherCode)
                .ForeignKey("dbo.GiftVoucherTypes", t => t.GiftVoucherTypeId, cascadeDelete: true)
                .Index(t => t.GiftVoucherTypeId);
            
            CreateTable(
                "dbo.GiftVoucherTypes",
                c => new
                    {
                        GiftVoucherTypeId = c.Long(nullable: false, identity: true),
                        GiftVoucherTypePublicId = c.String(),
                        GiftVoucherTypeName = c.String(nullable: false),
                        GiftVoucherTypeAmount = c.Single(nullable: false),
                        GiftVoucherTypeDescription = c.String(nullable: false, maxLength: 255),
                        GiftVoucherTypeNoOfDays = c.Int(nullable: false),
                        GiftVoucherExpiration = c.Byte(nullable: false),
                        ExpireStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GiftVoucherTypeId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        PublicItemCode = c.String(nullable: false, maxLength: 128),
                        ItemCode = c.Long(nullable: false),
                        ItemName = c.String(),
                        ItemCategory = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PublicItemCode);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        StockID = c.Long(nullable: false, identity: true),
                        PublicStockID = c.String(),
                        PublicItemCode = c.String(maxLength: 128),
                        ItemName = c.String(),
                        ItemCategory = c.String(),
                        PurchaseOrder = c.String(),
                        UoM = c.String(),
                        InitQty = c.Int(nullable: false),
                        PresentQty = c.Int(nullable: false),
                        WholeSaleValue = c.Single(nullable: false),
                        UnitPrice = c.Single(nullable: false),
                        GRNnum = c.String(),
                        StockStatus = c.Byte(nullable: false),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.StockID)
                .ForeignKey("dbo.Items", t => t.PublicItemCode)
                .Index(t => t.PublicItemCode);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        LogID = c.Long(nullable: false, identity: true),
                        UserAccountID = c.Long(nullable: false),
                        ModuleID = c.Long(nullable: false),
                        Activity = c.String(),
                    })
                .PrimaryKey(t => t.LogID)
                .ForeignKey("dbo.Modules", t => t.ModuleID, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccountID, cascadeDelete: true)
                .Index(t => t.UserAccountID)
                .Index(t => t.ModuleID);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        ModuleID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Route = c.String(),
                        Description = c.String(),
                        Suspend = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleID);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        UserAccountID = c.Long(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        EmployeeID = c.Long(nullable: false),
                        UserRoleID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.UserAccountID)
                .ForeignKey("dbo.People", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.UserRoles", t => t.UserRoleID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.UserRoleID);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        AuthorizationLevel = c.Long(nullable: false),
                        Description = c.String(),
                        Suspend = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserRoleID);
            
            CreateTable(
                "dbo.Privileges",
                c => new
                    {
                        PrivilegeID = c.Long(nullable: false, identity: true),
                        ModuleID = c.Long(nullable: false),
                        UserRole_UserRoleID = c.Long(),
                    })
                .PrimaryKey(t => t.PrivilegeID)
                .ForeignKey("dbo.Modules", t => t.ModuleID, cascadeDelete: true)
                .ForeignKey("dbo.UserRoles", t => t.UserRole_UserRoleID)
                .Index(t => t.ModuleID)
                .Index(t => t.UserRole_UserRoleID);
            
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
                "dbo.PromotionSchedules",
                c => new
                    {
                        PromoSheduleId = c.Long(nullable: false, identity: true),
                        PromoTypeId = c.Long(nullable: false),
                        PromoShedulePublicId = c.String(),
                        PromoSheduleItemCode = c.String(nullable: false),
                        PromoSheduleName = c.String(nullable: false),
                        PromoSheduleType = c.String(nullable: false),
                        SpecialStock = c.String(),
                        PromoSheduleDescription = c.String(maxLength: 255),
                        PromoSheduleFrom = c.Long(nullable: false),
                        PromoSheduleTo = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.PromoSheduleId)
                .ForeignKey("dbo.PromotionTypes", t => t.PromoTypeId, cascadeDelete: true)
                .Index(t => t.PromoTypeId);
            
            CreateTable(
                "dbo.PromotionTypes",
                c => new
                    {
                        PromoTypeId = c.Long(nullable: false, identity: true),
                        PromoTypePublicId = c.String(),
                        PromoTypeName = c.String(nullable: false),
                        PromoTimeSpan = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.PromoTypeId);
            
            CreateTable(
                "dbo.Recounts",
                c => new
                    {
                        RecountStockId = c.Long(nullable: false, identity: true),
                        RecountStockCode = c.String(),
                        StockStatus = c.Byte(nullable: false),
                        ChangedQty = c.Int(nullable: false),
                        RecountStartDate = c.Long(nullable: false),
                        RecountEndDate = c.Long(nullable: false),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.RecountStockId);
            
            CreateTable(
                "dbo.ReturnStocks",
                c => new
                    {
                        ReturnStockID = c.Long(nullable: false, identity: true),
                        ReturnStockCode = c.String(),
                        ReturnCause = c.String(),
                        ReturnQty = c.Int(nullable: false),
                        Replacement = c.String(),
                        ReturnedToSupplier = c.String(),
                    })
                .PrimaryKey(t => t.ReturnStockID);
            
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
            
            CreateTable(
                "dbo.SystemDetails",
                c => new
                    {
                        SystemDetailsID = c.Long(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Logo = c.String(),
                        Description = c.String(),
                        BranchID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.SystemDetailsID)
                .ForeignKey("dbo.Branches", t => t.BranchID, cascadeDelete: true)
                .Index(t => t.BranchID);
            
            CreateTable(
                "dbo.TableVersions",
                c => new
                    {
                        TableID = c.Byte(nullable: false),
                        Time = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.TableID);
            
            CreateTable(
                "dbo.TransInStocks",
                c => new
                    {
                        TransInStockID = c.Long(nullable: false, identity: true),
                        TransInStockCode = c.String(),
                        FromBranchId = c.String(),
                        FromBranchLoc = c.String(),
                        RecievedQty = c.Int(nullable: false),
                        RecievedDate = c.Long(nullable: false),
                        PublicItemCode = c.String(maxLength: 128),
                        ItemName = c.String(),
                        ItemCategory = c.String(),
                        UoM = c.String(),
                        Qty = c.Int(nullable: false),
                        WholeSaleValue = c.Single(nullable: false),
                        UnitPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.TransInStockID)
                .ForeignKey("dbo.Items", t => t.PublicItemCode)
                .Index(t => t.PublicItemCode);
            
            CreateTable(
                "dbo.TransOuts",
                c => new
                    {
                        TransOutStockID = c.Long(nullable: false, identity: true),
                        TransOutStockCode = c.String(),
                        SentQty = c.Int(nullable: false),
                        SentDate = c.Long(nullable: false),
                        GatePass = c.String(),
                    })
                .PrimaryKey(t => t.TransOutStockID);
            
            CreateTable(
                "dbo.Wastages",
                c => new
                    {
                        WastageStockID = c.Long(nullable: false, identity: true),
                        WastageStockCode = c.String(),
                        WastageCause = c.String(),
                        WastageQty = c.Int(nullable: false),
                        WastageValue = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.WastageStockID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransInStocks", "PublicItemCode", "dbo.Items");
            DropForeignKey("dbo.SystemDetails", "BranchID", "dbo.Branches");
            DropForeignKey("dbo.PromotionSchedules", "PromoTypeId", "dbo.PromotionTypes");
            DropForeignKey("dbo.Logs", "UserAccountID", "dbo.UserAccounts");
            DropForeignKey("dbo.UserAccounts", "UserRoleID", "dbo.UserRoles");
            DropForeignKey("dbo.Privileges", "UserRole_UserRoleID", "dbo.UserRoles");
            DropForeignKey("dbo.Privileges", "ModuleID", "dbo.Modules");
            DropForeignKey("dbo.UserAccounts", "EmployeeID", "dbo.People");
            DropForeignKey("dbo.Logs", "ModuleID", "dbo.Modules");
            DropForeignKey("dbo.Stocks", "PublicItemCode", "dbo.Items");
            DropForeignKey("dbo.GiftVoucherIssues", "GiftVoucherTypeId", "dbo.GiftVoucherTypes");
            DropForeignKey("dbo.DiscountSchedules", "DiscountTypeId", "dbo.DiscountTypes");
            DropForeignKey("dbo.Invoices", "IssuedByID", "dbo.People");
            DropForeignKey("dbo.InvoiceProduct", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "RackId", "dbo.Racks");
            DropForeignKey("dbo.Racks", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.InvoiceProduct", "InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.InvoicePaymentMethods", "PaymentMethodID", "dbo.PaymentMethods");
            DropForeignKey("dbo.InvoicePaymentMethods", "InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.InvoiceDeals", "InvoiceDealDiscountID", "dbo.InvoiceDealDiscount");
            DropForeignKey("dbo.InvoiceDealDiscount", "GivenEmployeeID", "dbo.People");
            DropForeignKey("dbo.InvoiceEmployeeDiscounts", "PermittedEmployeeID", "dbo.People");
            DropForeignKey("dbo.InvoiceEmployeeDiscounts", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.InvoiceDeals", "InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.InvoiceCustomers", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Preorders", "CurrentCustomerID", "dbo.Customers");
            DropForeignKey("dbo.Customers", "CurrentLoyaltyCardID", "dbo.LoyaltyCards");
            DropForeignKey("dbo.LoyaltyCards", "CurrentLoyatyprogramID", "dbo.LoyaltyPrograms");
            DropForeignKey("dbo.Logins", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Credits", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.InvoiceCustomers", "InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "CounterID", "dbo.Counters");
            DropForeignKey("dbo.Counters", "BranchID", "dbo.Branches");
            DropIndex("dbo.TransInStocks", new[] { "PublicItemCode" });
            DropIndex("dbo.SystemDetails", new[] { "BranchID" });
            DropIndex("dbo.PromotionSchedules", new[] { "PromoTypeId" });
            DropIndex("dbo.Privileges", new[] { "UserRole_UserRoleID" });
            DropIndex("dbo.Privileges", new[] { "ModuleID" });
            DropIndex("dbo.UserAccounts", new[] { "UserRoleID" });
            DropIndex("dbo.UserAccounts", new[] { "EmployeeID" });
            DropIndex("dbo.Logs", new[] { "ModuleID" });
            DropIndex("dbo.Logs", new[] { "UserAccountID" });
            DropIndex("dbo.Stocks", new[] { "PublicItemCode" });
            DropIndex("dbo.GiftVoucherIssues", new[] { "GiftVoucherTypeId" });
            DropIndex("dbo.DiscountSchedules", new[] { "DiscountTypeId" });
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            DropIndex("dbo.Racks", new[] { "SectionId" });
            DropIndex("dbo.Products", new[] { "SubCategoryId" });
            DropIndex("dbo.Products", new[] { "RackId" });
            DropIndex("dbo.InvoiceProduct", new[] { "ProductID" });
            DropIndex("dbo.InvoiceProduct", new[] { "InvoiceID" });
            DropIndex("dbo.PaymentMethods", new[] { "PaymentMethodName" });
            DropIndex("dbo.InvoicePaymentMethods", new[] { "PaymentMethodID" });
            DropIndex("dbo.InvoicePaymentMethods", new[] { "InvoiceID" });
            DropIndex("dbo.InvoiceEmployeeDiscounts", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.InvoiceEmployeeDiscounts", new[] { "PermittedEmployeeID" });
            DropIndex("dbo.InvoiceDealDiscount", new[] { "GivenEmployeeID" });
            DropIndex("dbo.InvoiceDeals", new[] { "InvoiceDealDiscountID" });
            DropIndex("dbo.InvoiceDeals", new[] { "InvoiceID" });
            DropIndex("dbo.Preorders", new[] { "CurrentCustomerID" });
            DropIndex("dbo.LoyaltyCards", new[] { "CurrentLoyatyprogramID" });
            DropIndex("dbo.Logins", new[] { "CustomerID" });
            DropIndex("dbo.Credits", new[] { "CustomerID" });
            DropIndex("dbo.Customers", new[] { "CurrentLoyaltyCardID" });
            DropIndex("dbo.InvoiceCustomers", new[] { "CustomerID" });
            DropIndex("dbo.InvoiceCustomers", new[] { "InvoiceID" });
            DropIndex("dbo.Invoices", new[] { "CounterID" });
            DropIndex("dbo.Invoices", new[] { "IssuedByID" });
            DropIndex("dbo.Invoices", new[] { "InvoicePublicID" });
            DropIndex("dbo.Counters", "IX_BranchCounterID");
            DropTable("dbo.Wastages");
            DropTable("dbo.TransOuts");
            DropTable("dbo.TransInStocks");
            DropTable("dbo.TableVersions");
            DropTable("dbo.SystemDetails");
            DropTable("dbo.SupplierPayments");
            DropTable("dbo.ReturnStocks");
            DropTable("dbo.Recounts");
            DropTable("dbo.PromotionTypes");
            DropTable("dbo.PromotionSchedules");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Orders");
            DropTable("dbo.Privileges");
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.Modules");
            DropTable("dbo.Logs");
            DropTable("dbo.Stocks");
            DropTable("dbo.Items");
            DropTable("dbo.GiftVoucherTypes");
            DropTable("dbo.GiftVoucherIssues");
            DropTable("dbo.DiscountTypes");
            DropTable("dbo.DiscountSchedules");
            DropTable("dbo.Discounts");
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
            DropTable("dbo.Products",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ProductPublicId",
                        new Dictionary<string, object>
                        {
                            { "ProductPublicId", "IndexAnnotation: { IsUnique: True }" },
                        }
                    },
                });
            DropTable("dbo.InvoiceProduct");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.InvoicePaymentMethods");
            DropTable("dbo.InvoiceEmployeeDiscounts");
            DropTable("dbo.People");
            DropTable("dbo.InvoiceDealDiscount");
            DropTable("dbo.InvoiceDeals");
            DropTable("dbo.Preorders");
            DropTable("dbo.LoyaltyPrograms");
            DropTable("dbo.LoyaltyCards");
            DropTable("dbo.Logins");
            DropTable("dbo.Credits");
            DropTable("dbo.Customers");
            DropTable("dbo.InvoiceCustomers");
            DropTable("dbo.Invoices");
            DropTable("dbo.Counters");
            DropTable("dbo.Branches");
        }
    }
}
