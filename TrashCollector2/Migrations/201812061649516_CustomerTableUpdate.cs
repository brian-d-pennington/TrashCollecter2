namespace TrashCollector2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerTableUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Day", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Month", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Year");
            DropColumn("dbo.Customers", "Month");
            DropColumn("dbo.Customers", "Day");
        }
    }
}
