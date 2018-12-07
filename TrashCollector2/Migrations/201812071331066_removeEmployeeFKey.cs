namespace TrashCollector2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeEmployeeFKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Employees", new[] { "CustomerId" });
            DropColumn("dbo.Employees", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "CustomerId");
            AddForeignKey("dbo.Employees", "CustomerId", "dbo.Customers", "ID", cascadeDelete: true);
        }
    }
}
