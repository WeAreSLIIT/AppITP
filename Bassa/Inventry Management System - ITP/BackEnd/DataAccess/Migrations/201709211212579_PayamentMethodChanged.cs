namespace DataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class PayamentMethodChanged : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceControlApps",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "InvoiceControlAppUsername",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { IsUnique: True }")
                                },
                            }),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Invoices", "InvoiceControlAppID", c => c.Long(nullable: false));
            AddColumn("dbo.PaymentMethods", "PaymentMethodNote", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.PaymentMethods", "PaymentMethodName", c => c.String(nullable: false, maxLength: 50,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "PaymentMethodName",
                        new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { IsUnique: True }")
                    },
                }));
            CreateIndex("dbo.Invoices", "InvoiceControlAppID");
            AddForeignKey("dbo.Invoices", "InvoiceControlAppID", "dbo.InvoiceControlApps", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "InvoiceControlAppID", "dbo.InvoiceControlApps");
            DropIndex("dbo.Invoices", new[] { "InvoiceControlAppID" });
            AlterColumn("dbo.PaymentMethods", "PaymentMethodName", c => c.String(nullable: false, maxLength: 100,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "PaymentMethodName",
                        new AnnotationValues(oldValue: "IndexAnnotation: { IsUnique: True }", newValue: null)
                    },
                }));
            DropColumn("dbo.PaymentMethods", "PaymentMethodNote");
            DropColumn("dbo.Invoices", "InvoiceControlAppID");
            DropTable("dbo.InvoiceControlApps",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Username",
                        new Dictionary<string, object>
                        {
                            { "InvoiceControlAppUsername", "IndexAnnotation: { IsUnique: True }" },
                        }
                    },
                });
        }
    }
}
