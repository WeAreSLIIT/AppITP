namespace Inventory_Management_System.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
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
                        Barcode = c.String(),
                        ProductName = c.String(),
                        ProductBrand = c.String(),
                        Cost = c.Double(nullable: false),
                        NotifyDay = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        PriceType = c.Byte(nullable: false),
                        NumberOfUnits = c.Int(nullable: false),
                        Unit = c.Double(nullable: false),
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
                        RackName = c.String(),
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
                        SectionName = c.String(),
                    })
                .PrimaryKey(t => t.SectionId);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        CategoryId = c.Long(nullable: false),
                        Description = c.String(),
                        MainCategoryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Categories", t => t.MainCategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.MainCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCategories", "MainCategoryId", "dbo.Categories");
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.Products", "RackId", "dbo.Racks");
            DropForeignKey("dbo.Racks", "SectionId", "dbo.Sections");
            DropIndex("dbo.SubCategories", new[] { "MainCategoryId" });
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            DropIndex("dbo.Racks", new[] { "SectionId" });
            DropIndex("dbo.Products", new[] { "SubCategoryId" });
            DropIndex("dbo.Products", new[] { "RackId" });
            DropTable("dbo.SubCategories");
            DropTable("dbo.Sections");
            DropTable("dbo.Racks");
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
            DropTable("dbo.Categories");
        }
    }
}
