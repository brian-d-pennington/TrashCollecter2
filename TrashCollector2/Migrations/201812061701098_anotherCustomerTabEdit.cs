namespace TrashCollector2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotherCustomerTabEdit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Day2", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Month2", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Year2", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Day3", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Month3", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Year3", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Year3");
            DropColumn("dbo.Customers", "Month3");
            DropColumn("dbo.Customers", "Day3");
            DropColumn("dbo.Customers", "Year2");
            DropColumn("dbo.Customers", "Month2");
            DropColumn("dbo.Customers", "Day2");
        }
    }
}
