namespace TrashCollector2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCustomerTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Day");
            DropColumn("dbo.Customers", "Month");
            DropColumn("dbo.Customers", "Year");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Month", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "Day", c => c.Int(nullable: false));
        }
    }
}
