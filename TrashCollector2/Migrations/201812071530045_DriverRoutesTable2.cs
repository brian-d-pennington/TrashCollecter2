namespace TrashCollector2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DriverRoutesTable2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DriverRoutes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DriverRoutes", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.DriverRoutes", "CustomerId", "dbo.Customers");
            DropIndex("dbo.DriverRoutes", new[] { "CustomerId" });
            DropIndex("dbo.DriverRoutes", new[] { "EmployeeId" });
            DropTable("dbo.DriverRoutes");
        }
    }
}
