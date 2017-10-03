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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.Products", "RackId", "dbo.Racks");
            DropForeignKey("dbo.Racks", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Racks", new[] { "SectionId" });
            DropIndex("dbo.Products", new[] { "SubCategoryId" });
            DropIndex("dbo.Products", new[] { "RackId" });
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
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
        }
    }
}
