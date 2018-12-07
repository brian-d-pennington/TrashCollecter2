namespace TrashCollector2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DaysOfTheWeekupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DaysOfTheWeeks", "Weekday", c => c.String());
            DropColumn("dbo.DaysOfTheWeeks", "Day");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DaysOfTheWeeks", "Day", c => c.String());
            DropColumn("dbo.DaysOfTheWeeks", "Weekday");
        }
    }
}
