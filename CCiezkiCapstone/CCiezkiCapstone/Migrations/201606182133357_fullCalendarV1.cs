namespace CCiezkiCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fullCalendarV1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FullcalendarModels", "description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FullcalendarModels", "description", c => c.String());
        }
    }
}
