namespace CCiezkiCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class calendarevents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FullcalendarModels",
                c => new
                    {
                        event_id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false),
                        date = c.DateTime(nullable: false),
                        start = c.String(nullable: false),
                        end = c.String(),
                        url = c.String(),
                        description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.event_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FullcalendarModels");
        }
    }
}
