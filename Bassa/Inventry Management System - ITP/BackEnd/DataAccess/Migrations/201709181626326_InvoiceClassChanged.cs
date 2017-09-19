namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceClassChanged : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Invoices", name: "EmployeeID", newName: "IssuedByID");
            RenameIndex(table: "dbo.Invoices", name: "IX_EmployeeID", newName: "IX_IssuedByID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Invoices", name: "IX_IssuedByID", newName: "IX_EmployeeID");
            RenameColumn(table: "dbo.Invoices", name: "IssuedByID", newName: "EmployeeID");
        }
    }
}
