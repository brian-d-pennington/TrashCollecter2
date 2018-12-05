namespace TrashCollector2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "SpecialRequest", c => c.DateTime());
            AlterColumn("dbo.Customers", "SuspendStartDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "ResumeServiceDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "ResumeServiceDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "SuspendStartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "SpecialRequest", c => c.DateTime(nullable: false));
        }
    }
}
