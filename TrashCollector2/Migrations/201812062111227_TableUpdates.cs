namespace TrashCollector2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableUpdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "CustomerId");
            AddForeignKey("dbo.Employees", "CustomerId", "dbo.Customers", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Employees", new[] { "CustomerId" });
            DropColumn("dbo.Employees", "CustomerId");
        }
    }
}
