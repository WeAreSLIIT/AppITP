namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCoutersTableUniqueKeyIssue : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Counters", "IX_BranchCounterID");
            CreateIndex("dbo.Counters", new[] { "BranchID", "BranchCounterNo" }, unique: true, name: "IX_BranchCounterID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Counters", "IX_BranchCounterID");
            CreateIndex("dbo.Counters", new[] { "BranchID", "CounterID" }, unique: true, name: "IX_BranchCounterID");
        }
    }
}
